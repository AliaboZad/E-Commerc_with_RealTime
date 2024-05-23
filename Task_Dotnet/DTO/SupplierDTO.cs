using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_Dotnet.DTO
{
    public class SupplierDTO
    {
        //Data transfar Object to implement some data of main class Suppliers 
        public int id { get; set; }
        public string SuppName { get; set; }
        [EmailAddress]
        public string Emmailcontent { get; set; }
        
        public List<listItemsDTO> listItems { get; set; } = new List<listItemsDTO>(); 


    }

    public class listItemsDTO
    {
        public int itemid { get; set; } 
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }

    }
}
