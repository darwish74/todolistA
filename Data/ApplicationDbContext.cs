using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using todolistA.Models;

namespace todolistA.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Person> persons { get; set; }
        public DbSet<Tasky> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Taskty;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
