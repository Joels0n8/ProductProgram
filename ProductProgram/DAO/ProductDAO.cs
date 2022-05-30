using ProductProgram.Model;
using System.Data.SqlClient;

namespace ProductProgram.DAO
{
    public class ProductDAO
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String message;

        public void ExecuteProductInsert(string name, string value, short type)
        {
            try
            {
                string parameters = "@Name, @Value, @Type, @CreationDate, @DeletionDate";

                //Comando Sql --SqlCommand
                cmd.CommandText = ("insert into Product values (" + parameters + ")");

                //Parameters
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Value", value);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@DeletionDate", DBNull.Value);

                //connection with bd
                cmd.Connection = connection.Conect();

                //exec cmd
                cmd.ExecuteNonQuery();

                //desconect bd
                connection.Disconect();

                //show message of result
                this.message = "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
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
                    model.Value = Convert.ToString(reader["Value"]);
                    model.productType = (EnumProgram.Enums.ProductType)Convert.ToInt32(reader["Type"]);

                    listProducts.Add(model);
                }
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
            }

            connection.Disconect();

            return listProducts;
        }
    }
}
