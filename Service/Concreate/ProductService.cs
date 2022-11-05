using Application.Repositories;
using Application.Service;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concreate
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Product product)
        {
            await _repository.AddAsync(product);
            await _repository.SaveAsync();
        }

        public async Task DeleteidAsync(string id)
        {
            await _repository.DeleteByidAsync(id);
            await _repository.SaveAsync();
        }

        public async Task<Product> GetById(string id)
        {
            Product product = await _repository.GetById(id);
            return product;
        }

        public  IList<Product> GetProducts()
        {
            IList<Product> products = _repository.GetAll().ToList();
            return products;
        }

        public async Task UpdateAsync(Product product)
        {
            _repository.update(product);
            await _repository.SaveAsync();
        }
    }
}
