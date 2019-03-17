using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    /// <summary>
    /// Class User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Retrieves or defines the User  - Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Retrieves or defines the User - Username
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// Retrieves or defines the User - Password
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Retrieves or defines the User - Has many Role
        /// </summary>
        public virtual ICollection<Role> Role { get; set; }
    }
}