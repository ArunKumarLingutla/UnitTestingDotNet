namespace QuickKartBL.Tests
{
    [TestClass()]
    public class ProductTestsMS
    {
        private Product product;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            product = new Product("P101", "Shirt", 1, 1000, 20, 4);
        }

        [TestMethod()]
        [ExpectedException(typeof(QuantityUnAvailableException))]
        public void Check_QuantityUnAvailableException()
        {
            //Act
            product.CalculateDiscountedPrice(21);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidQuantityException))]
        [DataRow(-1)]
        [DataRow(0)]
        public void Check_InvalidQuantityException(int quantity)
        {
            //Act
            product.CalculateDiscountedPrice(quantity);
        }

        [TestMethod()]
        [DataRow(19, 16150)]
        [DataRow(11, 9350)]
        [DataRow(20, 17000)]
        public void Check_QuantityGreaterThan10(int quantity, double expected)
        {
            //Act
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            //Assert
            Assert.AreEqual(expected, totalPrice);
        }

        [TestMethod()]
        [DataRow(9, 8100)]
        [DataRow(6, 5400)]
        [DataRow(10, 9000)]
        public void Check_QuantityBetween5And10(int quantity, double expected)
        {
            //Act
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            //Assert
            Assert.AreEqual(expected, totalPrice);
        }
    }
}