using System;
using AutoMapper;
using Cart.Api.DTO;

namespace Cart.Api.Mapping
{
    public class CartProfile :Profile
    {
        public CartProfile()
        {
            CreateMap<Accessor.DO.Cart, CartDTO>();
        }
    }
}
