﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<int> GetBasketItemCountAsync(string buyerId)
        {
            Guard.Against.NullOrEmpty(buyerId, nameof(buyerId));
            var basket = await _basketRepository
                .FirstOrDefaultAsync(new BasketWithItemsSpecification(buyerId));

            if (basket == null)
            {
                return 0;
            }

            return basket.Items.Sum(x => x.Quantity);
        }

        public async Task TransferBasketAsync(string anonymousId, string userName)
        {
            //Todo: anonim sepetten kullanıcı sepetine aktar
            throw new NotImplementedException();
        }

        public async Task AddItemToBasket(int basketId, int productId, decimal price, int quantity = 1)
        {
            var basket = await _basketRepository
                .FirstOrDefaultAsync(new BasketWithItemsSpecification(basketId));

            var basketItem = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            if (basketItem == null)
            {
                basket.Items.Add(new BasketItem { ProductId = productId, Quantity = quantity, UnitPrice = price });
            }
            else
            {
                basketItem.Quantity += quantity;
            }

            await _basketRepository.UpdateAsync(basket);
        }

        public async Task SetQuantities(int basketId, Dictionary<int, int> quantities)
        {
            var basket = await _basketRepository
                .FirstOrDefaultAsync(new BasketWithItemsSpecification(basketId));
            Guard.Against.Null(basket, nameof(basket));

            foreach (var basketItem in basket.Items)
            {
                if (quantities.ContainsKey(basketItem.ProductId))
                {
                    basketItem.Quantity = quantities[basketItem.ProductId];
                }
            }

            basket.Items.RemoveAll(x => x.Quantity == 0);
            await _basketRepository.UpdateAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            await _basketRepository.DeleteAsync(basket);
        }
    }
}
