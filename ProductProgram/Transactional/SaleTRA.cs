using ProductProgram.Bus;
using ProductProgram.DAO;
using ProductProgram.Model;

namespace ProductProgram.Transactional
{
    public class SaleTRA
    {
        public void SaveSales(List<SaleModel> sales)
        {
            SaleModel saleTotal = new SaleModel();
            SaleBUS saleBUS = new SaleBUS();
            
            foreach (SaleModel sale in sales)
            {
                if (saleTotal.productsIds == null)
                {
                    saleTotal.value = 0;
                    saleTotal.productsIds = sale.id.ToString() + ";";
                }
                
                else
                {
                    if (!saleTotal.productsIds.Contains(sale.id.ToString()))
                    saleTotal.productsIds += (sale.id.ToString() + ";");
                }

                saleTotal.value += sale.value;
            }

            saleBUS.SaveSale(saleTotal);
        }
    }
}
