using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public interface IProductRepository
    {
        Product Get(int id);

        Product Get(string name);

        void Save(Product user);

        List<Product> All();

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
