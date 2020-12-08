using System;
using System.Threading.Tasks;
using System.Linq;


namespace Cart.Api.Accessor
{
    public class CartAccessor :ICartAccessor
    {
        private readonly CartDB DB ;
        public CartAccessor(CartDB _DB)
        {
            DB = _DB;
        }

        public async Task<DO.Cart> GetCart(Guid CartID)
        {
            
            return  DB.CartData.Where(x => x.CartId == CartID).FirstOrDefault();
            
        }
        public async Task<Guid> AddNewCart()
        {
            return DB.CreateCart();

        }
        public async Task DeleteCart(Guid CartID)
        {
             DB.DeleteCart(CartID);

        }


        public async Task<DO.Cart> AddItem(Guid CartID,Guid ItemId)
        {
             
            var Cart = DB.CartData.Where(x => x.CartId == CartID).FirstOrDefault();
            if (Cart == null)
                return Cart;

            Cart.ItemIds.Add(ItemId);
            return DB.CartData.Where(x => x.CartId == CartID).FirstOrDefault();

        }

        public async Task<DO.Cart> RemoveItem(Guid CartID, Guid ItemId)
        {
            var Cart = DB.CartData.Where(x => x.CartId == CartID).FirstOrDefault();
            if (Cart == null)
                return Cart;

            Cart.ItemIds.Remove(ItemId);
            return DB.CartData.Where(x => x.CartId == CartID).FirstOrDefault();

        }
    }
}
