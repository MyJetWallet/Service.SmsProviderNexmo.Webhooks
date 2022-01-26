using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.SmsProviderNexmo.Webhooks.Settings
{
    public class SettingsModel
    {
        [YamlProperty("SmsProviderNexmoWebhooks.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("SmsProviderNexmoWebhooks.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("SmsProviderNexmoWebhooks.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
