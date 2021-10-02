using Microsoft.VisualStudio.TestTools.UnitTesting;
using InSystDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSystDAL.Tests
{
    [TestClass()]
    public class InSystRepositoryTests
    {
        [TestMethod()]
        public void GetPoliciesTest()
        {
            int expectedPolicies = 2;
            int result = (new InSystRepository()).GetPolicies().Count;
            Assert.AreEqual(expectedPolicies, result);
        }

        [TestMethod()]
        public void GetBranchByIdTest()
        {
            string branchId = "1000";
            string expectedBranchName = "Infosys";
            string result = (new InSystRepository().GetBranchById(branchId)).BranchName;
            Assert.AreEqual(result, expectedBranchName);
        }
    }
}