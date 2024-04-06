using TrendyWay.Basket.Dtos;

namespace TrendyWay.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userID);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userID);

    }
}
