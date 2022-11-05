using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IProductService
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteidAsync(string id);
        IList<Product> GetProducts();
        Task<Product> GetById(string id);

    }
}
