﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflections.Nexus.Shared.Models2
{
    public partial class ReportMyPaidTimeOffRequestsResult
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime RequestDate { get; set; }
        public string PaidTimeOffDayTypeName { get; set; }
        public string PaidTimeOffRequestTypeName { get; set; }
        public string CurrentState { get; set; }
        public string CurrentOwnerLastName { get; set; }
        public string CurrentOwnerFirstName { get; set; }
    }
}
