using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace UrlHelperWebSite.Controllers
{
    [Route("api/[controller]")]
    public class RouteValueUsageController
    {
        private readonly IUrlHelper _urlHelper;

        public RouteValueUsageController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        [HttpGet("urlHelper/helper")]
        public string UrlHelper()
        {
            return _urlHelper.Action("Get", "RouteValueUsage", new { id = 1234 });
        }

        [HttpGet("urlHelper/base")]
        public string UrlHelperBase()
        {
            return _urlHelper.Action("Get", "RouteValueUsage");
        }

        [HttpGet("Get/{id}")]
        public string Get(int id)
        {
            return "routevalue: " + id;
        }

        [HttpGet("Get")]
        public string Get()
        {
            return "BASEGET";
        }
    }
}
