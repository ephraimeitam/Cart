using System;
using System.Threading.Tasks;
using Cart.Api.Accessor;
using Cart.Api.Accessor.DO;
using Cart.Api.DTO;
using AutoMapper;


namespace Cart.Api.Manager
{
    public class CartManager : ICartManager
    {
        
        private readonly ICartAccessor _accessor;
        private readonly IMapper _mapper;
        

        public CartManager(ICartAccessor accessor, IMapper mapper/*,  ILogger<CartAccessor> logger*/)
        {
            _mapper = mapper;
            _accessor = accessor;
            //_logger = logger;
        }
        

        
       
        public async Task<CartDTO> GetCart(Guid CartId)
         {
            //_logger.LogDebug("Cart - GetCart");
             var Cart = await _accessor.GetCart(CartId);
            var c = _mapper.Map<CartDTO>(Cart);
            return c;// _mapper.Map<CartDTO>(Cart);
            
         }

        public async Task<Guid> AddNewCart()
        {
            //_logger.LogDebug("Cart - GetCart");
            
            return await _accessor.AddNewCart();

        }
        public async Task DeleteCart(Guid CartId)
        {
            //_logger.LogDebug("Cart - GetCart");

             await _accessor.DeleteCart(CartId);

        }

        public async Task<CartDTO> AddItem(Guid CartId,Guid Itemid)
        {
            //_logger.LogDebug("Cart - GetCart"); 
            var Cart = await _accessor.AddItem(CartId,Itemid);
            
            return  _mapper.Map<CartDTO>(Cart);

        }

        public async Task<CartDTO> RemoveItem(Guid CartId, Guid Itemid)
        {
            //_logger.LogDebug("Cart - GetCart"); 
            var Cart = await _accessor.RemoveItem(CartId, Itemid);
            return _mapper.Map<CartDTO>(Cart);

        }
    }
}
