using ShoeService.Models.Entities;
using System.Collections.Generic;

namespace ShoeService.DL.Interfaces
{
    public interface IShoeRepository
    {
        List<Shoe> GetAll();
        Shoe? GetById(string id);
        void Add(Shoe shoe);
        void Update(Shoe shoe);
        void Delete(string id);
    }
}
