using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Data
{
    public partial class ApplicationDbContext
    {
        partial void OnModelCreatingPartialDataSeed(ModelBuilder modelBuilder)
        {
            // password : P@ssw0rd
            modelBuilder.Entity<ApplicationUser>().HasData(
               new { Id = 1, UserName = "admin@system.com", FirstName = "Super", LastName = "Administrator", IsActive = true, NormalizedUserName = "ADMIN@SYSTEM.COM", Email = "admin@system.com", NormalizedEmail = "ADMIN@SYSTEM.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEMYgoo+Nk8o2o7R8s6Wa5TxKAEO1ytTcZhrL1YQHHWVY3DEeBqGd9PLAy91c1pVAig==", SecurityStamp = "VENUWRKWC2VPS67PRJBL26YK52EMR2L3", ConcurrencyStamp = "3fd1dc9a-82ab-4a62-be70-e80e201573af", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 }
            );

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR", Description = "System Administrator" },
                new ApplicationRole { Id = 2, Name = "Configuration", NormalizedName = "CONFIGURATION", Description = "Configration" },
                new ApplicationRole { Id = 3, Name = "Operations", NormalizedName = "OPERATIONS" , Description="Operation"},
                new ApplicationRole { Id = 4, Name = "Reports", NormalizedName = "REPORTS", Description="Reports" },
                new ApplicationRole { Id = 5, Name = "User", NormalizedName = "USER" , Description="User" }
            );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
              new IdentityUserRole<int> {UserId  = 1, RoleId = 1 }
           );

            modelBuilder.Entity<Gender>().HasData(
               new Gender { Id = 1, Value = "Male" },
               new Gender { Id = 2, Value = "Female" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Egypt" },
                new Country { Id = 2, Name = "Saudi Arabia" },
                new Country { Id = 3, Name = "Germany" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Cairo", CountryId = 1 },
                new City { Id = 2, Name = "Giza", CountryId = 1 },
                new City { Id = 3, Name = "Alexandria", CountryId = 1 },
                new City { Id = 4, Name = "Hurghada", CountryId = 1 }
            );

            modelBuilder.Entity<JobType>().HasData(
                new JobType { Id = 1, Value = "Part-Time" },
                new JobType { Id = 2, Value = "Full-Time" },
                new JobType { Id = 3, Value = "Flexible" }
            );

            modelBuilder.Entity<EmploymentType>().HasData(
                new JobType { Id = 1, Value = "Internship" },
                new JobType { Id = 2, Value = "Contract" },
                new JobType { Id = 3, Value = "Freelance" },
                new JobType { Id = 4, Value = "Temporary" }
            );

            modelBuilder.Entity<WorkingModel>().HasData(
                new JobType { Id = 1, Value = "On-Site" },
                new JobType { Id = 2, Value = "Online" },
                new JobType { Id = 3, Value = "Hybrid" }
            );

            modelBuilder.Entity<CompanyFileType>().HasData(
                new CompanyFileType { Id = 1, Value = "CompanyRegistration" },
                new CompanyFileType { Id = 2, Value = "TaxID" }
            );

            modelBuilder.Entity<CompanyType>().HasData(
                new CompanyType { Id = 1, Value = "Headquarter" },
                new CompanyType { Id = 2, Value = "Franchise" },
                new CompanyType { Id = 3, Value = "Regional Office" }
            );

            modelBuilder.Entity<EmployeeFileType>().HasData(
                new EmployeeFileType { Id = 1, Value = "National ID" },
                new EmployeeFileType { Id = 2, Value = "Birth Certificate" },
                new EmployeeFileType { Id = 3, Value = "Bachelor Certificate" },
                new EmployeeFileType { Id = 5, Value = "Passport" }
            );

            modelBuilder.Entity<HeadCountType>().HasData(
                new HeadCountType { Id = 1, Value = "Promote" },
                new HeadCountType { Id = 2, Value = "Hire" },
                new HeadCountType { Id = 3, Value = "Fire" },
                new HeadCountType { Id = 4, Value = "Transfer" },
                new HeadCountType { Id = 5, Value = "Retire" },
                new HeadCountType { Id = 6, Value = "Resign" }
            );

            modelBuilder.Entity<IdentificationType>().HasData(
                new EmployeeFileType { Id = 1, Value = "National ID" },
                new EmployeeFileType { Id = 2, Value = "Passport" }
            );

            modelBuilder.Entity<Industry>().HasData(
                new Industry { Id = 1, Value = "Technology" },
                new Industry { Id = 2, Value = "Retail" },
                new Industry { Id = 3, Value = "Healthcare" },
                new Industry { Id = 4, Value = "Education" },
                new Industry { Id = 5, Value = "Marketing" }
            );

            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = 1, Value = "Married" },
                new MaritalStatus { Id = 2, Value = "Single" },
                new MaritalStatus { Id = 3, Value = "Divorced" },
                new MaritalStatus { Id = 4, Value = "Widowed" }
            );

            modelBuilder.Entity<MilitaryStatus>().HasData(
                new MilitaryStatus { Id = 1, Value = "Exempted" },
                new MilitaryStatus { Id = 2, Value = "Reserved" },
                new MaritalStatus { Id = 3, Value = "Active Duty" },
                new MaritalStatus { Id = 4, Value = "Postponed" }
            );

            modelBuilder.Entity<PhoneNumberType>().HasData(
                new PhoneNumberType { Id = 1, Value = "Personal" },
                new PhoneNumberType { Id = 2, Value = "Home" }
            );

            modelBuilder.Entity<RequestStatus>().HasData(
                new RequestStatus { Id = 1, Value = "Accepted" },
                new RequestStatus { Id = 2, Value = "Rejected" },
                new RequestStatus { Id = 3, Value = "Pending" }
            );

            modelBuilder.Entity<SocialLinkType>().HasData(
                new SocialLinkType { Id = 1, Value = "Linkedin" },
                new SocialLinkType { Id = 2, Value = "DevOps" },
                new SocialLinkType { Id = 3, Value = "Facebook" },
                new SocialLinkType { Id = 4, Value = "Youtube" },
                new SocialLinkType { Id = 5, Value = "Instagram" },
                new SocialLinkType { Id = 6, Value = "TikTok" }
            );

        }
    }
}
