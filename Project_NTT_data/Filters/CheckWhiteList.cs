using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Project_NTT_data.MiddleWares;
using System.Net;

namespace Project_NTT_data.Filters
{
    public class CheckWhiteList : ActionFilterAttribute
    {
        private readonly IPList _ipList;
        public CheckWhiteList(IOptions<IPList> ipList)
        {
            _ipList = ipList.Value;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requestID = context.HttpContext.Connection.RemoteIpAddress; //This value format is IPAddress. Therefor we need to parse to IPAddress below
            var isWhiteList = _ipList.WhiteList.Where(ip=>IPAddress.Parse(ip).Equals(requestID)).Any();
            if (!isWhiteList)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
