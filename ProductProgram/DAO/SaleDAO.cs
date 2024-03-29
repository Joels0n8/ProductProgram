﻿using System.Data.SqlClient;

namespace ProductProgram.DAO
{
    internal class SaleDAO
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();

        public string CreateSale()
        {
            //connection with bd
            cmd.Connection = connection.Connect();

            SqlTransaction tran = connection.BeginTran();
            
            try
            {
                //Comando Sql --SqlCommand
                cmd.CommandText = ("CreateSale");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Parameters
                cmd.Parameters.AddWithValue("@paramCreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@paramUpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@paramDeletionDate", DBNull.Value);

                //links tran
                cmd.Transaction = tran;

                //exec cmd
                var id = cmd.ExecuteScalar();

                //commit
                tran.Commit();

                return id.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
                Console.WriteLine(ex);
                tran.Rollback();

                return null;
            }
            finally
            {
                //disconnect bd
                connection.Disconnect();
            }
        }

        public void UpdateSaleValue(int saleId)
        {
            //connection with bd
            cmd.Connection = connection.Connect();

            SqlTransaction tran = connection.BeginTran();

            try
            {
                //Comando Sql
                cmd.CommandText = ("UpdateSaleValue");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Parameters
                cmd.Parameters.AddWithValue("@paramSaleId", saleId);

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
