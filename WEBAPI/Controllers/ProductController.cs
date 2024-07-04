using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class ProductController : Controller
    {
        string ApiBaseurl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        ProductLogic objPro = new ProductLogic();
        
        // GET: Product/Index
        //public async Task<ActionResult> Index()
        //{
        //    ProductApiResponse apiResponse = await ApiIndex();
        //    return View(apiResponse);
        //}
        public async Task<ActionResult> Index()
        {
            //Product product = new Product();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseurl);
                //HttpResponseMessage response = await client.GetAsync("ProductApi?id=2");
                HttpResponseMessage response = await client.GetAsync("api/ProductApi");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<Product>(data);
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(data);

                    if (responseObject.Table != null && responseObject.Table.Count > 0)
                    {
                        var productData = responseObject.Table[0];
                        var product = new Product
                        {
                            ProductID = productData.ProductID,
                            Name = productData.Name,
                            Price = productData.Price,
                            Description = productData.Description
                        };

                        return View(product);
                    }
                    return Content("No product data found");
                }
                else
                {
                    
                }
                {
                    return null;
                }
            }
        }


        public void Home()
        {
            objPro.FetchProduct();
        }
    }
}