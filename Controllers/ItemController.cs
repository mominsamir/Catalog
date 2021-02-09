using Microsoft.AspNetCore.Mvc;
using Catalog1.Repositories;
using Catalog1.Entity;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using Catalog1.Dto;
using Catalog1.Extention;
using System;

namespace Catalog1.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : Controller
    {
        private readonly IInMemoryItemRepository itemRepostory;

        public object id { get; private set; }

        public ItemController(IInMemoryItemRepository itemRepostory)
        {
            this.itemRepostory = itemRepostory;
        }

        [HttpGet]
        public IEnumerable<ItemDto> getItems()
        {
            return itemRepostory.GetItems().Select(i => i.asDto());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> findOne(Guid id)
        {
            var item = itemRepostory.FindByUid(id);
            return item is null ? NotFound() : item.asDto();
        }


        [HttpPost]
        public ActionResult<ItemDto> createItem(CreateItemDto i)
        {
            Item item = new()
            {
                id = Guid.NewGuid(),
                name = i.name,
                price = i.price,
                createdOn = DateTimeOffset.UtcNow
            };

            itemRepostory.createItem(item);

            return CreatedAtAction(nameof(findOne), new { id = item.id  }, item.asDto());
        }

        [HttpPut("{id}")]
        public ActionResult updateItem(Guid id, UpdateItemDto dto)
        {
            var item = itemRepostory.FindByUid(id);
            if(item is null)
            {
                return NotFound();
            }

            Item editedItem = item with
            {
                name = dto.name,
                price = dto.price
            };

            itemRepostory.update(editedItem);

            return NoContent();
        }

    }
}
