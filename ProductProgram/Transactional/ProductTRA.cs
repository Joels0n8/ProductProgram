using ProductProgram.Model;
using ProductProgram.DAO;
using System.Data.SqlClient;

namespace ProductProgram.Transactional
{
    internal class ProductTransactional
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String message;

        public void SaveProduct(ProductModel product)
        {
            ProductDAO exec = new ProductDAO();

            exec.ExecuteProductInsert(product);
        }

        public List<ProductModel> GetAllProducts()
        {
            ProductDAO exec = new ProductDAO();

            return exec.GetProductModels();
        }
    }
}
