using ProductProgram.Bus;
using ProductProgram.Model;

namespace ProductProgram.Transactional
{
    public class SalesTRA
    {
        public SalesTRA() { }

        public void SaveSales(SalesModel sales)
        {
            SalesBUS salesBUS = new SalesBUS();

            salesBUS.SaveSales(sales);
        }
    }
}
