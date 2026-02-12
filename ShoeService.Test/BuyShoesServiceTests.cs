using Moq;
using ShoeService.BL.Services;
using ShoeService.DL.Interfaces;
using ShoeService.Models.Entities;
using ShoeService.Models.Requests;
using Xunit;

namespace ShoeService.Test
{
    public class BuyShoesServiceTests
    {
        private readonly Mock<IShoeRepository> _shoeRepositoryMock;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly BuyShoesService _service;

        public BuyShoesServiceTests()
        {
            _shoeRepositoryMock = new Mock<IShoeRepository>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            _service = new BuyShoesService(
                _shoeRepositoryMock.Object,
                _customerRepositoryMock.Object);
        }

        [Fact]
        public void BuyShoes_ShouldReturnSuccess_WhenPurchaseIsValid()
        {
            // Arrange
            var customer = new Customer { Id = "1", FullName = "Ivan", Email = "ivan@example.com" };
            var shoe = new Shoe { Id = "10", Brand = "Nike", Price = 100, Quantity = 5 };

            _customerRepositoryMock.Setup(x => x.GetById("1")).Returns(customer);
            _shoeRepositoryMock.Setup(x => x.GetById("10")).Returns(shoe);

            var request = new BuyShoesRequest
            {
                CustomerId = "1",
                ShoeId = "10",
                Quantity = 2
            };

            // Act
            var result = _service.BuyShoes(request);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(200, result.TotalPrice);
            Assert.Equal("Purchase successful", result.Message);
            _shoeRepositoryMock.Verify(x => x.Update(It.IsAny<Shoe>()), Times.Once);
        }

        [Fact]
        public void BuyShoes_ShouldReturnError_WhenNotEnoughQuantity()
        {
            // Arrange
            var customer = new Customer { Id = "1", FullName = "Ivan", Email = "ivan@example.com" };
            var shoe = new Shoe { Id = "10", Brand = "Nike", Price = 100, Quantity = 1 };

            _customerRepositoryMock.Setup(x => x.GetById("1")).Returns(customer);
            _shoeRepositoryMock.Setup(x => x.GetById("10")).Returns(shoe);

            var request = new BuyShoesRequest
            {
                CustomerId = "1",
                ShoeId = "10",
                Quantity = 5
            };

            // Act
            var result = _service.BuyShoes(request);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Not enough quantity available", result.Message);
            _shoeRepositoryMock.Verify(x => x.Update(It.IsAny<Shoe>()), Times.Never);
        }
    }
}
