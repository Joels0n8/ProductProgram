using ProductProgram.Bus;
using ProductProgram.DAO;
using ProductProgram.Model;

namespace ProductProgram.Transactional
{
    public class SaleTRA
    {
        public SaleTRA() { }
        public int SaveSale()
        {
            SaleBUS saleBUS = new SaleBUS();    
            string saleId;

            saleId = saleBUS.SaveSale();

            return int.Parse(saleId);
        }

        public void UpdateSaleValue(int saleId)
        {
            SaleBUS saleBUS = new SaleBUS();
            saleBUS.UpdateSaleValue(saleId);
        }
    }
}
