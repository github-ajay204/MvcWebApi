using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace WEBAPI.Models
{
    public class Health
    {

    }
    public class ResponseHead
    {
        public string Productid { get; set; }
    }
    public class ResponseBody
    {
        public string Productid { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}