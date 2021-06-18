using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Simplifier.Models;

namespace Simplifier.Controllers
{
    public class RegistrationController : ApiController
    {
        // GET: api/Registration
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Registration
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        public IHttpActionResult EmpRegestration([FromBody]EmpReg Detail)
        {
            using (Simplifier3XEntities edm = new Simplifier3XEntities())
            {
                try
                {
                    string empId = GenerateRandomNo().ToString();
                    string employeid = "e" + empId;
                    EmpReg objects = new EmpReg();
                    objects.ID = Detail.ID;
                    objects.FirstName = Detail.FirstName;
                    objects.LastName = Detail.LastName;
                    objects.ContactNumber = Detail.ContactNumber;
                    objects.EmailId = Detail.EmailId;
                    objects.EmployeeId = employeid;
                    objects.IsDeleted = false;


                    edm.EmpRegs.Add(objects);
                    edm.SaveChanges();


                    edm.Dispose();
                    return Ok();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public int GenerateRandomNo()
        {
            int min = 1;
            int max = 100;
            Random rdm = new Random();
            return rdm.Next(min, max);

        }
        [HttpGet]
        public IHttpActionResult EditEmployee(int ID)
        {
            try
            {
                Simplifier3XEntities edm = new Simplifier3XEntities();
                edm.Configuration.ProxyCreationEnabled = false;
                var details = edm.EditEmpReg(ID).ToList<EditEmpReg_Result>();
                edm.Dispose();
                return Ok(details);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public IHttpActionResult UpdateEmployee(int ID, EmpReg vari)
        {
            try
            {
                Simplifier3XEntities edm = new Simplifier3XEntities();
                edm.Configuration.ProxyCreationEnabled = false;
                var details = edm.UpdateRegEmp(ID, vari.FirstName, vari.LastName, vari.ContactNumber, vari.EmailId);
                return Ok(details);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int ID)
        {
            try
            {
                Simplifier3XEntities edm = new Simplifier3XEntities();
                edm.Configuration.ProxyCreationEnabled = false;
                var details = edm.DeleteEmgReg(ID);
                edm.Dispose();
                return Ok(details);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public IHttpActionResult ManageEmployee()
        {
            try
            {
                Simplifier3XEntities edm = new Simplifier3XEntities();
                edm.Configuration.ProxyCreationEnabled = false;
                var details = edm.GetEmployeeDetail().ToList<GetEmployeeDetail_Result>();
                edm.Dispose();
                return Ok(details);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
