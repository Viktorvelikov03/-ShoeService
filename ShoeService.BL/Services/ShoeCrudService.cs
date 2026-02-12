using System;
using System.Collections.Generic;
using ShoeService.BL.Interfaces;
using ShoeService.DL.Interfaces;
using ShoeService.Models.Entities;

namespace ShoeService.BL.Services
{
    public class ShoeCrudService : ICustomerCrudService
    {
        private readonly IShoeRepository _shoeRepository;

        public ShoeCrudService(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        public void AddCustomer(Shoe shoe)
        {
            shoe.Id = Guid.NewGuid().ToString();
            _shoeRepository.Add(shoe);
        }

        public void DeleteCustomer(Guid id)
        {
            _shoeRepository.Delete(id.ToString());
        }

        public List<Shoe> GetAllCustomers()
        {
            return _shoeRepository.GetAll();
        }

        public Shoe? GetById(Guid id)
        {
            return _shoeRepository.GetById(id.ToString());
        }
    }
}
