using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SportStore.Services;

namespace SportStore.Models
{

    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Save(Product product);
        void Save(IEnumerable<Product> products);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IOptions<AppSettings> _options;

        private readonly ShopContext _shopContext;
            
        public ProductRepository(ShopContext shopContext, IOptions<AppSettings> options)
        {
            _shopContext = shopContext;
            _options = options;
            //if(!_shopContext.Products.Any())
            //    FillStubDb();
        }

        //private void FillStubDb()
        //{
        //    using (var reader = new StreamReader(_options.Value.StubSettings.StubDataFilePath))
        //    {
        //        var json = reader.ReadToEnd();
        //        var products = JsonConvert.DeserializeObject<List<Product>>(json);
        //        Save(products);
        //    }
        //} 

        public void Save(Product product)
        {
            var entity = _shopContext.Products.Find(product.Id);
            if (entity == null)
            {
                _shopContext.Add(product);
            }
            else
            {
                entity = product;
            }
            _shopContext.SaveChanges();
        }

        public void Save(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Save(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _shopContext.Products.ToList();
        }

        public Product Get(int id)
        {
            return _shopContext.Products.FirstOrDefault(p=>p.Id == id);
        }
    }
}