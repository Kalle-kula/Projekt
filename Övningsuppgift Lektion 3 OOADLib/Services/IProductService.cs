using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    public interface IProductService
    {
        Response<Product> CreateProduct(string name, decimal startPrice, decimal provision,
            int supplierId, DateTime timeInterval, decimal buyOutPrice, Enum type, string designer);


        Response<Product> Get(string productName);

        Response<Product> GetById(int id);

        Response<Product> GetAll();

        Response<Product> UpdateProduct(int id, string name, decimal startPrice, decimal provision,
            int supplierId, DateTime timeInterval, decimal buyOutPrice, Enum type, string designer);

        Response<Product> DeleteProduct(int id);
    }
}
