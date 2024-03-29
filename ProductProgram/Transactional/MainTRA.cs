﻿using ProductProgram.Model;
using ProductProgram.Mapper;
using ProductProgram.Validators;
using ProductProgram.Bus;
using System.Text.RegularExpressions;

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

            SalesModel sales = new SalesModel();
            SalesMapper salesDTO = new SalesMapper();
            SaleTRA saleTRA = new SaleTRA();
            SalesTRA salesTRA = new SalesTRA();

            int saleId = saleTRA.SaveSale();

            string productId;
            int qtd;
            char op;

            do
            {
                Console.Write("Id do produto/serviço vendido: ");
                productId = Console.ReadLine();

                Console.WriteLine("Quantidade vendida: ");
                qtd = int.Parse(Console.ReadLine());

                if (Regex.IsMatch(productId, "^\\d+$"))
                {
                    sales = salesDTO.SaleDTO(saleId, int.Parse(productId), qtd);

                    if (sales != null)
                        salesTRA.SaveSales(sales);
                }
                else
                {
                    throw new Exception("Id inválido");
                }

                Console.WriteLine("Cadastrar mais vendas? s/n");
                op = char.Parse(Console.ReadLine());
            }
            while (op != 'n');

            saleTRA.UpdateSaleValue(saleId);
        }

        public static void GetAllProductsAndServices()
        {
            ProductBUS productBUS = new ProductBUS();
            List<ProductModel> productstList = new List<ProductModel>();

            productstList = productBUS.GetAllProducts();

            if (productstList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Não existem produtos cadastrados");
            }
            else
            {
                Console.WriteLine();
                foreach (ProductModel product in productstList)
                {
                    Console.WriteLine("Id: " + product.id + ";  Nome: " + product.name + ";   Valor: " + product.value);
                }
            }
        }

        public static void UpdateProduct()
        {
            ProductTRA productTRA = new ProductTRA();

            Console.WriteLine("Lista de produtos:");
            GetAllProductsAndServices();

            Console.WriteLine("Qual o ID do produto você quer atualizar? ");
            int productId = int.Parse(Console.ReadLine());

            productTRA.UpdateProduct(productId);

            Console.Clear();
        }
    }

}
