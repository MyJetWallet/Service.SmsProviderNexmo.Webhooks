using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MyJetWallet.Sdk.ServiceBus;
using Service.SmsProviderNexmo.Client;

namespace Service.SmsProviderNexmo.Webhooks.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceBus =
                builder.RegisterMyServiceBusTcpClient(Program.ReloadedSettings(t => t.SpotServiceBusHostPort),
                    Program.LogFactory);
            var queue = $"Sms-Nexmo-Webhook";
            
            builder.RegisterNexmoReportMessagePublisher(serviceBus);
        }
    }
}