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
        public JsonResult AddPolicyCategoryByModel(List<PolicyCategory> categories)
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
            //child branch change
            #endregion
        }

        [HttpPut]
        public JsonResult UpdatePolicyCategoryByAPIModel(List<InSystServices.Models.PolicyCategory> policyCategories)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var policy in policyCategories)
                    {

                        PolicyCategory dalModelPolicy = new PolicyCategory
                        {
                            PolicyType = policy.PolicyType,
                            PolicyCategoryId = policy.PolicyCategoryId,
                            PolicyCategoryName = policy.PolicyCategoryName,
                            Description = policy.Description,
                            IsActive = policy.IsActive
                        };
                        if (repository.UpdatePolicyCategory(dalModelPolicy))
                            continue;
                        else
                        {
                            message += $"Problem with {policy.PolicyCategoryId}" + Environment.NewLine;
                        }

                    }
                }   
                message += "Updated records.";
            }
            catch (Exception ex)
            {
                message = "Failed to add category.";
            }
            return Json(message);
        }

        /// <summary>
        /// recommended not to add delete operations in service
        /// 1. will trigger delete operation on same item multiple time
        /// 2. could delete data which was required
        /// </summary>
        /// <param name="categoryId">Policy category id to uniquely identify which category to be removed</param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult RemovePolicyCategory(string categoryId)
        {
            string message = string.Empty;
            try
            {
                if (repository.DeletePolicyCategory(categoryId))
                    message = $"Removed category {categoryId}.";
                else
                    message = "Some error occurred";
            }
            catch (Exception)
            {
                message = "Exception at Service. Try again.";
            }
            return Json(message);
        }
    }
}
