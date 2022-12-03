using ProductProgram.Bus;

namespace ProductProgram.Validators
{
    public class ProductValidator
    {
        public ProductValidator()
        {

        }

        public void ValidateProduct(string name, float value, string type)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value.ToString()) || string.IsNullOrEmpty(type))
            {
                Console.WriteLine();
                throw new Exception("todos os campos do produto devem ser preenchidos");
            }

            ProductBUS productBUS = new ProductBUS();

            string? existentName = productBUS.GetProductExistentNameByName(name);

            if (!string.IsNullOrEmpty(existentName))
            {
                Console.WriteLine();
                throw new Exception("produto já cadastrado");
            }
        }
    }
}
