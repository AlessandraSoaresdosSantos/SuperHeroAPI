using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class DataConfiguration 
    {
        public DataConfiguration() { }

        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                HasKey(c => c.Id);
                Property(p => p.Username).IsRequired().HasMaxLength(500);
                Property(p => p.Password).IsRequired().HasMaxLength(500);
                HasRequired(p => p.Roles);
                

            }
        }
    }
}