using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperPower
    {
        public  int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(500)]
        public  string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(500)]
        public  string Description { get; set; }
    }
}