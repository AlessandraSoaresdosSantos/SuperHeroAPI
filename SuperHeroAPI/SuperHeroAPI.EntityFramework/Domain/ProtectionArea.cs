namespace SuperHeroAPI.EntityFramework
{
    /// <summary>
    /// Class ProtectionArea
    /// </summary>
    public class ProtectionArea
    {
        /// <summary>
        /// Retrieves or defines the ProtectionArea  - Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Retrieves or defines the ProtectionArea - Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Retrieves or defines the ProtectionArea - Lat
        /// </summary>
        public virtual float Lat { get; set; }

        /// <summary>
        /// Retrieves or defines the ProtectionArea - Long
        /// </summary>
        public virtual float Long { get; set; }

        /// <summary>
        /// Retrieves or defines the ProtectionArea - Radius
        /// </summary>
        public virtual float Radius { get; set; }
    }
}