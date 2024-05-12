using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Venda;
using _5by5_Biltiful.Modulos.Venda.ClassesVenda;
using System.ComponentModel;

namespace biltiful.Modulos
{
    internal class ModuloVenda
    {

        void CadastrarVenda()
        {
            Console.WriteLine(">>>CADASTRAR VENDA<<<");
            Console.WriteLine("Informe o CPF do cliente: ");
            string cpf = Console.ReadLine();

            ManipularCliente manipularCliente = new ManipularCliente(@"C:\Dados\", "Clientes.dat");
            Cliente? cliente = manipularCliente.BuscarPorCPF(cpf);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado. Informe outro CPF.");
                return; 
            }

            // validar idade
            var dataAtual = DateOnly.FromDateTime(DateTime.Now.Date);
            int idade = (dataAtual.Year - cliente.DataNascimento.Year); // todo: encontrar outra forma de fazer para considerar meses
            if (idade < 18)
            {
                Console.WriteLine("Venda não pode ser realizada - Cliente é menor de idade.");
                return; // todo: ver se pode ficar assim
            }

            // imprime cliente
            Console.WriteLine($"Cliente encontrado\n Nome: {cliente.Nome} - Data Nasc.: {cliente.DataNascimento.ToString("dd/MM/yyyy")}");

            string resposta;
            int cont = 0;
            int valorTotal = 0;
            List<ItemVenda> itens = new List<ItemVenda>();

            ManipularProduto manipularProduto = new ManipularProduto(@"C:\Dados\", "Cosmetico.dat");
            int idVenda = 1; //todo: fazer função que define o próximo ID a ser gravado

            do
            {
                Console.WriteLine("Informe o código de barras do produto:");   
                var codigoProduto = Console.ReadLine();
                Produto? produto = manipularProduto.BuscarPorCodigoBarras(codigoProduto);
                if (cliente == null)
                {
                    Console.WriteLine("Produto não encontrado. Informe outro código.");
                    return;
                }

                Console.WriteLine("Informe a quantidade do produto:");
                int quantidadeProduto = Int32.Parse(Console.ReadLine());
                if (quantidadeProduto > 999)
                {
                    Console.WriteLine("Quantidade máxima permitida é 999.");
                    return;
                }

                ItemVenda item = new ItemVenda(idVenda, codigoProduto, quantidadeProduto, produto.ValorVenda, (quantidadeProduto * produto.ValorVenda));
                itens.Add(item);

                cont++;
                Console.WriteLine("Deseja incluir mais um produto? S ou N");
                resposta = Console.ReadLine();

            } while (resposta == "S" || resposta == "s" && cont < 3);
            //no maximo 3 produtos
            Console.WriteLine("Valor total da venda: ");

            Venda venda = new Venda(idVenda, dataAtual, cpf, valorTotal);
            ManipularVenda manipularVenda = new ManipularVenda(@"C:\Dados\", "Venda.dat");
            manipularVenda.Escrever(new List<string> { venda.FormatarParaArquivo() });

            //todo:  escrever arquivo item venda

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
            Console.WriteLine("[ 3 ] IMPRIMIR VENDA");
            Console.WriteLine("[ 4 ] EXCLUIR VENDA");
            Console.WriteLine("[ 0 ] VOLTAR");

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
