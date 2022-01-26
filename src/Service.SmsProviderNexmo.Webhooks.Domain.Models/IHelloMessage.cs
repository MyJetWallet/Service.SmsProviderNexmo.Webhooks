using System;

namespace Service.SmsProviderNexmo.Webhooks.Domain.Models
{
    public interface IHelloMessage
    {
        string Message { get; set; }
    }
}
