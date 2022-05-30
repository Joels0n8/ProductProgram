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

            exec.ExecuteProductInsert(product.Name, product.Value, ((short)product.productType));

            /*//Comando Sql --SqlCommand
            cmd.CommandText = "insert into Teste (Name, Value) values (@Name, @Value)";

            //Parameters
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Value", product.Value);

            //connection with bd
            try
            {
                cmd.Connection = connection.Conect();

                //exec cmd
                cmd.ExecuteNonQuery();
                   
                //desconect bd
                connection.Disconect();

                //show message of result
                this.message = "Cadastrado com sucesso!";
            }
            catch (SqlException ex)
            {
                this.message = ex.Message;
            }*/
        }

        public List<ProductModel> GetAllProducts()
        {
            ProductDAO exec = new ProductDAO();

            return exec.GetProductModels();
        }
    }
}
