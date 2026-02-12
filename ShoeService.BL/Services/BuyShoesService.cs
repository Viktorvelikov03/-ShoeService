using ShoeService.BL.Interfaces;
using ShoeService.DL.Interfaces;
using ShoeService.Models.Requests;
using ShoeService.Models.Responses;

namespace ShoeService.BL.Services
{
    public class BuyShoesService : IBuyShoesService
    {
        private readonly IShoeRepository _shoeRepository;
        private readonly ICustomerRepository _customerRepository;

        public BuyShoesService(
            IShoeRepository shoeRepository,
            ICustomerRepository customerRepository)
        {
            _shoeRepository = shoeRepository;
            _customerRepository = customerRepository;
        }

        public BuyShoesResponse BuyShoes(BuyShoesRequest request)
        {
            var customer = _customerRepository.GetById(request.CustomerId);
            if (customer == null)
            {
                return new BuyShoesResponse
                {
                    Success = false,
                    Message = "Customer not found"
                };
            }

            var shoe = _shoeRepository.GetById(request.ShoeId);
            if (shoe == null)
            {
                return new BuyShoesResponse
                {
                    Success = false,
                    Message = "Shoe not found"
                };
            }

            if (shoe.Quantity < request.Quantity)
            {
                return new BuyShoesResponse
                {
                    Success = false,
                    Message = "Not enough quantity available"
                };
            }

            // Намаляваме количеството
            shoe.Quantity -= request.Quantity;
            _shoeRepository.Update(shoe);

            return new BuyShoesResponse
            {
                Success = true,
                Message = "Purchase successful",
                TotalPrice = shoe.Price * request.Quantity
            };
        }
    }
}
