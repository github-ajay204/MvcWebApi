using System;
using System.Collections;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;
using WEBAPI.Models;
using DataAccessClassDAL;

namespace WEBAPI.Controllers.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EmployeeApiController : ApiController
    {
        // Variable declarations
        Product product = new Product();
        DataAccessClass obj2 = new DataAccessClass();
        Hashtable htparam = new Hashtable();
        DataSet dsResult = new DataSet();

        // Create Employee
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            try
            {
                htparam.Add("@Name", employee.Name);
                htparam.Add("@Designation", employee.Designation);
                htparam.Add("@Skills", employee.Skills);
                dsResult = obj2.GetDataSetForPrc("CreateEmployee", htparam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Get All Employees
        [HttpGet]
        [Route("api/GetAllEmployee")]
        public DataSet GetAllEmployee()
        {
            try
            {
                dsResult = obj2.GetDataSetForPrc("GetEmployee");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dsResult;
        }
    }
}
