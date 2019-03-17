using System;

namespace SuperHeroAPI.EntityFramework
{
    /// <summary>
    /// Class AuditEvent
    /// </summary>
    public class AuditEvent
    {
        /// <summary>
        /// Retrieves or defines the AuditEvent  - Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Retrieves or defines the AuditEvent - Entity
        /// </summary>
        public virtual string Entity { get; set; }

        /// <summary>
        /// Retrieves or defines the AuditEvent  - EntityId 
        /// </summary>
        public virtual int EntityId { get; set; }

        /// <summary>
        /// Retrieves or defines the AuditEvent  - Datetime 
        /// </summary>
        public virtual DateTime Datetime { get; set; }

        /// <summary>
        /// Retrieves or defines the AuditEvent  - Username 
        /// </summary>
        public virtual User Username { get; set; }

        /// <summary>
        /// Retrieves or defines the AuditEvent - Action
        /// </summary>
        public virtual string Action { get; set; }
    }
}