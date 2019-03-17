namespace SuperHeroAPI.EntityFramework
{
    /// <summary>
    /// Class SuperPower
    /// </summary>
    public class SuperPower
    {
        /// <summary>
        /// Retrieves or defines the SuperPower  - Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Retrieves or defines the SuperPower - Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Retrieves or defines the SuperPower - Description
        /// </summary>
        public virtual string Description { get; set; }
    }
}