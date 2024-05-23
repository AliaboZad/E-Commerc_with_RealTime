using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Task_Dotnet.DataContext;
using Task_Dotnet.DTO;
using Task_Dotnet.Hubs;
using Task_Dotnet.IRepo;
using Task_Dotnet.Models;

namespace Task_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo _itemRepo;

        private readonly IHubContext<ItemsHub> _hubContext;
        public ItemsController(IHubContext<ItemsHub> hubContext, IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
            _hubContext = hubContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listitems = await _itemRepo.GetAll();

            if (listitems == null)
                return NotFound();

            return Ok(listitems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _itemRepo.Get(id);
            if (item != null)
            {
                Items showitem = new()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    SuppId = item.SuppId

                };
                return Ok(showitem);
            }

            return BadRequest($"item number {id} not exist");

        }

        [HttpPost]

        public async Task<IActionResult> PostWithrealtime([FromBody] ItemsDTO items)
        {
            var additems = new Items 
            {   
                ItemId  = items.id,
                ItemName = items.Name,
                Price = items.Price,
                SuppId = items.SupplId
            };

            await _itemRepo.create(additems);

            await _hubContext.Clients.All.SendAsync("ReceiveItems", additems);

            
             
            
            return CreatedAtAction("GetById", new { id = additems.ItemId }, additems); 
        }




        [HttpDelete("DEL")]
        public async Task<IActionResult> Deleteitem(int id)
        {
            var del = _itemRepo.Get(id);
            if (id == 0)
                return BadRequest($"item number {id} not exist");

            await _itemRepo.delete(id);

            await _hubContext.Clients.All.SendAsync("ItemDeleted", del);

            return NoContent();

            //return CreatedAtAction("GetById", new { id = del.Id }, del);

            //return Ok("Deleted Successfuly");

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateItem(int id, [FromForm] ItemsDTO items)
        {
            var getitem = await _itemRepo.Get(id);

            if (getitem != null)
            {
                getitem.ItemName = items.Name;
                getitem.Price = items.Price;
                getitem.SuppId = items.SupplId;

                await _itemRepo.update(getitem);

                await _hubContext.Clients.All.SendAsync("ItemUpdated", items);

                return NoContent();

            }


            return BadRequest("Not Found ");


        }
    }
}
