using CoreWebApiOrnek.DAL.Concerete.EfCore.Configuration;
using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiOrnek.DAL.Concerete.EfCore.Context
{
    public partial class ApiContext : DbContext        //insall EfCore Tools,Design,SqlServer 
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=APIORNEK;Trusted_Connection=True;");
        //}
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap()); 
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new ExpenseMap());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }//Kullanicilar
        public DbSet<Group> Groups { get; set; }//Gruplar
        public DbSet<Expense> Expenses { get; set; }//Giderler
    }
}
