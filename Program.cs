using biltiful.Modulos;

namespace biltiful
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[ 1 ] Módulo Registro");
            Console.WriteLine("[ 2 ] Módulo Venda");
            Console.WriteLine("[ 3 ] Módulo MP");
            Console.WriteLine("[ 4 ] Módulo Cosméticos");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    ModuloRegistro moduloRegistro = new();
                    moduloRegistro.Executar();
                    break;
                case 2:
                    ModuloVenda moduloVenda = new();
                    moduloVenda.Executar();
                    break;
                case 3:
                    ModuloCompraMP moduloMP = new();
                    moduloMP.Executar();
                    break;
                default:
                    ModuloCosmeticos moduloCosmeticos = new();
                    moduloCosmeticos.Executar();
                    break;
            }
        }
    }


}