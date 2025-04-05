using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reflections.Nexus.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyFileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompanyT__3214EC27FDF325DB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadCountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadCountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Identifi__3214EC077151D407", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Industry__3214EC27D6683BAD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MatrialS__3214EC0707AF5D45", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Military__3214EC2797640630", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "ntext", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SocialLi__3214EC079574A20A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WorkingM__3214EC275B84BC05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City__3214EC276A5C1E8A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstablishDate = table.Column<DateTime>(type: "date", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommercialRegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TaxRegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    LogoURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Company__3214EC27621FACBE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Company",
                        column: x => x.ParentId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_CompanyType1",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Industry",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompanyF__3214EC074A53B7CC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyFiles_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyFiles_CompanyFileType",
                        column: x => x.FileTypeId,
                        principalTable: "CompanyFileType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyTelephoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTelephoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTelephoneNumber_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyTelephoneNumber_PhoneNumberType",
                        column: x => x.TypeId,
                        principalTable: "PhoneNumberType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SocialTypeId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialLinks_SocialLinkType",
                        column: x => x.SocialTypeId,
                        principalTable: "SocialLinkType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__3214EC0735C0FED9", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTitle_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    MilitaryStatusId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: false),
                    WorkingModelId = table.Column<int>(type: "int", nullable: false),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    MedicalInsurance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC07F195CECB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Employee",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_EmploymentType",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Gender",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Identification",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_JobTitle",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_JobType",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_MatrialStatus",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_MilitaryStatus",
                        column: x => x.MilitaryStatusId,
                        principalTable: "MilitaryStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Nationality",
                        column: x => x.NationalityId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_WorkingModel",
                        column: x => x.WorkingModelId,
                        principalTable: "WorkingModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC27C74AC7F2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_EmployeeFileType",
                        column: x => x.FileTypeId,
                        principalTable: "EmployeeFileType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "ntext", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRequest_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeRequest_Notification",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeRequest_RequestStatus",
                        column: x => x.StatusId,
                        principalTable: "RequestStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTelephoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTelephoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTelephoneNumber_PhoneNumberType",
                        column: x => x.TypeId,
                        principalTable: "PhoneNumberType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneNumber_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeadCountItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    HeadCountTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    MilitaryStatusId = table.Column<int>(type: "int", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: false),
                    WorkingModelId = table.Column<int>(type: "int", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    MedicalInsurance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ITCheckDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ItcheckBy = table.Column<int>(type: "int", nullable: true),
                    HRCheckDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HRCheckBy = table.Column<int>(type: "int", nullable: true),
                    FromDepartmentJobTitleId = table.Column<int>(type: "int", nullable: true),
                    ToDepartmentJobTitleId = table.Column<int>(type: "int", nullable: true),
                    FromWorkingModelId = table.Column<int>(type: "int", nullable: true),
                    ToWorkingModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HeadCoun__3214EC07F31532E4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadCountItem_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_FromDepartment",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_FromWorkingModel",
                        column: x => x.WorkingModelId,
                        principalTable: "WorkingModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_Gender",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_HeadCountItem1",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_HeadCountItem",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_HeadCountType",
                        column: x => x.HeadCountTypeId,
                        principalTable: "HeadCountType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_JobType",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_Manager",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_MaritalStatus",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_MilitaryStatus",
                        column: x => x.MilitaryStatusId,
                        principalTable: "MilitaryStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeadCountItem_Nationality",
                        column: x => x.WorkingModelId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CompanyFileType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "CompanyRegistration" },
                    { 2, "TaxID" }
                });

            migrationBuilder.InsertData(
                table: "CompanyType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Headquarter" },
                    { 2, "Franchise" },
                    { 3, "Regional Office" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Egypt" },
                    { 2, "Saudi Arabia" },
                    { 3, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeFileType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "National ID" },
                    { 2, "Birth Certificate" },
                    { 3, "Bachelor Certificate" },
                    { 5, "Passport" }
                });

            migrationBuilder.InsertData(
                table: "EmploymentType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Internship" },
                    { 2, "Contract" },
                    { 3, "Freelance" },
                    { 4, "Temporary" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "HeadCountType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Promote" },
                    { 2, "Hire" },
                    { 3, "Fire" },
                    { 4, "Transfer" },
                    { 5, "Retire" },
                    { 6, "Resign" }
                });

            migrationBuilder.InsertData(
                table: "IdentificationType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "National ID" },
                    { 2, "Passport" }
                });

            migrationBuilder.InsertData(
                table: "Industry",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Retail" },
                    { 3, "Healthcare" },
                    { 4, "Education" },
                    { 5, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "JobType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Part-Time" },
                    { 2, "Full-Time" },
                    { 3, "Flexible" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatus",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Married" },
                    { 2, "Single" },
                    { 3, "Divorced" },
                    { 4, "Widowed" }
                });

            migrationBuilder.InsertData(
                table: "MilitaryStatus",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Exempted" },
                    { 2, "Reserved" },
                    { 3, "Active Duty" },
                    { 4, "Postponed" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumberType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "Home" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatus",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Accepted" },
                    { 2, "Rejected" },
                    { 3, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "System Administrator", "Administrator", "ADMINISTRATOR" },
                    { 2, null, "Configration", "Configuration", "CONFIGURATION" },
                    { 3, null, "Operation", "Operations", "OPERATIONS" },
                    { 4, null, "Reports", "Reports", "REPORTS" },
                    { 5, null, "User", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "SocialLinkType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Linkedin" },
                    { 2, "DevOps" },
                    { 3, "Facebook" },
                    { 4, "Youtube" },
                    { 5, "Instagram" },
                    { 6, "TikTok" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "3fd1dc9a-82ab-4a62-be70-e80e201573af", "admin@system.com", true, "Super", true, "Administrator", true, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEMYgoo+Nk8o2o7R8s6Wa5TxKAEO1ytTcZhrL1YQHHWVY3DEeBqGd9PLAy91c1pVAig==", null, false, "VENUWRKWC2VPS67PRJBL26YK52EMR2L3", false, "admin@system.com" });

            migrationBuilder.InsertData(
                table: "WorkingModel",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "On-Site" },
                    { 2, "Online" },
                    { 3, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, false, "Cairo" },
                    { 2, 1, false, "Giza" },
                    { 3, 1, false, "Alexandria" },
                    { 4, 1, false, "Hurghada" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CityId",
                table: "Company",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyType",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                table: "Company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_IndustryId",
                table: "Company",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ParentId",
                table: "Company",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFiles_CompanyId",
                table: "CompanyFiles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFiles_FileTypeId",
                table: "CompanyFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTelephoneNumber_CompanyId",
                table: "CompanyTelephoneNumber",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTelephoneNumber_TypeId",
                table: "CompanyTelephoneNumber",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_CompanyId",
                table: "Department",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerId",
                table: "Department",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CityId",
                table: "Employee",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploymentTypeId",
                table: "Employee",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderId",
                table: "Employee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdentificationTypeId",
                table: "Employee",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTitleId",
                table: "Employee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTypeId",
                table: "Employee",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MaritalStatusId",
                table: "Employee",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MilitaryStatusId",
                table: "Employee",
                column: "MilitaryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_NationalityId",
                table: "Employee",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkingModelId",
                table: "Employee",
                column: "WorkingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_EmployeeId",
                table: "EmployeeFiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_FileTypeId",
                table: "EmployeeFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequest_EmployeeId",
                table: "EmployeeRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequest_NotificationId",
                table: "EmployeeRequest",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequest_StatusId",
                table: "EmployeeRequest",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTelephoneNumber_EmployeeId",
                table: "EmployeeTelephoneNumber",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTelephoneNumber_TypeId",
                table: "EmployeeTelephoneNumber",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_DepartmentId",
                table: "HeadCountItem",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_EmployeeId",
                table: "HeadCountItem",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_GenderId",
                table: "HeadCountItem",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_HeadCountTypeId",
                table: "HeadCountItem",
                column: "HeadCountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_IdentificationTypeId",
                table: "HeadCountItem",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_JobTitleId",
                table: "HeadCountItem",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_JobTypeId",
                table: "HeadCountItem",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_ManagerId",
                table: "HeadCountItem",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_MaritalStatusId",
                table: "HeadCountItem",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_MilitaryStatusId",
                table: "HeadCountItem",
                column: "MilitaryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCountItem_WorkingModelId",
                table: "HeadCountItem",
                column: "WorkingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitle_DepartmentId",
                table: "JobTitle",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_CompanyId",
                table: "SocialLinks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_SocialTypeId",
                table: "SocialLinks",
                column: "SocialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee",
                table: "Department",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Nationality",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_City",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_City",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_CompanyType1",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Industry",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee",
                table: "Department");

            migrationBuilder.DropTable(
                name: "CompanyFiles");

            migrationBuilder.DropTable(
                name: "CompanyTelephoneNumber");

            migrationBuilder.DropTable(
                name: "EmployeeFiles");

            migrationBuilder.DropTable(
                name: "EmployeeRequest");

            migrationBuilder.DropTable(
                name: "EmployeeTelephoneNumber");

            migrationBuilder.DropTable(
                name: "HeadCountItem");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "CompanyFileType");

            migrationBuilder.DropTable(
                name: "EmployeeFileType");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropTable(
                name: "PhoneNumberType");

            migrationBuilder.DropTable(
                name: "HeadCountType");

            migrationBuilder.DropTable(
                name: "SocialLinkType");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmploymentType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "MilitaryStatus");

            migrationBuilder.DropTable(
                name: "WorkingModel");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
