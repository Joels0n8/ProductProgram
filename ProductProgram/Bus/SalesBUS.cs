using ProductProgram.DAO;
using ProductProgram.Model;

namespace ProductProgram.Bus
{
    internal class SalesBUS
    {
        public void SaveSales(SalesModel sales)
        {
            SalesDAO exec = new SalesDAO();
            exec.InsertSales(sales);
        }
    }
}
