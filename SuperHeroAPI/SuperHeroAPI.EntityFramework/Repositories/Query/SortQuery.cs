using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SuperHeroAPI.EntityFramework.Repositories.Query
{
    public class SortQuery
    {
        public SortQuery(SortDirection direction, string sortedAttribute)
        {

            Direction = direction;
            SortedAttribute = sortedAttribute;

        }

        public SortDirection Direction { get; set; }

        public string SortedAttribute { get; set; }

    }

}