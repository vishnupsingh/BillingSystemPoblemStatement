using BillingSystem;
using BillingSystem.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystemTests
{
    public class Tests
    {
        private static IList<SKU> skuList = new List<SKU>();
        private static IList<Promotion> promotions = new List<Promotion>();

        [SetUp]
        public void Setup()
        {
            InitializeSKUList();
            InitializePromotions();
        }

        [Test]
        public void ShouldReturnCartValue50ForItemAQuantity1()
        {
            var itemA = GetCartItemByName("A");
            itemA.Quantity = 1;
            var billing = new Billing(CreateCart(new List<CartItem>() { itemA }));
            var cartValue = billing.CalculateCartValue();

            cartValue.Should().Be(50);
        }

        [Test]
        public void ShouldReturnCartValue100ForItemAQuantity2()
        {
            var itemA = GetCartItemByName("A");
            itemA.Quantity = 2;
            var billing = new Billing(CreateCart(new List<CartItem>() { itemA }));
            var cartValue = billing.CalculateCartValue();

            cartValue.Should().Be(100);
        }

        [Test]
        public void ShouldReturnCartValue80ForItemsAAndBQuantity1Each()
        {
            var itemA = GetCartItemByName("A");
            var itemB = GetCartItemByName("B");
            var billing = new Billing(CreateCart(new List<CartItem>() { itemA, itemB }));
            var cartValue = billing.CalculateCartValue();

            cartValue.Should().Be(80);
        }

        [Test]
        public void ShouldReturnCartValue130ForItemAQuantity3AfterApplyingPromotion()
        {
            var itemA = GetCartItemByName("A", 3);
            var billing = new Billing(CreateCart(new List<CartItem>() { itemA }));
            var cartValue = billing.CalculateCartValue(promotions);

            cartValue.Should().Be(130);
        }

        private static Cart CreateCart(IList<CartItem> cartItems)
        {
            var cart = new Cart();
            foreach (var item in cartItems)
            {
                cart.Items.Add(item);
            }
            return cart;
        }

        private static CartItem GetCartItemByName(string itemName, int quantity = 1)
        {
            var item = skuList.FirstOrDefault(sku => sku.Name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase));
            return new CartItem
            {
                Id = new Random().Next(),
                SKU = item,
                Quantity = quantity
            };
        }

        private static void InitializeSKUList()
        {
            skuList.Add(new SKU
            {
                Id = 1,
                Name = "A",
                Price = 50
            });
            skuList.Add(new SKU
            {
                Id = 2,
                Name = "B",
                Price = 30
            });
            skuList.Add(new SKU
            {
                Id = 3,
                Name = "C",
                Price = 20
            });
            skuList.Add(new SKU
            {
                Id = 4,
                Name = "D",
                Price = 15
            });
        }

        private static void InitializePromotions()
        {
            promotions.Add(new Promotion
            {
                Id = 1,
                Items = new List<int> { 1 },
                Quantity = 3,
                OfferValue = 130,
                PromotionType = PromotionType.BulkItems
            });
            promotions.Add(new Promotion
            {
                Id = 2,
                Items = new List<int> { 2 },
                Quantity = 2,
                OfferValue = 45,
                PromotionType = PromotionType.BulkItems
            });
            promotions.Add(new Promotion
            {
                Id = 3,
                Items = new List<int> { 3, 4 },
                Quantity = 1,
                OfferValue = 30,
                PromotionType = PromotionType.Combo
            });
        }
    }
}