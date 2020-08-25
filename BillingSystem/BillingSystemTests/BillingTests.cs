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

        [SetUp]
        public void Setup()
        {
            InitializeSKUList();
        }

        [Test]
        public void ShouldReturnCartValue50ForItemAQuantity1()
        {
            var itemA = GetItemByName("A");
            itemA.Quantity = 1;
            var billing = new Billing(CreateCart(new List<SKU>() { itemA }));
            var cartValue = billing.CalculateCartValue();

            cartValue.Should().Be(50);
        }

        private static Cart CreateCart(IList<SKU> cartItems)
        {
            var cart = new Cart();
            foreach (var item in cartItems)
            {
                cart.Items.Add(item);
            }
            return cart;
        }

        private static SKU GetItemByName(string itemName)
        {
            return skuList.FirstOrDefault(sku => sku.Name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase));
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
    }
}