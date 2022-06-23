using ProductProgram.Bus;
using ProductProgram.Mapper;
using ProductProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProgram.Transactional
{
    public class ProductTRA
    {
        public ProductTRA()
        {

        }
        public void UpdateProduct(int productId)
        {
            ProductModel product = new ProductModel();
            ProductBUS productBUS = new ProductBUS();
            ProductMapper productDTO = new ProductMapper();

            product = productBUS.GetProductById(productId);

            if(product == null)
                Console.WriteLine("Produto não encontrado, tente novamente");
            
            else
            {
                Console.WriteLine("Escreva o novo nome do produto: ");
                string name = string.Format(Console.ReadLine());

                Console.Write("Escreva o valor do novo produto: ");
                float value = float.Parse(Console.ReadLine());

                Console.Write("Escreva o tipo do novo produto(0 - Produto, 1 - Serviço): ");
                string type = string.Format(Console.ReadLine());

                product = productDTO.ProductDTO(name, value, type);

                productBUS.UpdateProduct(product, productId);
            }
        }
    }
}
