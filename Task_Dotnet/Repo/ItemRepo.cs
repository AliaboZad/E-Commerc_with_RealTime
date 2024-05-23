using Microsoft.EntityFrameworkCore;
using Task_Dotnet.DataContext;
using Task_Dotnet.DTO;
using Task_Dotnet.IRepo;
using Task_Dotnet.Models;

namespace Task_Dotnet.Repo
{
    public class ItemRepo : GenericRepo<Items>, IItemRepo
    {
        
        public ItemRepo(Task_DbContext db) : base(db)
        {
        } 
    }
}
