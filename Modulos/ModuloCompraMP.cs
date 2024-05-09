namespace biltiful.Modulos
{
    internal class ModuloCompraMP
    {

        void CadastrarMP()
        {
            Console.WriteLine("pega os dados para cadastro da MP");
            Console.WriteLine("faz trativas");
            Console.WriteLine("salva no arquivo tudo que for necessario");
        }

        void LocalizarMP()
        {
            Console.WriteLine("pega os dados para localizar MP");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo tudo que for necessario");
        }

        void ExcluirMP()
        {
            Console.WriteLine("pega os dados para excluir MP");
            Console.WriteLine("faz trativas");
            Console.WriteLine("exclui MP");
        }

        void ExibirMP()
        {
            Console.WriteLine("pega os dados para exibir MP");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo e exibe MP");
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Cadastrar MP");
            Console.WriteLine("[ 2 ] Localizar MP");
            Console.WriteLine("[ 3 ] Excluir MP");
            Console.WriteLine("[ 4 ] Exibir MP");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    CadastrarMP();
                    break;
                case 2:
                    LocalizarMP();
                    break;
                case 3:
                    ExcluirMP();
                    break;
                default:
                    ExibirMP();
                    break;
            }
        }

    }
}
