    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class Product
    {
        //Properties of the Product class
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public byte CategoryId { get; set; }
        public double Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int Rating { get; set; }

        //Constructor of the Product class
        public Product(string productId, string productName, byte categoryId, double price, int quantityAvailable, int rating)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            Price = price;
            QuantityAvailable = quantityAvailable;
            Rating = rating;
        }
        #region CalculateDiscountedPrice
        public double CalculateDiscountedPrice(int quantityToPurchase)
        {
            double totalPrice = 0;

            if (quantityToPurchase <= 0)
            {
                InvalidQuantityException exObj = new InvalidQuantityException("\nQuantity to purchase cannot be less than or equal to zero.\n");
                throw exObj;
            }
            else if (quantityToPurchase > this.QuantityAvailable)
            {
                QuantityUnAvailableException exObj = new QuantityUnAvailableException("\nQuantity to purchase is more than available quantity\n");
                throw exObj;
            }
            else if (quantityToPurchase > 10)
            {
                totalPrice = (this.Price * quantityToPurchase) - (this.Price * quantityToPurchase) * 0.15;
            }
            else if (quantityToPurchase > 5 && quantityToPurchase <= 10)
            {
                totalPrice = (this.Price * quantityToPurchase) - (this.Price * quantityToPurchase) * 0.10;
            }

            else if (quantityToPurchase >= 1 && quantityToPurchase <5)
            {
                totalPrice = this.Price * quantityToPurchase;
            }
            return totalPrice;
        }

        #endregion
    }
}
