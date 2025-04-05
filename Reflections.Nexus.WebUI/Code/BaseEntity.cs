using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Reflections.Nexus.WebUI.Code
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 110,TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(Order = 120)]
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [Required]
        [Column(Order = 130, TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Updated { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(Order = 140)]
        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }

        [ValidateNever]
        [Timestamp]
        [Column(Order = 150)]
        public byte[] RowVersion { get; set; }
    }
}
