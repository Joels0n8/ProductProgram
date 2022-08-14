using ProductProgram.DAO;
namespace ProductProgram.Bus
{
    internal class SaleBUS
    {
        public string SaveSale()
        {
            SaleDAO exec = new SaleDAO();

            return exec.CreateSale();
        }

        public void UpdateSaleValue(int saleId)
        {
            SaleDAO exec = new SaleDAO();

            exec.UpdateSaleValue(saleId);
        }
    }
}
