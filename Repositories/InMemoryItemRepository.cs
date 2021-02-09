using Catalog1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog1.Repositories
{
    public interface IInMemoryItemRepository
    {
        Item FindByUid(Guid uid);
        IEnumerable<Item> GetItems();

        void createItem(Item item);
        void update(Item item);
    }

    public class InMemoryItemRepositoryImpl : IInMemoryItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { id = Guid.NewGuid(), name = "Samir", price = 3.2M, createdOn = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), name = "Farjana", price = 4.2M, createdOn = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), name = "Zenia", price = 5.2M, createdOn = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), name = "Iqra", price = 6.2M, createdOn = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item FindByUid(Guid uid)
        {
            return items.Where(item => item.id == uid).SingleOrDefault();
        }

        public void createItem(Item item)
        {
            this.items.Add(item);
        }

        public void update(Item item)
        {
            var index = items.FindIndex(i => i.id == item.id);
            items[index] = item;
        }
    }
}
