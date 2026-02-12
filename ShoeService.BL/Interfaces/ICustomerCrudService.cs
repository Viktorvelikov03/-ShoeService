using ShoeService.Models.Entities;
using System;
using System.Collections.Generic;

namespace ShoeService.BL.Interfaces
{
    public interface ICustomerCrudService
    {
        List<Shoe> GetAllCustomers();
        Shoe? GetById(Guid id);
        void AddCustomer(Shoe shoe);
        void DeleteCustomer(Guid id);
    }
}
