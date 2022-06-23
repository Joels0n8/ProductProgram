using ProductProgram.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProgram.DAO
{
    internal class SaleDAO
    {
        Conexao connection = new Conexao();
        SqlCommand cmd = new SqlCommand();

        public void ExecuteSaleInsert(SaleModel sale)
        {
            try
            {
                string parameters = "@productsIds, @value, @creationDate, @updateDate, @deletionDate";

                //Comando Sql --SqlCommand
                cmd.CommandText = ("insert into Sale   values (" + parameters + ")");

                //Parameters
                cmd.Parameters.AddWithValue("@productsIds", sale.productsIds);
                cmd.Parameters.AddWithValue("@value", sale.value);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@updateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@deletionDate", DBNull.Value);

                //connection with bd
                cmd.Connection = connection.Conect();

                //exec cmd
                cmd.ExecuteNonQuery();

                //desconect bd
                connection.Disconect();

                //message
                Console.WriteLine("Venda cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu algum erro");
            }
        }
    }
}
