using ProductProgram.Model;
using ProductProgram.DAO;
using System.Data.SqlClient;

namespace ProductProgram.Bus
{
    internal class ProductBUS
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();

        public void SaveProduct(ProductModel product)
        {
            ProductDAO exec = new ProductDAO();

            exec.ExecuteProductInsert(product);
        }

        public List<ProductModel> GetAllProducts()
        {
            ProductDAO exec = new ProductDAO();

            return exec.GetAllProducts();
        }

        public ProductModel GetProductById(int id)
        {
            ProductDAO exec = new ProductDAO();

            return exec.GetProductById(id);
        }
    }
}
