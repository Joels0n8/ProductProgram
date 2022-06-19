using System;
using ProductProgram.Model;
using ProductProgram.Transactional;
using ProductProgram.Mapper;
using ProductProgram.Validators;

namespace ProductProgram.Controllers
{
    public class MainBus
    {
        public static void SaveNewProduct()
        {
            try
            {
                ProductModel product = new ProductModel();
                ProductMapper productDTO = new ProductMapper();
                ProductTransactional productTRA = new ProductTransactional();
                ProductValidator productValidator = new ProductValidator();

                Console.Write("Escreva o nome do novo produto: ");
                string name = string.Format(Console.ReadLine());

                Console.Write("Escreva o valor do novo produto: ");
                float value = float.Parse(Console.ReadLine());

                Console.Write("Escreva o tipo do novo produto(0 - Produto, 1 - Serviço): ");
                string type = string.Format(Console.ReadLine());

                product = productDTO.ProducMapper(name, value, type);

                productTRA.SaveProduct(product);

                Console.WriteLine("Pressione Enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SaveNewSale()
        {
            Console.WriteLine("Qual produto você quer cadastrar venda? ");
            GetAllProductsAndServices();

            Console.Write("Id do produto/serviço: ");

            int id = Convert.ToInt32(Console.Read());
        }

        public static void GetAllProductsAndServices()
        {
            ProductTransactional productTRA = new ProductTransactional();
            List<ProductModel> productstList = new List<ProductModel>();

            productstList = productTRA.GetAllProducts();

            if (productstList.Count == 0)
            {
                Console.WriteLine("Aconteceu algum erro, pressione Enter para continuar");
            }
            else
            {
                Console.WriteLine();
                foreach (ProductModel product in productstList)
                {
                    Console.WriteLine("Id: " + product.Id + ";  Nome: " + product.Name +
                       ";   Valor: " + product.Value);
                }
            }

            Console.WriteLine("\nPressione Enter para voltar ao Menu");
            Console.ReadLine();
            Console.Clear();
        }
    }

}
