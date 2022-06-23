using ProductProgram.Transactional;

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
                Console.WriteLine("2 - Alterar produto/serviço");
                Console.WriteLine("3 - Registrar venda produto/serviço");
                Console.WriteLine("4 - Todos os produtos e serviços");
                Console.WriteLine("5 - Encerrar");

                Console.Write("Escolha uma opção: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        MainTRA.SaveNewProduct();
                        break;
                    case 2:
                        MainTRA.UpdateProduct();
                        break;
                    case 3:
                        MainTRA.SaveNewSale();
                        break;
                    case 4:
                        MainTRA.GetAllProductsAndServices();
                        Console.WriteLine("\nPressione Enter para voltar ao Menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            while (option != 5);
        }
    }
}