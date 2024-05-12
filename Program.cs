using biltiful.Modulos;

namespace biltiful
{
    internal class Program
    {
        static readonly string caminhoDiretorioProjeto = "C://Biltiful//";

        //MODULO 1 CADASTRO
        static readonly string caminhoClientes = "Clientes.dat";
        static readonly string caminhoProdutos = "Cosmetico.dat";
        static readonly string caminhoMateriasPrimas = "Materia.dat";
        static readonly string caminhoFornecedores = "Fornecedor.dat";
        static readonly string caminhoRiscos = "Risco.dat";
        static readonly string caminhoBloqueados = "Bloqueado.dat";

        //MODULO 2 VENDA
        static readonly string caminhoVendas = "Venda.dat";
        static readonly string caminhoItensVenda = "ItemVenda.dat";

        //MODULO 3 COMPRA
        static readonly string caminhoCompras = "Compra.dat";
        static readonly string caminhoItensCompra = "ItemCompra.dat";

        //MODULO 4 PRODUCAO
        static readonly string caminhoProducoes = "Producao.dat";
        static readonly string caminhoItensProducao = "ItemProducao.dat";

        static int OpcaoMenu()
        {
            string? input;
            int opcao;
        
            do
            {
                do
                {
                    Console.WriteLine("\n-- MENU PRINCIPAL --\n");

                    Console.WriteLine("[ 1 ] Secao Cadastro");
                    Console.WriteLine("[ 2 ] Secao Venda");
                    Console.WriteLine("[ 3 ] Secao Compra");
                    Console.WriteLine("[ 4 ] Secao Producao");
                    Console.WriteLine("[ 0 ] Sair");

                    Console.Write("Selecione uma opcao valida: ");
                    input = Console.ReadLine();

                } while (int.TryParse(input, out opcao));
        
            } while (opcao < 0 || opcao > 4) ;

            return opcao;
        }

        static void Main(string[] args)
        {
            ModuloCadastro moduloCadastro = new(caminhoDiretorioProjeto, caminhoClientes, caminhoProdutos, caminhoMateriasPrimas, caminhoFornecedores, caminhoRiscos, caminhoBloqueados);
            //ModuloVenda moduloVenda = new(caminhoDiretorioProjeto, caminhoVendas, caminhoItensVenda);
            ModuloCompra moduloCompra = new(caminhoDiretorioProjeto, caminhoCompras, caminhoItensCompra);
            //ModuloProducao moduloProducao = new(caminhoDiretorioProjeto, caminhoProducoes, caminhoItensProducao);

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