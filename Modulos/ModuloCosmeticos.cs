namespace biltiful.Modulos
{
    internal class ModuloCosmeticos
    {

        void CadastrarCosmetico()
        {
            Console.WriteLine("pega os dados para cadastro da cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("salva no arquivo tudo que for necessario");
        }

        void LocalizarCosmetico()
        {
            Console.WriteLine("pega os dados para localizar cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo tudo que for necessario");
        }

        void ExcluirCosmetico()
        {
            Console.WriteLine("pega os dados para excluir cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("exclui Cosmetico");
        }

        void ExibirCosmetico()
        {
            Console.WriteLine("pega os dados para exibir cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo e exibe cosmetico");
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Cadastrar cosmetico");
            Console.WriteLine("[ 2 ] Localizar cosmetico");
            Console.WriteLine("[ 3 ] Excluir cosmetico");
            Console.WriteLine("[ 4 ] Exibir cosmetico");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    CadastrarCosmetico();
                    break;
                case 2:
                    LocalizarCosmetico();
                    break;
                case 3:
                    ExcluirCosmetico();
                    break;
                default:
                    ExibirCosmetico();
                    break;
            }
        }

    }
}
