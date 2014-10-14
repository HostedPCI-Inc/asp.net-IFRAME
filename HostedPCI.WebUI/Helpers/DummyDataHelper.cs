using System;
using HostedPCI.WebUI.Models.Entities;

namespace HostedPCI.WebUI.Helpers
{
    public static class DummyDataHelper
    {
        public static CustomerInfoModel CreateCustomer()
        {
            var customer = new CustomerInfoModel
            {
                Email = "hpcitest1@mailinator.com",
                CustomerId = "hpcitest1",
                CustomerIP = "173.32.21.248",
                BillingAddress = new BillingAddressModel
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Address = "123 Elm Street",
                    State = "CA",
                    City = "Beverly Hills",
                    ZipCode = "90210",
                    Country = "US"
                },
                ShippingAddress = new ShippingAddressModel
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Address = "123 Elm Street",
                    State = "CA",
                    City = "Beverly Hills",
                    ZipCode = "90210",
                    Country = "US"
                }
            };

            return customer;
        }

        public static OrderModel CreateOrder()
        {
            var orderItem1 = new OrderItemModel
            {
                Id = "Item1",
                Name = "ItemName1",
                Description = "Item Description 1",
                Quantity = "1",
                Price = 2,
                Taxable = false
            };

            var orderItem2 = new OrderItemModel
            {
                Id = "Item2",
                Name = "ItemName2",
                Description = "Item Description 2",
                Quantity = "1",
                Price = 1,
                Taxable = false
            };

            var orderItems = new[] {orderItem1, orderItem2};

            var order = new OrderModel
            {
                InvoiceNumber = DateTime.Now.Ticks.ToString(),
                Description = "Test Order",
                TotalAmount = 4.25M,
                Currency = "USD",
                OrderItems = orderItems
            };

            return order;
        }

        public static TransactionModel CreateTransaction()
        {
            var transaction = new TransactionModel
            {
                Amount = 80.25M,
                CurrencyCode = "USD",
                MerchantRefId = Guid.NewGuid().ToString("N").ToUpper()
            };

            return transaction;
        }
    }
}