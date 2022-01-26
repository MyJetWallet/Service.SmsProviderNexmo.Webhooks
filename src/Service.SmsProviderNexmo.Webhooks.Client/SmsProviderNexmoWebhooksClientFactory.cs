using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.SmsProviderNexmo.Webhooks.Grpc;

namespace Service.SmsProviderNexmo.Webhooks.Client
{
    [UsedImplicitly]
    public class SmsProviderNexmoWebhooksClientFactory: MyGrpcClientFactory
    {
        public SmsProviderNexmoWebhooksClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
