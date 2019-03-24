using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public abstract class BaseServices
    {
        protected BaseServices()
        {
        
        }
        protected UnityOfWork UnityOfWork { get; set; }
        protected QuerySet QuerySet;
        public QuerySet GetQuerySet()
        {
            return this.QuerySet;
        }
    }
}