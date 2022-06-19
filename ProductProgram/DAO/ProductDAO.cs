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
            try
            {
                string parameters = "@Name, @Value, @Type, @CreationDate, @UpdateDate, @DeletionDate";

                //Comando Sql --SqlCommand
                cmd.CommandText = ("insert into Product values (" + parameters + ")");

                //Parameters
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Value", product.Value);
                cmd.Parameters.AddWithValue("@Type", (short)product.productType);
                cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@DeletionDate", DBNull.Value);

                //connection with bd
                cmd.Connection = connection.Conect();

                //exec cmd
                cmd.ExecuteNonQuery();

                //desconect bd
                connection.Disconect();

                //message
                Console.WriteLine("Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
            }
        }

        public List<ProductModel> GetProductModels()
        {
            List<ProductModel> listProducts = new List<ProductModel>();

            try
            {
                SqlDataReader reader;

                SqlCommand cmd = new SqlCommand("[GetAllProducts]");

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = connection.Conect();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductModel model = new ProductModel();

                    model.Id = Convert.ToInt32(reader["ProductId"]);
                    model.Name = Convert.ToString(reader["Name"]);
                    model.Value = Convert.ToSingle(reader["Value"]);
                    model.productType = (EnumProgram.Enums.ProductType)Convert.ToInt32(reader["Type"]);

                    listProducts.Add(model);
                }

                connection.Disconect();

                return listProducts;
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
                return null;
            }
        }
    }
}
