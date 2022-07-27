using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppWeb.EntityFramework
{
    public class SchoolDataContext : DbContext
    {
        public SchoolDataContext(DbContextOptions<SchoolDataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //if(!optionBuilder.IsConfigured)
            //{
            //    optionBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=SchoolDatabase;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
