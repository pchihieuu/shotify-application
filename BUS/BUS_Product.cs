using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_Product
    {
        DAL_Product dalProduct = new DAL_Product();

        public DataTable ListOfProducts()
        {
            return dalProduct.ListOfProducts();
        }

        public bool InsertProduct(DTO_Product product)
        {
            return dalProduct.InsertProduct(product);
        }

        public bool UpdateProduct(DTO_Product product)
        {
            return dalProduct.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return dalProduct.DeleteProduct(id);
        }

        public DataTable SearchProduct(string name)
        {
            return dalProduct.SearchProduct(name);
        }

        public string[] ListProductNameQuantity()
        {
            return dalProduct.ListProductNameQuantity();
        }

        public double GetUnitPrice(string name)
        {
            return dalProduct.GetUnitPrice(name);
        }

        public int GetProductId(string name)
        {
            return dalProduct.GetProductId(name);
        }
    }
}
