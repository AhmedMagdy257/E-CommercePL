using BusinessLayer.GenericRepo;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProductRepo
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository    
    {

        private readonly ECommerceDbContext _dbContext;

        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

    }
}
