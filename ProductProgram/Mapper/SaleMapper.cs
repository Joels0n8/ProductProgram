using ProductProgram.Model;
using ProductProgram.Validators;

namespace ProductProgram.Mapper
{
    public class SaleMapper
    {
        public SaleModel SaleDTO(int id, int qtd)
        {
            SaleValidator saleValidator = new SaleValidator();
            
            float saleValue = saleValidator.ValidateSale(id, qtd);

            if (saleValue > 0)
            {
                SaleModel saleMapper = new SaleModel();

                saleMapper.id = id;
                saleMapper.qtd = qtd;
                saleMapper.value = saleValue;

                return saleMapper;
            }

            else
                return null;
        }
    }
}
