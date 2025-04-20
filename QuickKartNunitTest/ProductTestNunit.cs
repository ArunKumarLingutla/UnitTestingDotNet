using QuickKartBL;

namespace QuickKartNunitTest
{
    [TestFixture]
    public class ProductTestNunit
    {
        private Product product;

        [SetUp]
        public void TestInitialize()
        {
            product = new Product("P101", "Shirt", 1, 1000, 20, 4);
        }

        [Test]
        public void Check_InvalidQuantityException()
        {
            Assert.Throws<InvalidQuantityException>(() => product.CalculateDiscountedPrice(0));
        }

        [Test]
        public void Check_QuantityUnavailableException()
        {
            Assert.Throws<QuantityUnAvailableException>(() => product.CalculateDiscountedPrice(21));
        }

        [Test]
        public void Check_QuantityGreaterThan10()
        {
            double totalPrice = product.CalculateDiscountedPrice(11);
            Assert.That(totalPrice, Is.EqualTo(9350));
        }

        [Test]
        public void Check_QuantityBetween5And10()
        {
            double totalPrice = product.CalculateDiscountedPrice(10);
            Assert.That(totalPrice, Is.EqualTo(9000));
        }

        [Test]
        public void Check_QuantityBetween1And5()
        {
            double totalPrice = product.CalculateDiscountedPrice(5);
            Assert.That(totalPrice, Is.EqualTo(5000));
        }

        [TestCase(19, 16150)]
        [TestCase(20, 17000)]
        [TestCase(11, 9350)]
        public void Check_QuantityGreaterThan10(int quantity, double expected)
        {
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            Assert.That(totalPrice, Is.EqualTo(expected));
        }

        [TestCase(6, 5400)]
        [TestCase(9, 8100)]
        [TestCase(10, 9000)]
        public void Check_QuantityBetween5And10(int quantity, double expected)
        {
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            Assert.That(totalPrice, Is.EqualTo(expected));
        }

        [TestCase(1, 1000)]
        [TestCase(2, 2000)]
        [TestCase(4, 4000)]
        [TestCase(5, 5000)]
        public void Check_QuantityBetween1And5(int quantity, double expected)
        {
            double totalPrice = product.CalculateDiscountedPrice(quantity);
            Assert.That(totalPrice, Is.EqualTo(expected));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Check_InvalidQuantityException(int quantity)
        {
            Assert.Throws<InvalidQuantityException>(() => product.CalculateDiscountedPrice(quantity));
        }

        [TearDown]
        public void TestCleanUp()
        {
            product = null;
        }

    }
}
