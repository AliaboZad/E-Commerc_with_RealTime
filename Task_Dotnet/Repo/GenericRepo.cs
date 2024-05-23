using Microsoft.EntityFrameworkCore;
using Task_Dotnet.DataContext;
using Task_Dotnet.IRepo;
using Task_Dotnet.Models;

namespace Task_Dotnet.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        // Generic Repository : That class implement  Methods from interface IGenericRepo
        // Methods of interface are CRUD operations 

        private readonly Task_DbContext _db;
        public GenericRepo(Task_DbContext db)
        {
            _db = db;
        }

        // create a new (Item Or Supplier)
        public async Task create(T Gen)
        {
            await _db.Set<T>().AddAsync(Gen);
            await _db.SaveChangesAsync();
        }

        // Get one (Item or Supplier) By ID 
        public async Task<T> Get(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        // Get List of (Items or Suppliers )
        public async Task<List<T>> GetAll()
            => await  _db.Set<T>().ToListAsync();

        // Ipdate (Item or Suplier )
        public async Task update(T Gen)
        {

            _db.Set<T>().Update(Gen);

            await _db.SaveChangesAsync();

        }

        // Delete one of (Items or Suppliers) By ID
        public async Task delete(int id)
        {

            var Delete = await Get(id);

            _db.Set<T>().Remove(Delete);

            await _db.SaveChangesAsync();

        }
    }
}
