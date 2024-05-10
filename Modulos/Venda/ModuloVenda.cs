using System.ComponentModel;

namespace biltiful.Modulos
{
    internal class ModuloVenda
    {

        void CadastrarVenda()
        {
            Console.WriteLine(">>>CADASTRAR VENDA<<<");
            Console.WriteLine("Informe o CPF do cliente: ");
            int cpf = int.Parse(Console.ReadLine());
            string resposta;
            int cont = 0;
            //imprime na tela o nome e data de nascimento do cliente para fazer uma confirmação
            //e verificar se não esta bloqueado ou é menor de idade
            do
            {
                Console.WriteLine("Informe o código de barras do produto:");
                Console.WriteLine("Informe a quantidade do produto:");
                cont ++;
                Console.WriteLine("Deseja incluir mais um produto? S ou N");
                resposta = Console.ReadLine();

            }while (resposta == "S" || resposta == "s" && cont <3);
            //no maximo 3 produtos
            Console.WriteLine("Valor total da venda: ");
        }

        void LocalizarVenda()
        {
            Console.WriteLine(">>>LOCALIZAR VENDA<<<");
            Console.WriteLine("pega os dados para localizar venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo tudo que for necessario");
        }

        void ExibirVenda()
        {
            Console.WriteLine(">>>EXIBIR VENDA<<<");
            Console.WriteLine("pega os dados para exibir venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo e exibe venda");
        }
        void ExcluirVenda()
        {
            Console.WriteLine(">>>EXCLUIR VENDA<<<");
            Console.WriteLine("pega os dados para excluir venda");
            Console.WriteLine("faz trativas");
            Console.WriteLine("exclui venda");
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] CADASTRAR VENDA");
            Console.WriteLine("[ 2 ] LOCALIZAR VENDA");
            Console.WriteLine("[ 3 ] EXIBIR VENDA");
            Console.WriteLine("[ 4 ] EXCLUIR VENDA");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao inválida, tente novamente: ");
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
                    ExibirVenda();
                    break;
                case 4:
                    ExcluirVenda();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
