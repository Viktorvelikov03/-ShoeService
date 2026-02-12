using ShoeService.DL.Interfaces;
using ShoeService.DL.LocalDb;
using ShoeService.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShoeService.DL.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        public List<Shoe> GetAll()
            => StaticDatabase.Shoes;

        public Shoe? GetById(string id)
            => StaticDatabase.Shoes.FirstOrDefault(x => x.Id == id);

        public void Add(Shoe shoe)
            => StaticDatabase.Shoes.Add(shoe);

        public void Update(Shoe shoe)
        {
            var index = StaticDatabase.Shoes.FindIndex(x => x.Id == shoe.Id);
            if (index != -1)
                StaticDatabase.Shoes[index] = shoe;
        }

        public void Delete(string id)
        {
            var shoe = GetById(id);
            if (shoe != null)
                StaticDatabase.Shoes.Remove(shoe);
        }
    }
}
