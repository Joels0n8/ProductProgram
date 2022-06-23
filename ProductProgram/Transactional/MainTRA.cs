using System;
using ProductProgram.Model;
using ProductProgram.Mapper;
using ProductProgram.Validators;
using ProductProgram.Bus;

namespace ProductProgram.Transactional
{
    public class MainTRA
    {
        public static void SaveNewProduct()
        {
            try
            {
                ProductModel product = new ProductModel();
                ProductMapper productDTO = new ProductMapper();
                ProductBUS productBUS = new ProductBUS();
                ProductValidator productValidator = new ProductValidator();

                Console.Write("Escreva o nome do novo produto: ");
                string name = string.Format(Console.ReadLine());

                Console.Write("Escreva o valor do novo produto: ");
                float value = float.Parse(Console.ReadLine());

                Console.Write("Escreva o tipo do novo produto(0 - Produto, 1 - Serviço): ");
                string type = string.Format(Console.ReadLine());

                product = productDTO.ProductDTO(name, value, type);

                productBUS.SaveProduct(product);

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

            List<SaleModel> sales = new List<SaleModel>();
            SaleMapper sale = new SaleMapper();
            SaleTRA saleTRA = new SaleTRA();

            int id;
            int qtd;
            char op;

            do
            {
                Console.Write("Id do produto/serviço vendido: ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantidade vendida: ");
                qtd = int.Parse(Console.ReadLine());

                sales.Add(sale.SaleDTO(id, qtd));

                Console.WriteLine("Cadastrar mais vendas? s/n");
                op = char.Parse(Console.ReadLine());
            }
            while (op != 'n');

            if (sales.Count > 0)
                saleTRA.SaveSale(sales);
        }

        public static void GetAllProductsAndServices()
        {
            ProductBUS productBUS = new ProductBUS();
            List<ProductModel> productstList = new List<ProductModel>();

            productstList = productBUS.GetAllProducts();

            if (productstList.Count == 0)
            {
                Console.WriteLine("Aconteceu algum erro, pressione Enter para continuar");
            }
            else
            {
                Console.WriteLine();
                foreach (ProductModel product in productstList)
                {
                    Console.WriteLine("Id: " + product.id + ";  Nome: " + product.name +
                       ";   Valor: " + product.value);
                }
            }
        }
    }

}
