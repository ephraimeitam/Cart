using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart.Api.Manager;
using Microsoft.AspNetCore.Mvc;


namespace Cart.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class Cart : ControllerBase
    {
       

        
        private readonly ICartManager _manager;
      

        public Cart(ICartManager manager)
        {
            
            _manager = manager;
        }

        [HttpGet]
        [Route("{CartId}")]
        public async Task<IActionResult>  Get(Guid CartId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var Cart = await _manager.GetCart(CartId);
                if (Cart == null)
                    return NotFound("Cart Doesn't Exists");
                return Ok(Cart);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        
        public async Task<IActionResult> Post()
        {
            try
            {


                Guid CartId = await _manager.AddNewCart();
                return Ok(CartId);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpDelete]
        [Route("{CartId}")]
        public async Task<IActionResult> Delete(Guid CartId)
        {
            try
            {

                await _manager.DeleteCart(CartId);
                return Ok();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
