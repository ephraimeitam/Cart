using System;
using System.Threading.Tasks;
using Cart.Api.DTO;

namespace Cart.Api.Manager
{
    public interface ICartManager
    {

        Task<CartDTO> GetCart(Guid CartId);
        Task<Guid> AddNewCart();
        Task DeleteCart(Guid CartId);
        Task<CartDTO> AddItem(Guid CartId, Guid Itemid);
        Task<CartDTO> RemoveItem(Guid CartId, Guid Itemid);
    }
}
