using ProductProgram.Bus;
using ProductProgram.Model;

namespace ProductProgram.Validators
{
    public class SaleValidator
    {
        public SaleValidator()
        {

        }

        public float ValidateSale(int id, int qtd)
        {
            ProductBUS productBUS = new ProductBUS();
            ProductModel productModel = new ProductModel();

            productModel = productBUS.GetProductById(id);

            if(productModel == null)
            {
                Console.WriteLine("Id inexistente");

                return 0;
            }

            if (qtd < 0)
            {
                Console.WriteLine("a venda deve conter uma quantidade");

                return 0;                
            }

            return productModel.value * qtd;
        }
    }
}
