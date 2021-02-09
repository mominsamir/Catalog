using Catalog1.Dto;
using System;

namespace Catalog1.Entity
{
    public record Item
    {
        public Guid id { get; init; }
        public string name{ get; init; }
        public decimal price{ get; init; }
        public DateTimeOffset createdOn { get; init; }

        public static implicit operator Item(UpdateItemDto v)
        {
            throw new NotImplementedException();
        }
    }
}
