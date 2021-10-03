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

        [HttpPost]
        public JsonResult AddPolicyCategory(string policyType, string policyCategoryId, string policyCategoryName, string description, bool isActive)
        {
            string message = string.Empty;
            try
            {
                if (repository.AddPolicyCategory(policyType, policyCategoryId, policyCategoryName, description, isActive))
                    message = "Category added succesfully";
                else
                    message = "Exception occured at DAL";
            }
            catch (Exception ex)
            {
                message = "Failed to add category.";
            }
            return Json(message);
        }

        [HttpPost]
        public JsonResult AddPolicyCategoryByModal(List<PolicyCategory> categories)
        {
            string message = string.Empty;
            try
            {
                if(repository.AddPolicyCategory(categories))
                    message = "Categories added succesfully";
                else
                    message = "Exception occured at DAL";
            }
            catch (Exception ex)
            {
                message = "Failed to add category.";
            }
            return Json(message);

            #region Postman JSON Raw Body 
            //[
            //    {
            //        "PolicyType": "Life Insurance",
            //        "PolicyCategoryId": "G1",
            //        "PolicyCategoryName": "Policy G1 Test",
            //        "Description": "Web API Postman Call 1",
            //        "IsActive": true
            //    },
            //    {
            //        "PolicyType": "Life Insurance",
            //        "PolicyCategoryId": "G2",
            //        "PolicyCategoryName": "Policy G2 Test",
            //        "Description": "Web API Postman Call 2",
            //        "IsActive": false
            //    }
            //]
            #endregion
        }
    }
}
