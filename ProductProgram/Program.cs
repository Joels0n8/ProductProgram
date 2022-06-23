using System;
using ProductProgram.Model;
using ProductProgram.Transactional;
using ProductProgram.Mapper;
using ProductProgram.Validators;
using ProductProgram.Controllers;

namespace ProductProgram
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("Programa para cadastro de movimentação de produtos e serviços");

                Console.WriteLine("Menu");
                Console.WriteLine("1 - Cadastrar novo produto/serviço");
                Console.WriteLine("2 - Registrar venda produto/serviço");
                Console.WriteLine("3 - Todos os produtos e serviços");
                Console.WriteLine("4 - Encerrar");

                Console.Write("Escolha uma opção: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        MainBus.SaveNewProduct();
                        break;
                    case 2:
                        MainBus.SaveNewSale();
                        break;
                    case 3:
                        MainBus.GetAllProductsAndServices();
                        Console.WriteLine("\nPressione Enter para voltar ao Menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            while (option != 4);
        }
    }
}