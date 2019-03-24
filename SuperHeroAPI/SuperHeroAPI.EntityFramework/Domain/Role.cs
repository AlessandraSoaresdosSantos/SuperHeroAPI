using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI.EntityFramework
{
    public class Role
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public int User_Id { get; set; }

        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }
    }
}