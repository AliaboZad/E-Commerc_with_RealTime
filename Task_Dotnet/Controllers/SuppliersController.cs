using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Task_Dotnet.DTO;
using Task_Dotnet.IRepo;
using Task_Dotnet.Models;
using Task_Dotnet.Repo;

namespace Task_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepo _supplierRepo;
        public SuppliersController(ISupplierRepo supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listSupport = await _supplierRepo.GetAll();

            if (listSupport == null)
                return NotFound();

            return Ok(listSupport);
        }

        [HttpPost]
        public async Task<IActionResult> Creat(SupplierDTO supplierDTO)
        {
            var addsupp = new Supplier
            {
                SupplierName = supplierDTO.SuppName,
                ContactEmail = supplierDTO.Emmailcontent,
            };

            await _supplierRepo.create(addsupp);
            return Ok("Add Successfully");
            
        }

        [HttpGet("GetSuppById")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var supp = await _supplierRepo.Get(id);

            if (supp != null)
            {
                SupplierDTO suppdto = new SupplierDTO
                {
                    id = supp.SupplierId,
                    SuppName = supp.SupplierName,
                    Emmailcontent = supp.ContactEmail,

                };

                if ( supp.item != null && supp.item.Any() )
                {
                    foreach (var item in supp.item)
                    {
                        listItemsDTO listitem = new ()
                        { 
                            itemid = item.ItemId,
                            ItemName = item.ItemName,
                            ItemPrice = item.Price    
                        };
                        suppdto.listItems.Add(listitem);
                    }
                }
                return Ok(suppdto);
            }

            return BadRequest($"item number {id} not exist");

        }

        [HttpDelete]

        public async Task<IActionResult> Deletesupp(int id)
        {
            if (id == 0)
                return BadRequest($"item number {id} not exist");

            await _supplierRepo.delete(id);

            return Ok("Deleted Successfuly");

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateItem(int id, [FromForm] SupplierDTO supplierDTO)
        {
            var getsupp = await _supplierRepo.Get(id);

            if (getsupp != null)
            {
                getsupp.SupplierId = supplierDTO.id;
                getsupp.SupplierName = supplierDTO.SuppName;
                getsupp.ContactEmail = supplierDTO.Emmailcontent;
                

                await _supplierRepo.update(getsupp);

                return Ok("Updated");

            }


            return BadRequest("Not Found ");


        }
    }
}
