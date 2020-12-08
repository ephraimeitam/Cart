using System;
using System.Collections.Generic;

namespace Cart.Api.DTO
{
    public class CartDTO
    {
        public Guid CartId { get; set; }
        public List<Guid> ItemIds { get; set; }
    }
}
