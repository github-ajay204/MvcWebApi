using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WEBAPI.Models;

namespace WEBAPI.DataAccess
{
    public class Context: DbContext
    {
        public Context() : base("EmpContext")
        {
            // Constructor
        }

        // Define DbSet properties for your entities
        #region Product related
        public DbSet<Product> products { get; set; }
        public IEnumerable<Product> GetProductsFromStoredProcedure()
        {
            return this.Database.SqlQuery<Product>("GetAllProducts");
        }
        #endregion

        #region Student enrollment and courses
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<Enrollment>().HasKey(e => e.EnrollmentId);
        //}

        #endregion
    }
}