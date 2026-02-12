using ShoeService.DL.Interfaces;
using ShoeService.DL.LocalDb;
using ShoeService.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShoeService.DL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll()
            => StaticDatabase.Customers;

        public Customer? GetById(string id)
            => StaticDatabase.Customers.FirstOrDefault(x => x.Id == id);

        public void Add(Customer customer)
            => StaticDatabase.Customers.Add(customer);

        public void Delete(string id)
        {
            var customer = GetById(id);
            if (customer != null)
                StaticDatabase.Customers.Remove(customer);
        }
    }
}
