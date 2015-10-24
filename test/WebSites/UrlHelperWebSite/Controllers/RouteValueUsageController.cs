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

        [HttpGet("urlHelper/helper/{which}")]
        public string UrlHelper(string which)
        {
            return _urlHelper.Action(which, "RouteValueUsage", new { id = 1234 });
        }

        [HttpGet("urlHelper/base/{which}")]
        public string UrlHelperBase(string which)
        {
            return _urlHelper.Action(which, "RouteValueUsage");
        }

        [HttpGet("default/{id=0}")]
        public string Default(int id)
        {
            return "routevalue: " + id;
        }

        [HttpGet("default")]
        public string Default()
        {
            return "BASEGET";
        }

        [HttpGet("base/{id}")]
        public string Base(int id)
        {
            return "routevalue: " + id;
        }

        [HttpGet("base")]
        public string Base()
        {
            return "BASEGET";
        }
    }
}
