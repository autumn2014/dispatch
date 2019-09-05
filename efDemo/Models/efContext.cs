using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace efDemo.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class efContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public efContext() : base("name=efContext")
        {
        }

        public System.Data.Entity.DbSet<efDemo.Models.Keyboard> Keyboards { get; set; }

        public System.Data.Entity.DbSet<efDemo.Models.Mouse> Mice { get; set; }

        public System.Data.Entity.DbSet<efDemo.Models.Book> Books { get; set; }
    }
}
