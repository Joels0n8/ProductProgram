using System.Data.SqlClient;

namespace ProductProgram.DAO
{
    public class Conexao
    {
        SqlConnection connection = new SqlConnection();
        public Conexao()
        {
            connection.ConnectionString = "Data Source=JOE;Initial Catalog=solution;Integrated Security=True";
        }

        public SqlConnection Conect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
            return connection;
        }

        public void Disconect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
