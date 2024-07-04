using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBAPI.DataAccess;

namespace WEBAPI.Models
{
    public class ProductLogic
    {
        private Context db = new Context();

        public void FetchProduct()
        {
            var products = from p in db.products
                           select p;
        }
    }
}