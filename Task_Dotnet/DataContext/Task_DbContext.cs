using Microsoft.EntityFrameworkCore;
using Task_Dotnet.Models;

namespace Task_Dotnet.DataContext
{
    public class Task_DbContext : DbContext
    {
        // inject two classes (Items and Suppliers) in database that by Dbset<> and DbContext 
        public Task_DbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Items> items { get; set; }
        public DbSet<Supplier> suppliers { get; set; }

    }
}
