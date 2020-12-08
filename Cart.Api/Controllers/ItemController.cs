using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart.Api.Manager;
using Microsoft.AspNetCore.Mvc;


namespace Cart.Api.Controllers
{

    [ApiController]
    [Route("api/cart/{CartId}/item/{ItemId}")]
    public class ItemController : Controller
    {

        
        private readonly ICartManager _manager;

        public ItemController(ICartManager manager)
        {
            
            _manager = manager;
        }

        [HttpPost]

        public async Task<IActionResult> Post(Guid CartId,Guid ItemId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var Cart = await _manager.AddItem(CartId,ItemId);
                if (Cart == null)
                    return NotFound("Cart Doesn't Exists");
                return Ok(Cart);

            }
            catch (Exception e)
            {

                throw e;
            }

        }


        [HttpDelete]

        public async Task<IActionResult> Delete(Guid CartId, Guid ItemId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var Cart = await _manager.RemoveItem(CartId, ItemId);
                if (Cart == null)
                    return NotFound("Cart Doesn't Exists");
                return Ok(Cart);

            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
