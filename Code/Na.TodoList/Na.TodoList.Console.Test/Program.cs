using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace Na.TodoList.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.google.com/  ping www.google.com       
            //https://api.five9.com/ http://api.five9.com/ http://api.five9.com  ping api.five9.com   38.107.71.7

            string host = "https://" + "api.five9.com";

            var result = IsIPOrHostName(host);

            Console.WriteLine("IP ADDRESS");
            var ipAddress = GetIpAddress(host);
            Console.WriteLine(ipAddress + "\n");

            Console.WriteLine("PING");
            var pingResult = IsConnectedToInternet(host);
            Console.WriteLine(pingResult + "\n");

            Console.WriteLine("TRACERT");
            List<IPAddress> traceResult = GetTraceRoute(host).ToList();
            foreach (var item in traceResult)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static string IsIPOrHostName(string host)
        {
            var ipMatch = Regex.IsMatch(host, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$");

            IPAddress ip;
            bool isIp = IPAddress.TryParse(host, out ip);

            var ipHostName = Regex.IsMatch(host, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");

            bool isUri = Uri.IsWellFormedUriString(host, UriKind.RelativeOrAbsolute);

            return "";
        }

        public static string GetIpAddress(string urlx)
        {
            Uri uri = new Uri(urlx);
            string pingurl = string.Format("{0}", uri.Host);
            string host = pingurl;            

            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return reply.Address.ToString();
            }
            catch { }

            return "No Ip Address";
        }

        public static bool IsConnectedToInternet(string urlx)
        {
            Uri uri = new Uri(urlx);
            string pingurl = string.Format("{0}", uri.Host);
            string host = pingurl;
            bool result = false;

            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }

            return result;
        }

        public static IEnumerable<IPAddress> GetTraceRoute(string urlx)
        {
            // following are similar to the defaults in the "traceroute" unix command.
            const int timeout = 10000;
            const int maxTTL = 30;
            const int bufferSize = 32;

            byte[] buffer = new byte[bufferSize];
            new Random().NextBytes(buffer);

            Uri uri = new Uri(urlx);
            string pingurl = string.Format("{0}", uri.Host);
            string host = pingurl;

            using (var pinger = new Ping())
            {
                for (int ttl = 1; ttl <= maxTTL; ttl++)
                {
                    PingOptions options = new PingOptions(ttl, true);
                    PingReply reply = pinger.Send(host, timeout, buffer, options);

                    // we've found a route at this ttl
                    if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired)
                        yield return reply.Address;

                    // if we reach a status other than expired or timed out, we're done searching or there has been an error
                    if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.TimedOut)
                        break;
                }
            }
        }
    }
}
