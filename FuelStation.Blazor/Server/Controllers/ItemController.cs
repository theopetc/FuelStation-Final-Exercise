using FuelStation.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IEntityRepo<Item> _itemRepo;
        public ItemController(IEntityRepo<Item> itemRepo)
        {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemListViewModel>> Get()
        {
            var result = await _itemRepo.GetAllAsync();
            return result.Select(x => new ItemListViewModel
            {
                ID = x.ID,
                Code = x.Code,
                Description = x.Description,
                ItemType = x.ItemType,
                Price = x.Price,
                Cost = x.Cost
            });
        }

        [HttpGet("{id}")]
        public async Task<ItemListViewModel> Get(int id)
        {
            var result = await _itemRepo.GetByIdAsync(id);
            return new ItemListViewModel
            {
                ID = result.ID,
                Code = result.Code,
                Description = result.Description,
                ItemType = result.ItemType,
                Price = result.Price,
                Cost = result.Cost
            };
        }

        [HttpPost]
        public async Task Post(ItemListViewModel item)
        {
            var newItem = new Item();
            newItem.Code = item.Code;
            newItem.Description = item.Description;
            newItem.ItemType = item.ItemType;
            newItem.Price = item.Price;
            newItem.Cost = item.Cost;

            await _itemRepo.CreateAsync(newItem);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _itemRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ItemListViewModel item)
        {
            var itemToUpdate = await _itemRepo.GetByIdAsync(item.ID);
            if (itemToUpdate == null) return NotFound();

            itemToUpdate.Code = item.Code;
            itemToUpdate.Description = item.Description;
            itemToUpdate.ItemType = item.ItemType;
            itemToUpdate.Price = item.Price;
            itemToUpdate.Cost = item.Cost;

            await _itemRepo.UpdateAsync(item.ID, itemToUpdate);

            return Ok();
        }
    }
}
