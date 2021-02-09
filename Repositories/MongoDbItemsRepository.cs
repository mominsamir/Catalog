using Catalog1.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog1.Repositories
{
    public class MongoDbItemsRepository : IInMemoryItemRepository
    {
        private const string DATABASE_NAME = "catlog";
        private const string COLLECTION_NAME = "items";

        private readonly IMongoCollection<Item> itemsCollections; 
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DATABASE_NAME);
            itemsCollections = database.GetCollection<Item>(COLLECTION_NAME);
        }


        public void createItem(Item item)
        {
            itemsCollections.InsertOne(item);
        }

        public Item FindByUid(Guid uid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
