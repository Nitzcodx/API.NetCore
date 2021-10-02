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
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public JsonResult GetBranchById(string branchId)
        {
            BranchDetail branch;
            try
            {
                branch = repository.GetBranchById(branchId);
            }
            catch (Exception)
            {

                branch = null;
            }
            return Json(branch);
        }
    }
}
