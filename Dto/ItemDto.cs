using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog1.Dto
{
    public record ItemDto
    {
        public Guid id { get; init; }
        public string name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset createdOn { get; init; }
    }

    public record CreateItemDto
    {
        [Required]
        public string name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal price { get; init; }
    }


    public record UpdateItemDto
    {
        [Required]
        public string name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal price { get; init; }
    }
}
