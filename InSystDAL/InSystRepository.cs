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
    }
}
