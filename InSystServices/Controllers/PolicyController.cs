using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InSystDAL;
using InSystDAL.Models;

namespace InSystServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : Controller
    {
        InSystRepository repository;
        public PolicyController()
        {
            repository = new InSystRepository();
        }

        [HttpGet]
        public JsonResult GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();
            try
            {
                policies = repository.GetPolicies();
            }
            catch (Exception)
            {

                policies = null;
            }
            return Json(policies);
        }
    }
}
