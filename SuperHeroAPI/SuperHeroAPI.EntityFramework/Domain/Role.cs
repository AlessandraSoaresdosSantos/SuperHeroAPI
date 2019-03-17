namespace SuperHeroAPI.EntityFramework
{
    /// <summary>
    /// Class Role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Retrieves or defines the Role  - Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Retrieves or defines the Role - Name
        /// </summary>
        public virtual string Name { get; set; }
    }
}