﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflections.Nexus.Shared.Models2
{
    public partial class PaidTimeOffRequestSelectAllResult
    {
        public int PaidTimeOffRequestId { get; set; }
        public int UserAccountId { get; set; }
        public DateTime RequestDate { get; set; }
        public int PaidTimeOffDayTypeId { get; set; }
        public int PaidTimeOffRequestTypeId { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
