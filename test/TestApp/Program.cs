using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProtoBuf.Grpc.Client;
using Service.SmsProviderNexmo.Webhooks.Client;
using Service.SmsProviderNexmo.Webhooks.Grpc.Models;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            Console.Write("Press enter to start");
            Console.ReadLine();

            var t = "msisdn=380636957149&to=MyJetWallet&network-code=25506&messageId=150000006DA483C4&price=0.10500000&status=delivered&scts=2201271322&err-code=0&api-key=e0af2f3c&message-timestamp=2022-01-27+13%3A22%3A01";
            var t2 = HttpUtility.ParseQueryString(t);
            var t3 =  t2.AllKeys.ToDictionary(k => k, k => t2[k]);

            var f = new MyClass
            {
                PhoneNumber = t3["msisdn"],
                NetworkCode = t3["network-code"],
                MessageId = t3["messageId"],
                Price = t3["price"],
                Status = t3["status"],
                ErrorCode = t3["err-code"],
                MessageTimestamp = DateTime.Parse(t3["message-timestamp"])
            };

            Console.WriteLine("End");
            Console.ReadLine();
        }
        
        public class MyClass
        {
            public string PhoneNumber { get; set; }
            public string NetworkCode { get; set; }
            public string MessageId { get; set; }
            public string Price { get; set; }
            public string Status { get; set; }
            public string ErrorCode { get; set; }
            public DateTime MessageTimestamp { get; set; }
        }
    }
}
