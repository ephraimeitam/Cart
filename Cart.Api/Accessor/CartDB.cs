using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Accessor
{
    public  class CartDB
    {
        public List<DO.Cart> CartData;
       public CartDB()
        {
            CartData = new List<DO.Cart>();
        }

        
        public Guid  CreateCart()
        {
            Guid CartId = Guid.NewGuid();
            DO.Cart cart = new DO.Cart();
            cart.CartId = CartId;
            cart.ItemIds = new List<Guid>();
            CartData.Add(cart);
            return CartId;


        }

        public void DeleteCart(Guid CartId)
        {
            var cart = CartData.Where(x => x.CartId == CartId).First();
            CartData.Remove(cart);
        }
        public async Task< DO.Cart> GetCart(Guid CartId)
        {
            return  CartData.Where(x => x.CartId == CartId).FirstOrDefault();
           
        }



        public void AddItem(Guid CartId, Guid ItemId)
        {
            try
            {
                var cart = CartData.Where(x => x.CartId == CartId).First();
                if (cart == null)
                {
                    throw new Exception("Cart Doesnt Exists");
                }
                cart.ItemIds.Add(ItemId);
                
            }
            catch (Exception e)
            {
                throw e;
            }



        }
        public void Removetem(Guid CartId, Guid ItemId)
        {
            try
            {
                var cart = CartData.Where(x => x.CartId == CartId).First();
                if (cart == null)
                {
                    throw new Exception("Cart Doesnt Exists");
                }
                cart.ItemIds.Remove(ItemId);

            }
            catch (Exception e)
            {
                throw e;
            }



        }


    }
}
