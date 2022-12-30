using Microsoft.Extensions.Options;
using System.Net;

namespace Project_NTT_data.MiddleWares
{
    public class IPSafeMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IPList _Iplist;

        public IPSafeMiddleWare(RequestDelegate next, IOptions<IPList> ipList) /*to fill the iplist out from appsettings.json file we used IOptions<T>*/
        {
            _next= next;
            _Iplist = ipList.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var RequestIP = httpContext.Connection.RemoteIpAddress; // to get the IP addrees which belongs to client
            var WhiteList = _Iplist.WhiteList.Where(ip => IPAddress.Parse(ip).Equals(RequestIP)).Any(); //Parse - the strings that coming from appsettings.json need to convert IP Address. That is the reason for IPAddress.Parse(ip)
            if(!WhiteList)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden; 
                return;
            }
            await _next.Invoke(httpContext);

        }
    }
}
