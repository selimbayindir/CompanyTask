using Application.Repositories;
using DataAccess.Context;
using Entity.Entities;
using Service.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class ProductRepository : Repositories<Product>, IProductRepository
    {
        public ProductRepository(MvcAppContext context) : base(context)
        {
        }
    }
}
