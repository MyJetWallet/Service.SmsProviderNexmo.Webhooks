using Autofac;
using Service.SmsProviderNexmo.Webhooks.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.SmsProviderNexmo.Webhooks.Client
{
    public static class AutofacHelper
    {
        public static void RegisterSmsProviderNexmoWebhooksClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new SmsProviderNexmoWebhooksClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetHelloService()).As<IHelloService>().SingleInstance();
        }
    }
}
