#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using global::Reflections.Nexus.WebUI.Code;
using global::Reflections.Nexus.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Code;

namespace Reflections.Nexus.WebUI.ViewModels
{
    public partial class EmployeeManager 
    {

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public int CityId { get; set; }

        public string Address { get; set; }

        public int JobTitleId { get; set; }

        public int? ManagerId { get; set; }

        public int GenderId { get; set; }

        public int? MilitaryStatusId { get; set; }

        public DateTime BirthDate { get; set; }

        public int JobTypeId { get; set; }

        public DateTime JoiningDate { get; set; }

        public int EmploymentTypeId { get; set; }

        public int WorkingModelId { get; set; }

        public int IdentificationTypeId { get; set; }

        public string Identification { get; set; }

        public DateTime? ExitDate { get; set; }

        public string Email { get; set; }

        public int Salary { get; set; }

        public int NationalityId { get; set; }

        public string MedicalInsurance { get; set; }

        public int MaritalStatusId { get; set; }

    }
}
