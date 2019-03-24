using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.EntityFramework
{
    public class User
    {
        public User() {
            this.Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}