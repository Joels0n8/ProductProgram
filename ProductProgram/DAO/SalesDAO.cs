using ProductProgram.Model;
using System.Data.SqlClient;

namespace ProductProgram.DAO
{
    public class SalesDAO
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();

        public void InsertSales(SalesModel sales)
        {
            //connection with bd
            cmd.Connection = connection.Connect();

            SqlTransaction tran = connection.BeginTran();

            try
            {
                //Comando Sql --SqlCommand
                cmd.CommandText = ("CreateSales");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Parameters
                cmd.Parameters.AddWithValue("@paramSaleId", sales.saleId);
                cmd.Parameters.AddWithValue("@paramProductId", sales.productId);
                cmd.Parameters.AddWithValue("@paramQuantidade", sales.qtd);
                cmd.Parameters.AddWithValue("@paramValue", sales.value);
                cmd.Parameters.AddWithValue("@paramCreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@paramUpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@paramDeletionDate", DBNull.Value);

                //links with tran
                cmd.Transaction = tran;

                //exec cmd
                cmd.ExecuteNonQuery();

                //commit
                tran.Commit();
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
