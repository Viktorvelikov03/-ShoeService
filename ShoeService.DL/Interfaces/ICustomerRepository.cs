using ShoeService.Models.Entities;
using System.Collections.Generic;

namespace ShoeService.DL.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer? GetById(string id);
        void Add(Customer customer);
        void Delete(string id);
    }
}
