using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.EntityFramework
{
    public class ProtectionArea
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lat")]
        public float Lat { get; set; }

        [Required]
        [Display(Name = "Long")]
        public float Long { get; set; }

        [Required]
        [Display(Name = "Radius")]
        public float Radius { get; set; }
    }
}