﻿using BusinessLayer.GenericRepo;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProductRepo
{
    public interface IProductRepository :IGenericRepository<Product>
    {
    }
}
