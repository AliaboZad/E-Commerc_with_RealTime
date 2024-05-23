using Microsoft.AspNetCore.Mvc;
using Task_Dotnet.DTO;
using Task_Dotnet.Models;

namespace Task_Dotnet.IRepo
{
    public interface IItemRepo : IGenericRepo<Items>
    {
        
    }
}
