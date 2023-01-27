using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shecan_Desktop.utilities
{
    internal class ConnectionManager
    {
        public async Task<bool> IsConnectedToShecanAsync()
        {
            using (WebClient hc = new WebClient())
            {
                string result = "";
                try
                {
                    string link = "https://check.shecan.ir:8443/?" + new Random().Next();
                    result = await hc.DownloadStringTaskAsync(link);
                }
                catch
                {
                }
                return result == "1";
            }
        }
    }
}
