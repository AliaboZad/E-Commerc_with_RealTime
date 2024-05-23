using Microsoft.EntityFrameworkCore;
using Task_Dotnet.DataContext;
using Task_Dotnet.IRepo;
using Task_Dotnet.Models;

namespace Task_Dotnet.Repo
{
    public class SupplierRepo : GenericRepo<Supplier> , ISupplierRepo
    {
        public SupplierRepo(Task_DbContext db) : base(db)
        {
            
        }
    }
}
