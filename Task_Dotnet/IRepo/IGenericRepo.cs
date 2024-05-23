using Task_Dotnet.DTO;
using Task_Dotnet.Models;

namespace Task_Dotnet.IRepo
{
    public interface IGenericRepo<T> where T : class
    {
        // Generic Interface for the same Methods  
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task create(T Gen);
        Task update( T Gen); 
        Task delete(int id);
    }
}
