using ProductProgram.Model;
using System.Data.SqlClient;

namespace ProductProgram.DAO
{
    public class ProductDAO
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();

        public void ExecuteProductInsert(ProductModel product)
        {
            //connection with bd
            cmd.Connection = connection.Connect();
            
            SqlTransaction tran = connection.BeginTran();

            try
            {
                string parameters = "@name, @value, @type, @creationDate, @updateDate, @deletionDate";

                //Comando Sql --SqlCommand
                cmd.CommandText = ("insert into Product values (" + parameters + ")");

                //Parameters
                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@value", product.value);
                cmd.Parameters.AddWithValue("@type", (short)product.productType);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@updateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@deletionDate", DBNull.Value);

                //links with tran
                cmd.Transaction = tran;

                //exec cmd
                cmd.ExecuteNonQuery();

                //commit
                tran.Commit();

                //message
                Console.WriteLine("Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(ex);

                //Rollback
                tran.Rollback();
            }
            finally
            {
                //disconnect bd
                connection.Disconnect();
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> listProducts = new List<ProductModel>();

            try
            {
                SqlDataReader reader;

                SqlCommand cmd = new SqlCommand("[GetAllProducts]");

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = connection.Connect();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductModel model = new ProductModel();

                    model.id = Convert.ToInt32(reader["ProductId"]);
                    model.name = Convert.ToString(reader["Name"]);
                    model.value = Convert.ToSingle(reader["Value"]);
                    model.productType = (EnumProgram.Enums.ProductType)Convert.ToInt32(reader["Type"]);

                    listProducts.Add(model);
                }

                connection.Disconnect();

                return listProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(ex);
                return null;
            }
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel product = new ProductModel();

            try
            {
                SqlDataReader reader;

                SqlCommand cmd = new SqlCommand("[GetProductById]");

                cmd.Parameters.AddWithValue("@parameterId", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = connection.Connect();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductModel model = new ProductModel();

                    model.id = Convert.ToInt32(reader["ProductId"]);
                    model.name = Convert.ToString(reader["Name"]);
                    model.value = Convert.ToSingle(reader["Value"]);
                    model.productType = (EnumProgram.Enums.ProductType)Convert.ToInt32(reader["Type"]);

                    product = model;
                }

                connection.Disconnect();

                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdateProduct(ProductModel product, int productId)
        {
            //connection with bd
            cmd.Connection = connection.Connect();

            SqlTransaction tran = connection.BeginTran();

            try
            {
                //Comando Sql --SqlCommand
                SqlCommand cmd = new SqlCommand("[UpdateProduct]");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Parameters
                cmd.Parameters.AddWithValue("@parameterId", productId);
                cmd.Parameters.AddWithValue("@parameterName", product.name);
                cmd.Parameters.AddWithValue("@parameterValue", product.value);
                cmd.Parameters.AddWithValue("@parameterType", (short)product.productType);
                cmd.Parameters.AddWithValue("@parameterUpdateDate", DateTime.Now);

                //links with tran
                cmd.Transaction = tran;

                //exec cmd
                cmd.ExecuteNonQuery();

                //commit
                tran.Commit();

                //message
                Console.WriteLine("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(ex);

                //Rollback
                tran.Rollback();
            }
            finally
            {
                //disconnect bd
                connection.Disconnect();
            }
        }
    }
}
