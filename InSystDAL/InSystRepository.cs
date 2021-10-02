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
    }
}
