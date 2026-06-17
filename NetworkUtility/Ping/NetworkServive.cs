using System.Net.NetworkInformation;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dns;

        //ctor
        public NetworkService(IDNS dns)
        {
            _dns = dns;
        }

        public string SendPing()
        {
            var dnsSuccess = _dns.SendDns();

            if (dnsSuccess)
            {
                return "Success: Ping Sent!";
            }
            else
            {
                return "Failed: Ping Not Sent!";
            }
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 2
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 3
                }
            };

            return pingOptions;
        }
    }
}
