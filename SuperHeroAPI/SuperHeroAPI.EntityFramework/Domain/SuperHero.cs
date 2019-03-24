using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperHero
    {
        public SuperHero()
        {
            this.SuperPowers = new List<SuperPower>();
        }

        public  int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(500)]
        public  string Name { get; set; }

        [Display(Name = "Alias")]
        [MaxLength(500)]
        public  string Alias { get; set; }

        public int ProtectionArea_Id { get; set; }

        [ForeignKey(nameof(ProtectionArea_Id))]
        public  virtual ProtectionArea ProtectionArea { get; set; }

        public int SuperPower_Id { get; set; }

        [ForeignKey(nameof(SuperPower_Id))]
        public virtual SuperPower SuperPower { get; set; }
        public  virtual List<SuperPower> SuperPowers { get; set; }
    }
}