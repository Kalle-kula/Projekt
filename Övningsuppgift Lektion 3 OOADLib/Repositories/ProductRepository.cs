using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Repositories
{
    public class ProductRepository : IProductRepository
    {
        DAL.AuctionSystemDBDataContext db = new DAL.AuctionSystemDBDataContext();

        public List<Product> All()
        {
            var products = db.Products.Where(x => x.IsDeleted == null || x.IsDeleted == false);

            List<Product> lstProducts = new List<Product>();

            foreach (DAL.Product pt in products)
            {
                Product pd = new Product();
                pd.Id = pt.Id;
                pd.BuyoutPrice = pt.BuyoutPrice.HasValue ? pt.BuyoutPrice.Value : 0;
                pd.ProductDesigner = pt.ProductDesigner;
                pd.Provision = pt.Provision.HasValue ? pt.Provision.Value : 0;
                pd.StartPrice = pt.StartPrice.HasValue ? pt.StartPrice.Value : 0;
                pd.SupplierId = pt.SupplierId.HasValue ? pt.SupplierId.Value : 0;
                pd.Type = UtilityHelper.HelperClass.GetProductType(pt.TypeId.HasValue ? pt.TypeId.Value : 0);
                lstProducts.Add(pd);
            }

            return lstProducts;
        }

        public void DeleteProduct(int id)
        {
            DAL.Product p = db.Products.Where(x => x.Id == id).FirstOrDefault();

            if (p != null)
            {
                p.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public Product Get(string name)
        {
            var pt = db.Products.Where(x => x.Name == name && (x.IsDeleted == null || x.IsDeleted == false)).FirstOrDefault();

            if (pt != null)
            {
                Product pd = new Product();
                pd.Id = pt.Id;
                pd.BuyoutPrice = pt.BuyoutPrice.HasValue ? pt.BuyoutPrice.Value : 0;
                pd.ProductDesigner = pt.ProductDesigner;
                pd.Provision = pt.Provision.HasValue ? pt.Provision.Value : 0;
                pd.StartPrice = pt.StartPrice.HasValue ? pt.StartPrice.Value : 0;
                pd.SupplierId = pt.SupplierId.HasValue ? pt.SupplierId.Value : 0;
                pd.Type = UtilityHelper.HelperClass.GetProductType(pt.TypeId.HasValue ? pt.TypeId.Value : 0);
                return pd;
            }

            return null;
        }

        public Product Get(int id)
        {
            var pt = db.Products.Where(x => x.Id == id && (x.IsDeleted == null || x.IsDeleted == false)).FirstOrDefault();

            if (pt != null)
            {
                Product pd = new Product();
                pd.Id = pt.Id;
                pd.BuyoutPrice = pt.BuyoutPrice.HasValue ? pt.BuyoutPrice.Value : 0;
                pd.ProductDesigner = pt.ProductDesigner;
                pd.Provision = pt.Provision.HasValue ? pt.Provision.Value : 0;
                pd.StartPrice = pt.StartPrice.HasValue ? pt.StartPrice.Value : 0;
                pd.SupplierId = pt.SupplierId.HasValue ? pt.SupplierId.Value : 0;
                pd.Type = UtilityHelper.HelperClass.GetProductType(pt.TypeId.HasValue ? pt.TypeId.Value : 0);
                return pd;
            }

            return null;
        }

        public void Save(Product pt)
        {
            DAL.Product pd = new DAL.Product();
            pd.BuyoutPrice = pt.BuyoutPrice;
            pd.ProductDesigner = pt.ProductDesigner;
            pd.Provision = pt.Provision;
            pd.StartPrice = pt.StartPrice;
            pd.SupplierId = pt.SupplierId;
            pd.TypeId = (int)pt.Type;
            db.Products.InsertOnSubmit(pd);
            db.SubmitChanges();
        }

        public void UpdateProduct(Product pt)
        {
            DAL.Product pd = db.Products.Where(x => x.Id == pt.Id).FirstOrDefault();

            if (pd != null)
            {
                pd.Id = pt.Id;
                pd.BuyoutPrice = pt.BuyoutPrice;
                pd.ProductDesigner = pt.ProductDesigner;
                pd.Provision = pt.Provision;
                pd.StartPrice = pt.StartPrice;
                pd.SupplierId = pt.SupplierId;
                pd.TypeId = (int)pt.Type;
                db.SubmitChanges();
            }
        }
    }
}
