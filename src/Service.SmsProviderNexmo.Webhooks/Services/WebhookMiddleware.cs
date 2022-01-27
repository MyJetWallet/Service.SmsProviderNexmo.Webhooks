using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.ServiceBus;
using Service.SmsProviderNexmo.Domain.Models;

namespace Service.SmsProviderNexmo.Webhooks.Services
{
    public class WebhookMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<WebhookMiddleware> _logger;
        private readonly IServiceBusPublisher<NexmoSmsDeliveryReportMessage> _publisher;

        public WebhookMiddleware(
            RequestDelegate next,
            ILogger<WebhookMiddleware> logger, IServiceBusPublisher<NexmoSmsDeliveryReportMessage> publisher)
        {
            _next = next;
            _logger = logger;
            _publisher = publisher;
        }

        /// <summary>
        /// Invokes the middleware
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/nexmo", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Receive call to {path}, method: {method}", context.Request.Path,
                    context.Request.Method);
            }

            if (!context.Request.Path.StartsWithSegments("/nexmo/webhook", StringComparison.OrdinalIgnoreCase))
            {
                await _next.Invoke(context);
                return;
            }

            var path = context.Request.Path;
            var method = context.Request.Method;

            var body = "--none--";

            if (method == "POST")
            {
                await using var buffer = new MemoryStream();

                await context.Request.Body.CopyToAsync(buffer);

                buffer.Position = 0L;

                using var reader = new StreamReader(buffer);

                body = await reader.ReadToEndAsync();

                var queryString = HttpUtility.ParseQueryString(body);
                var temp =  queryString.AllKeys.ToDictionary(k => k, k => queryString[k]);

                await _publisher.PublishAsync(new NexmoSmsDeliveryReportMessage
                {
                    PhoneNumber = temp["msisdn"],
                    NetworkCode = temp["network-code"],
                    MessageId = temp["messageId"],
                    Price = temp["price"],
                    Status = temp["status"],
                    ErrorCode = temp["err-code"],
                    MessageTimestamp = DateTime.Parse(temp["message-timestamp"])
                });

            }

            var query = context.Request.QueryString;

            _logger.LogInformation($"'{path}' | {query} | {method}\n{body}");

            context.Response.StatusCode = 200;
        }
        
    }
}