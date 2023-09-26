using GLDiagonistic.Domain;
using GLDiagonistic.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLDiagonistic.Infrastucture.Common
{
    public class GLDDbContext : IdentityDbContext<User>
    {
        public GLDDbContext(DbContextOptions<GLDDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Investigation> Investigations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<InvestigationResult> InvestigationResults { get; set; }
    }
}
