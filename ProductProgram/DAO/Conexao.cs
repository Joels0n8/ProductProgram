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

        public SqlConnection Connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }

        public void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlTransaction BeginTran()
        {
            return connection.BeginTransaction();
        }
    }
}
