﻿using System.Text.Json;
using TrendyWay.Basket.Dtos;
using TrendyWay.Basket.Settings;

namespace TrendyWay.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userID)
        {
           var status = await _redisService.GetDb().KeyDeleteAsync(userID);
        }

        public async Task<BasketTotalDto> GetBasket(string userID)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userID);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
