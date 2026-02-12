using Microsoft.AspNetCore.Mvc;
using ShoeService.BL.Interfaces;
using ShoeService.Models.Requests;

namespace ShoeService.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyShoesController : ControllerBase
    {
        private readonly IBuyShoesService _buyShoesService;

        public BuyShoesController(IBuyShoesService buyShoesService)
        {
            _buyShoesService = buyShoesService;
        }

        [HttpPost]
        public IActionResult BuyShoes([FromBody] BuyShoesRequest request)
        {
            var result = _buyShoesService.BuyShoes(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
