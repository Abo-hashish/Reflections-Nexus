using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Models;
using Reflections.Nexus.WebUI.ViewModels;

namespace Reflections.Nexus.WebUI.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }


        //public DbSet<SalaryStatistics> SalaryStatistics { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<CompanyFile> CompanyFiles { get; set; }

        public virtual DbSet<CompanyFileType> CompanyFileTypes { get; set; }

        public virtual DbSet<CompanyTelephoneNumber> CompanyEmployeeTelephoneNumber { get; set; }

        public virtual DbSet<CompanyType> CompanyTypes { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeFile> EmployeeFiles { get; set; }

        public virtual DbSet<EmployeeFileType> EmployeeFileTypes { get; set; }

        public virtual DbSet<EmployeeRequest> EmployeeRequests { get; set; }

        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }

        public virtual DbSet<HeadCountItem> HeadCountItems { get; set; }

        public virtual DbSet<HeadCountType> HeadCountTypes { get; set; }

        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

        public virtual DbSet<Industry> Industries { get; set; }

        public virtual DbSet<JobTitle> JobTitles { get; set; }

        public virtual DbSet<JobType> JobTypes { get; set; }

        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

        public virtual DbSet<MilitaryStatus> MilitaryStatuses { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

        public virtual DbSet<SocialLink> SocialLinks { get; set; }

        public virtual DbSet<SocialLinkType> SocialLinkTypes { get; set; }

        public virtual DbSet<EmployeeTelephoneNumber> EmployeeTelephoneNumber { get; set; }

        public virtual DbSet<WorkingModel> WorkingModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__City__3214EC276A5C1E8A");

                entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Company__3214EC27621FACBE");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd()
                    .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasOne(d => d.City).WithMany(p => p.Companies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_City");

                entity.HasOne(d => d.CompanyType).WithMany(p => p.Companies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_CompanyType1");

                entity.HasOne(d => d.Industry).WithMany(p => p.Companies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Industry");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("FK_Company_Company");
            });

            modelBuilder.Entity<CompanyFile>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__CompanyF__3214EC074A53B7CC");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())")
                   .ValueGeneratedOnAdd()
                   .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Company).WithMany(p => p.CompanyFiles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyFiles_Company");

                entity.HasOne(d => d.FileType).WithMany(p => p.CompanyFiles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyFiles_CompanyFileType");
            });

            modelBuilder.Entity<CompanyTelephoneNumber>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Company).WithMany(p => p.CompanyTelephoneNumbers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyTelephoneNumber_Company");

                entity.HasOne(d => d.Type).WithMany(p => p.CompanyTelephoneNumbers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyTelephoneNumber_PhoneNumberType");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__CompanyT__3214EC27FDF325DB");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0735C0FED9");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();


                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())")
                   .ValueGeneratedOnAdd()
                   .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasOne(d => d.Company).WithMany(p => p.Departments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Company");

                entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07F195CECB");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.City).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_City");

                entity.HasOne(d => d.EmploymentType).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmploymentType");

                entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Gender");

                entity.HasOne(d => d.IdentificationType).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Identification");

                entity.HasOne(d => d.JobTitle).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_JobTitle");

                entity.HasOne(d => d.JobType).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_JobType");

                entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK_Employee_Employee");

                entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_MatrialStatus");

                entity.HasOne(d => d.MilitaryStatus).WithMany(p => p.Employees).HasConstraintName("FK_Employee_MilitaryStatus");

                entity.HasOne(d => d.Nationality).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Nationality");

                entity.HasOne(d => d.WorkingModel).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_WorkingModel");
            });

            modelBuilder.Entity<EmployeeFile>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC27C74AC7F2");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())")
                   .ValueGeneratedOnAdd()
                   .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                
                entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeFiles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeFiles_Employee");

                entity.HasOne(d => d.FileType).WithMany(p => p.EmployeeFiles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeFiles_EmployeeFileType");
            });

            modelBuilder.Entity<EmployeeRequest>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeRequests)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRequest_Employee");

                entity.HasOne(d => d.Notification).WithMany(p => p.EmployeeRequests)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRequest_Notification");

                entity.HasOne(d => d.Status).WithMany(p => p.EmployeeRequests)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRequest_RequestStatus");
            });

            modelBuilder.Entity<EmployeeTelephoneNumber>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd()
                    .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
 
                entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())")
                    .ValueGeneratedOnAdd().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTelephoneNumbers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhoneNumber_EmployeeId");

                entity.HasOne(d => d.Type).WithMany(p => p.EmployeeTelephoneNumbers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTelephoneNumber_PhoneNumberType");
            });

            modelBuilder.Entity<EmploymentType>(entity =>
            {
            });

            modelBuilder.Entity<Gender>(entity =>
            {
            });

           modelBuilder.Entity<HeadCountItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__HeadCoun__3214EC07F31532E4");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Employee).WithMany(p => p.HeadCountItemEmployees).HasConstraintName("FK_HeadCountItem_Employee");

                entity.HasOne(d => d.FromDepartmentJobTitle).WithMany(p => p.HeadCountItemFromDepartmentJobTitles).HasConstraintName("FK_HeadCountItem_FromDepartmentJobTitle");

                entity.HasOne(d => d.FromWorkingModel).WithMany(p => p.HeadCountItemFromWorkingModels).HasConstraintName("FK_HeadCountItem_FromWorkingModel");

                entity.HasOne(d => d.Gender).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_Gender");

                entity.HasOne(d => d.HeadCountType).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_HeadCountType");

                entity.HasOne(d => d.IdentificationType).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_IdentificationType");

                entity.HasOne(d => d.EmploymentType).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_EmploymentType");

                entity.HasOne(d => d.JobType).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_JobType");

                entity.HasOne(d => d.Manager).WithMany(p => p.HeadCountItemManagers).HasConstraintName("FK_HeadCountItem_Manager");

                entity.HasOne(d => d.MaritalStatus).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_MaritalStatus");

                entity.HasOne(d => d.MilitaryStatus).WithMany(p => p.HeadCountItems).HasConstraintName("FK_HeadCountItem_MilitaryStatus");

                entity.HasOne(d => d.Nationality).WithMany(p => p.HeadCountItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadCountItem_Nationality");

                entity.HasOne(d => d.ToDepartmentJobTitle).WithMany(p => p.HeadCountItemToDepartmentJobTitles).HasConstraintName("FK_HeadCountItem_ToDepartment");

                entity.HasOne(d => d.ToWorkingModel).WithMany(p => p.HeadCountItemToWorkingModels).HasConstraintName("FK_HeadCountItem_ToWorkingModel");
            });

            modelBuilder.Entity<HeadCountType>(entity =>
            {
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Identifi__3214EC077151D407");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Industry__3214EC27D6683BAD");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {

                entity.HasOne(d => d.Department).WithMany(p => p.JobTitles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobTitle_Department");
            });

            modelBuilder.Entity<JobType>(entity =>
            {
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__MatrialS__3214EC0707AF5D45");
            });

            modelBuilder.Entity<MilitaryStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Military__3214EC2797640630");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Activities");

            });

            modelBuilder.Entity<PhoneNumberType>(entity =>
            {
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
            });


            modelBuilder.Entity<SocialLink>(entity =>
            {

                entity.HasOne(d => d.Company).WithMany(p => p.SocialLinks)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialLinks_Company");

                entity.HasOne(d => d.SocialType).WithMany(p => p.SocialLinks)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialLinks_SocialLinkType");
            });

            modelBuilder.Entity<SocialLinkType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__SocialLi__3214EC079574A20A");
            });


            modelBuilder.Entity<WorkingModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WorkingM__3214EC275B84BC05");
            });


            OnModelCreatingPartialGlobalFilters(modelBuilder);
            OnModelCreatingPartialDataSeed(modelBuilder);
            OnModelCreatingPartial(modelBuilder);

        }


        partial void OnModelCreatingPartialGlobalFilters(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartialDataSeed(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
