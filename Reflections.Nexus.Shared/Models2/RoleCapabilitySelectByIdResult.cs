﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflections.Nexus.Shared.Models2
{
    public partial class RoleCapabilitySelectByIdResult
    {
        public int RoleCapabilityId { get; set; }
        public int RoleId { get; set; }
        public int CapabilityId { get; set; }
        public byte AccessFlag { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
