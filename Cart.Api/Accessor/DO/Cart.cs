using System;
using System.Collections.Generic;

namespace Cart.Api.Accessor.DO
{
    public class Cart
    {
       
        public Guid CartId { get; set; }
        public List<Guid> ItemIds { get; set; }

        
    }
}
