using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Task_Dotnet.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public string SupplierName { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        //ForienKey of Items
        public virtual List<Items> item { get; set; }


    }
}
