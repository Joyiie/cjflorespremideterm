using joy.premidterm.Infrastructure.Domian.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace joy.premidterm.Infrastructure.Domian

    
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
       : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Patient> patients = new List<Patient>();
            List<Payment> roles = new List<Payment>();

            patients.Add(new Patient()
            {
                Id = Guid.Parse("00965ecf-acae-46fe-8775-d7834b07fd96"),
                Code = "123",
                FullName = "Joy",
                DateOfBirth = DateTime.Parse("1984-3-12"),
                Type = Enum.Type.IVInfusion,
                PaymentID =Guid.Parse("00965ecf-acae-46fe-8775-d7834b07fd97")

            });







            roles.Add(new Payment()
            {
                Id = Guid.Parse("00965ecf-acae-46fe-8775-d7834b07fd97"),
                Title = "Credit cards",
                Description = "A credit card is a thin rectangular piece of plastic or metal issued by a bank or financial",
                Abbreviation = "CC"
            });



            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Payment>().HasData(Payments);
        }

    }
}
