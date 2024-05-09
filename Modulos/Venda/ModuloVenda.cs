namespace biltiful.Modulos
{
    internal class ModuloVenda
    {

        void CadastrarVenda()
        {
            Console.WriteLine("pega os dados para cadastro da venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("salva no arquivo tudo que for necessario");
        }

        void LocalizarVenda()
        {
            Console.WriteLine("pega os dados para localizar venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo tudo que for necessario");
        }

        void ExcluirVenda()
        {
            Console.WriteLine("pega os dados para excluir venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("exclui venda");
        }

        void ExibirVenda()
        {
            Console.WriteLine("pega os dados para exibir venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo e exibe venda");
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Cadastrar venda");
            Console.WriteLine("[ 2 ] Localizar venda");
            Console.WriteLine("[ 3 ] Excluir venda");
            Console.WriteLine("[ 4 ] Exibir venda");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    CadastrarVenda();
                    break;
                case 2:
                    LocalizarVenda();
                    break;
                case 3:
                    ExcluirVenda();
                    break;
                default:
                    ExibirVenda();
                    break;
            }
        }

    }
}
