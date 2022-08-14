using ProductProgram.Model;
using ProductProgram.Validators;

namespace ProductProgram.Mapper
{
    public class SalesMapper
    {
        public SalesMapper() { }
        public SalesModel? SaleDTO(int saleId, int productId, int qtd)
        {
            SaleValidator saleValidator = new SaleValidator();
            
            float saleValue = saleValidator.ValidateSale(productId, qtd);

            if (saleValue > 0)
            {
                SalesModel salesMapper = new SalesModel();

                salesMapper.saleId = saleId;
                salesMapper.productId = productId;
                salesMapper.qtd = qtd;
                salesMapper.value = saleValue;

                return salesMapper;
            }

            else
                return null;
        }
    }
}
