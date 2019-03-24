using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI.EntityFramework
{
    public class AuditEvent
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Entity")]
        [MaxLength(500)]
        public string Entity { get; set; }

        [Display(Name = "EntityId")]
        public int EntityId { get; set; }

        [Display(Name = "Datetime")]
        public DateTime Datetime { get; set; }

        [Required]
        [Display(Name = "Action")]
        [MaxLength(200)]
        public string Action { get; set; }

        public int Username_Id { get; set; }

        [ForeignKey(nameof(Username_Id))]
        public virtual User Username { get; set; }

    }
}