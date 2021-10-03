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

        [TestMethod()]
        public void AddPolicyCategoryTest()
        {

            Assert.IsTrue((new InSystRepository()).AddPolicyCategory("General Insurance", "L2", "Pension Scheme", "Supports NPS", false));
        }

        [TestMethod()]
        public void AddPolicyCategoryTest1()
        {
            Models.PolicyCategory category1 = new Models.PolicyCategory();
            category1.PolicyType = "General Insurance";
            category1.PolicyCategoryId = "L4";
            category1.PolicyCategoryName = "Test Policy 1";
            category1.Description = "Unit Testing 1";
            category1.IsActive = false;

            Models.PolicyCategory category2 = new Models.PolicyCategory();
            category2.PolicyType = "General Insurance";
            category2.PolicyCategoryId = "L5";
            category2.PolicyCategoryName = "Test Policy 2";
            category2.Description = "Unit Testing 2";
            category2.IsActive = false;

            List<Models.PolicyCategory> policyCategories = new List<Models.PolicyCategory>
            {
                category1,category2
            };
            Assert.IsTrue((new InSystRepository()).AddPolicyCategory(policyCategories));
        }

        [TestMethod()]
        public void UpdatePolicyCategoryTest()
        {
            Models.PolicyCategory policyCategory = new Models.PolicyCategory
            {
                PolicyCategoryId = "L4"
            };

            Assert.IsTrue((new InSystRepository()).UpdatePolicyCategory(policyCategory));
        }
    }
}