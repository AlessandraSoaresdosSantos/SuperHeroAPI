using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    /// <summary>
    /// Class SuperHero
    /// </summary>
    public class SuperHero
    {
        /// <summary>
        /// Retrieves or defines the SuperHero  - Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Retrieves or defines the SuperHero - Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Retrieves or defines the SuperHero - Alias
        /// </summary>
        public virtual string Alias { get; set; }

        /// <summary>
        /// Retrieves or defines the SuperHero - Has a ProtectionArea
        /// </summary>
        public virtual ProtectionArea ProtectionArea { get; set; }

        /// <summary>
        /// Retrieves or defines the SuperHero - Has many SuperPower
        /// </summary>
        public virtual ICollection<SuperPower> SuperPower { get; set; }
    }
}