using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    class ProductService : IProductService
    {
        public Response<Product> CreateProduct(string name, decimal startPrice, decimal provision, int supplierId, DateTime timeInterval, decimal buyOutPrice, Enum type, string designer)
        {
            throw new NotImplementedException();
        }

        public Response<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Response<Product> Get(string productName)
        {
            throw new NotImplementedException();
        }

        public Response<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response<Product> UpdateProductDetail(string name, decimal startPrice, decimal provision, int supplierId, DateTime timeInterval, decimal buyOutPrice, Enum type, string designer)
        {
            throw new NotImplementedException();
        }
    }
}
