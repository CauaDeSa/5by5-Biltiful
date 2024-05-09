namespace biltiful.Modulos
{
    internal class ModuloRegistro
    {

        void CadastrarCliente()
        {
            Console.WriteLine("Pega os dados do cliente");
            Console.WriteLine("Trata os dados");
            Console.WriteLine("Salva no arquivo");
        }

        void CadastrarFornecedor()
        {
            Console.WriteLine("Pega os dados do fornecedor");
            Console.WriteLine("Trata os dados");
            Console.WriteLine("Salva no arquivo");
        }

        void CadastrarMP()
        {
            Console.WriteLine("Pega os dados do matéria-prima");
            Console.WriteLine("Trata os dados");
            Console.WriteLine("Salva no arquivo");
        }

        void CadastrarProduto()
        {
            Console.WriteLine("Pega os dados do produto");
            Console.WriteLine("Trata os dados");
            Console.WriteLine("Salva no arquivo");
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Cadastrar cliente");
            Console.WriteLine("[ 2 ] Cadastrar fornecedor");
            Console.WriteLine("[ 3 ] Cadastro matéria-prima");
            Console.WriteLine("[ 4 ] Cadastrar produto");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao) {
                case 1:
                    CadastrarCliente();
                    break;
                case 2:
                    CadastrarFornecedor();
                    break;
                case 3:
                    CadastrarMP();
                    break;
                default:
                    CadastrarProduto();
                    break;
            }
        }

    }
}
