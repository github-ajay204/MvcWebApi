using DataAccessClassDAL;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Serialization;
using WEBAPI.DataAccess;
using WEBAPI.Models;


namespace WEBAPI.Controllers.Api
{
    public class ProductApiController : ApiController
    {
        #region variable declare
        Product product = new Product();
        DataAccessClass obj2 = new DataAccessClass();
        Hashtable htparam = new Hashtable();
        DataSet dsResult = new DataSet();
        #endregion

        #region Fetch Product list from database
        public IEnumerable<Product> Get()
        {
            using (var context = new Context())
            {
                return context.products.ToList();
            }
        }
        #endregion

        #region GET based on unique id

        ////https://localhost:44365/api/ProductApi?id=1
        [HttpGet]
        [Route("api/ProductApi")]
        public DataSet Get([FromUri] int id)
        {
            //htparam.Add("@ProductID", id);
            dsResult = obj2.GetDataSetForPrc("GetAllProducts");
            return dsResult;
        }
        #endregion

        #region Insert into database
        public void Post([FromBody] Product product)
        {
            htparam.Add("@Description", product.Description.ToString());
            htparam.Add("@Name", product.Name.ToString());
            htparam.Add("@ProductID", product.ProductID);
            htparam.Add("@Price", product.Price);
            dsResult = obj2.GetDataSetForPrc("InsertProduct", htparam);
        }
        #endregion

        #region PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}