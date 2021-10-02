using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace InSystDAL.Models
{
    public partial class BranchDetail
    {
        public BranchDetail()
        {
            ChildCareerPolicies = new HashSet<ChildCareerPolicy>();
            PolicyStatuses = new HashSet<PolicyStatus>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? BranchManagerId { get; set; }

        public virtual Credential BranchManager { get; set; }

        [JsonIgnore]
        public virtual ICollection<ChildCareerPolicy> ChildCareerPolicies { get; set; }

        [JsonIgnore]
        public virtual ICollection<PolicyStatus> PolicyStatuses { get; set; }
    }
}
