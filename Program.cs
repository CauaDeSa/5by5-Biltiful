using biltiful.Modulos;

namespace biltiful
{
    internal class Program
    {
        static int OpcaoMenu()
        {
            string? input;
            int opcao;
        
            do
            {
                do
                {
                    Console.WriteLine("[ 1 ] Módulo Registro");
                    Console.WriteLine("[ 2 ] Módulo Venda");
                    Console.WriteLine("[ 3 ] Módulo MP");
                    Console.WriteLine("[ 4 ] Módulo Cosméticos");
                    Console.WriteLine("[ 0 ] Sair");

                    Console.WriteLine("Selecione uma opcao valida: ");
                    input = Console.ReadLine();

                } while (int.TryParse(input, out opcao));
        
            } while (opcao < 0 || opcao > 4) ;

            return opcao;
        }

        static void Main(string[] args)
        {
            ModuloCadastro moduloCadastro = new("C://Biltiful//Cadastro//", "Clientes.dat", "Produto.dat", "Materia.dat", "Fornecedor.dat", "Risco.dat", "Bloqueado.dat");
            //ModuloVenda moduloVenda = new();
            //ModuloCompra moduloCompra = new();
            //ModuloProducao moduloProducao = new();

            int opcao;

            do
            {
                Console.Clear();

                opcao = OpcaoMenu();

                switch (opcao)
                {
                    case 1:
                        moduloCadastro.Executar();
                        break;
                    //case 2:
                    //    moduloVenda.Executar();
                    //    break;
                    //case 3:
                    //    moduloCompra.Executar();
                    //    break;
                    //case 4:
                    //    moduloProducao.Executar();
                    //    break;
                }

            } while (opcao != 0);
        }
    }
}