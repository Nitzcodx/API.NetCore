using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InSystDAL.Models;

namespace InSystDAL
{
    public class InSystRepository
    {
        public List<Policy> GetPolicies()
        {
            List<Policy> policies = new List<Policy>();
            try
            {
                using(var context = new InSystContext())
                {
                    policies = (from policy in context.Policies
                                select policy).ToList();
                }
            }
            catch (Exception ex)
            {
                policies = null;
            }
            return policies;
        }

        public BranchDetail GetBranchById(string branchId)
        {
            BranchDetail branchDetail;
            try
            {
                using(var context = new InSystContext())
                {
                    branchDetail = (from branch in context.BranchDetails
                                    where branch.BranchId.Equals(Convert.ToInt32(branchId))
                                    select branch).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                branchDetail = null;
            }
            return branchDetail;
        }

        public bool AddPolicyCategory(string policyType,string policyCategoryId, string policyCategoryName, string description, bool isActive)
        {
            try
            {
                PolicyCategory category = new PolicyCategory();
                category.PolicyType = policyType;
                category.PolicyCategoryId = policyCategoryId;
                category.PolicyCategoryName = policyCategoryName;
                category.Description = description;
                category.IsActive = isActive;
                using(var context = new InSystContext()){
                    context.PolicyCategories.Add(category);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddPolicyCategory(List<PolicyCategory> categories)
        {
            try
            {
                using(var context = new InSystContext())
                {
                    context.PolicyCategories.AddRange(categories);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePolicyCategory(PolicyCategory policyCategory)
        {
            try
            {
                using(var context = new InSystContext())
                {
                    PolicyCategory category = (from categories in context.PolicyCategories
                                               where categories.PolicyCategoryId.Equals(policyCategory.PolicyCategoryId)
                                               select categories).FirstOrDefault();
                    category.Description = "Updated from PostmanCall";
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
