using System;
using System.Collections.Generic;
using System.Linq;
using BillingSystem;
using BillingSystem.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BillingSystemTests
{
    public class BillingSystemTests
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
        public void ShouldReturn_CartValue50_ForItemA_Quantity1()
        {
            // Arrange
            var itemA = GetCartItemByName("A");

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA });
            var billing = new Billing(cart);
            billing.CalculateCartValue();

            // Assert
            cart.TotalValue.Should().Be(50);
        }

        [Test]
        public void ShouldReturn_CartValue100_ForItemA_Quantity2()
        {
            // Arrange
            var itemA = GetCartItemByName("A", 2);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA });
            var billing = new Billing(cart);
            billing.CalculateCartValue();

            // Assert
            cart.TotalValue.Should().Be(100);
        }

        [Test]
        public void ShouldReturn_CartValue80_ForItemsAAndB_Quantity1Each()
        {
            // Arrange
            var itemA = GetCartItemByName("A");
            var itemB = GetCartItemByName("B");

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA, itemB });
            var billing = new Billing(cart);
            billing.CalculateCartValue();

            // Assert
            cart.TotalValue.Should().Be(80);
        }

        [Test]
        public void ShouldReturn_CartValue130_ForItemA_Quantity3_AfterApplyingPromotion()
        {
            // Arrange
            var itemA = GetCartItemByName("A", 3);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(130);
        }

        [Test]
        public void ShouldReturn_CartValue45_ForItemB_Quantity2_AfterApplyingPromotion()
        {
            // Arrange
            var itemB = GetCartItemByName("B", 2);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemB });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(45);
        }

        [Test]
        public void ShouldReturn_CartValue30_ForItemsCD_Quantity1Each_AfterApplyingPromotion()
        {
            // Arrange
            var itemC = GetCartItemByName("C");
            var itemD = GetCartItemByName("D");

            // Act
            var cart = CreateCart(new List<CartItem>() { itemC, itemD });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(30);
        }

        [Test]
        public void ShouldReturn_CartValue60_ForItemsCD_Quantity2Each_AfterApplyingPromotion()
        {
            // Arrange
            var itemC = GetCartItemByName("C", 2);
            var itemD = GetCartItemByName("D", 2);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemC, itemD });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(60);
        }

        [Test]
        public void ShouldReturn_CartValue45_ForItemsCD_Quantity1ForC2ForD_AfterApplyingPromotion()
        {
            // Arrange
            var itemC = GetCartItemByName("C", 1);
            var itemD = GetCartItemByName("D", 2);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemC, itemD });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(45);
        }

        [Test]
        public void ShouldReturn_CartValue100_ForItemsABC_Quantity1Each_AfterApplyingPromotion()
        {
            // Arrange
            var itemA = GetCartItemByName("A", 1);
            var itemB = GetCartItemByName("B", 1);
            var itemC = GetCartItemByName("C", 1);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA, itemB, itemC });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(100);
        }

        [Test]
        public void ShouldReturn_CartValue370_ForItemsABC_AfterApplyingPromotion()
        {
            // Arrange
            var itemA = GetCartItemByName("A", 5);
            var itemB = GetCartItemByName("B", 5);
            var itemC = GetCartItemByName("C", 1);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA, itemB, itemC });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(370);
        }

        [Test]
        public void ShouldReturn_CartValue280_ForItemsABCD_AfterApplyingPromotion()
        {
            // Arrange
            var itemA = GetCartItemByName("A", 3);
            var itemB = GetCartItemByName("B", 5);
            var itemC = GetCartItemByName("C", 1);
            var itemD = GetCartItemByName("D", 1);

            // Act
            var cart = CreateCart(new List<CartItem>() { itemA, itemB, itemC, itemD });
            var billing = new Billing(cart);
            billing.CalculateCartValue(promotions);

            // Assert
            cart.TotalValue.Should().Be(280);
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