using ProductProgram.Model;
using ProductProgram.Transactional;

namespace ProductProgram.Validators
{
    public class SaleValidator
    {
        public SaleValidator()
        {

        }

        public float ValidateSale(int id, int qtd)
        {
            ProductTRA productTRA = new ProductTRA();
            ProductModel productModel = new ProductModel();

            productModel = productTRA.GetProductById(id);

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
