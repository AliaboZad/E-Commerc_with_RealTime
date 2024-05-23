using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Task_Dotnet.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public decimal Price { get; set; }

        //immplement foreignKey of Suupliers 
        [ForeignKey(nameof(Suppliers))]
        public int SuppId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Supplier Suppliers { get; set; }
    }
}
