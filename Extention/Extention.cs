using Catalog1.Dto;
using Catalog1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog1.Extention
{
    public static class Extention
    {
        public static ItemDto asDto(this Item i)
        {
            return new ItemDto
            {
                name = i.name,
                id = i.id,
                createdOn = i.createdOn,
                price = i.price
            };
        }
    }
}
