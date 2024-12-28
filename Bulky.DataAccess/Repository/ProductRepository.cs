using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        readonly private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Price = obj.Price;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price50 = obj.Price50; 
                objFromDb.Author = obj.Author;
                objFromDb.ListPrice = obj.ListPrice;
                if (objFromDb != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
