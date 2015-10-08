using Övningsuppgift_Lektion_3_OOADLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    class ProductService : IProductService
    {
        IProductRepository _repository;
        public Response<Product> CreateProduct(string name, decimal startPrice, decimal provision, int supplierId, DateTime timeInterval, decimal buyOutPrice, Enum type, string designer)
        {
            var response = new Response<Product>();
            if (_repository.Get(name) != null) response.Error = ErrorCode.DuplicateEntity;
            if (response.Success)
            {
                var product = new Product();
                product.Name = name;
                product.StartPrice = startPrice;
                product.Provision = provision;
                product.SupplierId = supplierId;
                product.TimeInterval = timeInterval;
                product.BuyoutPrice = buyOutPrice;
                product.Type = type;
                _repository.Save(product);
                response.Entity = product;
            }
            return response;
        }

        public Response<Product> DeleteProduct(int id)
        {
            var response = new Response<Product>();
            if (response.Success)
            {
                _repository.DeleteProduct(id);
            }
            return response;
        }

        public Response<Product> Get(string productName)
        {
            var response = new Response<Product>();
            response.Entity = _repository.Get(productName);
            return response;
        }

        public Response<Product> GetAll()
        {
            var response = new Response<Product>();
            response.EntityList = _repository.All();
            return response;
        }

        public Response<Product> GetById(int id)
        {
            var response = new Response<Product>();
            response.Entity = _repository.Get(id);
            return response;
        }

        public Response<Product> UpdateProductDetail(int id, string name, decimal startPrice, decimal provision, int supplierId, DateTime timeInterval, decimal buyOutPrice, Enum type, string designer)
        {
            var response = new Response<Product>();
            if (_repository.Get(name) != null) response.Error = ErrorCode.DuplicateEntity;
            if(response.Success)
            {
                var product = new Product();
                product.Id = id;
                product.Name = name;
                product.StartPrice = startPrice;
                product.Provision = provision;
                product.SupplierId = supplierId;
                product.TimeInterval = timeInterval;
                product.BuyoutPrice = buyOutPrice;
                product.Type = type;
                product.ProductDesigner = designer;
                _repository.UpdateProduct(product);                
            }
            return response;
        }
    }
}
