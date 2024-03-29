﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //urun varmis gibi davranmak icin //Global degiskenler alt cizgi ile kullanilir.

        public InMemoryProductDal()
        {
            //Oracle, SQL Server, MongoDB, PostGres
            _products = new List<Product> {
                new Product{ ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product{ ProductId = 2, CategoryId = 2, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product{ ProductId = 3, CategoryId = 3, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product{ ProductId = 4, CategoryId = 4, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product{ ProductId = 5, CategoryId = 5, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda(=>)
            
            Product productToDelete;
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //Bu blok tek tek dolasmaya yarar.

//          Her bir p icin productId'yi dolas ve sarti yerine getiriyor mu bak ve oyle ise esitle  demektir. 
//          SingleOrDefault tek bir eleman bulmaya yarar. Genelde id olan aramalarda bu kullanilir.
            
            _products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gonderdigim urun id'sine sahip olan urun id'sine sahip olan listedeki urunu bul demektir.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProdudctDetails()
        {
            throw new NotImplementedException();
        }
    }
}
