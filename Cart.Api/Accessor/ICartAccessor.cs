using System;
using System.Threading.Tasks;

namespace Cart.Api.Accessor
{
    public interface ICartAccessor
    {

        Task<DO.Cart> GetCart(Guid CartID);

        Task<Guid> AddNewCart();

        Task DeleteCart(Guid CartID);

        Task<DO.Cart> AddItem(Guid CartID, Guid ItemId);

        Task<DO.Cart> RemoveItem(Guid CartID, Guid ItemId);



    }
}
