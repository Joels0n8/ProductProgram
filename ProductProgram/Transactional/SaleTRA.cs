using ProductProgram.DAO;
using ProductProgram.Model;

namespace ProductProgram.Transactional
{
    public class SaleTRA
    {
        public void SaveSale(List<SaleModel> sales)
        {
            SaleModel saleTotal = new SaleModel();
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

            SaleDAO exec = new SaleDAO();
            exec.ExecuteSaleInsert(saleTotal);
        }
    }
}
