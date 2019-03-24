using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework 
{
    public class QuerySet
    {
        public List<string> IncludedRelationships { get; set; } = new List<string>();

        public List<string> Fields { get; set; } = new List<string>();

        public string Token { get; set; }
    }
}