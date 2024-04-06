using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrendyWay.Basket.Dtos;
using TrendyWay.Basket.LoginServices;
using TrendyWay.Basket.Services;

namespace TrendyWay.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserID);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserID = _loginService.GetUserID;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Changes saved");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserID);
            return Ok();
        }
    }
}
