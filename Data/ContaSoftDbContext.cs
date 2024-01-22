using contasoft_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace contasoft_api.Data
{
    public class ContaSoftDbContext : DbContext
    {
        public ContaSoftDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Invoice606> Invoice606 { get; set; }
        public DbSet<Invoice607> Invoice607 { get; set; }
        public DbSet<O606> O606 { get; set; }
        public DbSet<O607> O607 { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<contasoft_api.Models.Bank>? Bank { get; set; }
        public DbSet<BankSelected> BankSelected { get; set; }
        public DbSet<Transaction> Transaction { get; set; }


    }
}
