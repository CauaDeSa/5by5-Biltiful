using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacao;

namespace biltiful.Modulos
{
    internal class ModuloCadastro
    {
        ManipularCliente mCliente;
        ManipularProduto mProduto;
        ManipularMateriaPrima mPrima;
        ManipularFornecedor mFornecedor;
        ManipularInadimplentes mInadimplente;
        ManipularBloqueados mBloqueado;

        public ModuloCadastro(string caminhoDiretorio, string caminhoCliente, string caminhoProduto, string caminhoPrima, string caminhoFornecedor, string caminhoRisco, string caminhoBloqueado)
        {
            mCliente = new(caminhoDiretorio, caminhoCliente);
            mProduto = new(caminhoDiretorio, caminhoProduto);
            mPrima = new(caminhoDiretorio, caminhoPrima);
            mFornecedor = new(caminhoDiretorio, caminhoFornecedor);
            mInadimplente = new(caminhoDiretorio, caminhoRisco);
            mBloqueado = new(caminhoDiretorio, caminhoBloqueado);
        }

        void CadastrarCliente()
        {
            Console.WriteLine(" ---- CADASTRO DE CLIENTES ----");

            Console.Write("Insira CPF: ");
            cpf = ValidarCPF.VerificarCPF(Console.ReadLine());



        }

        void CadastrarFornecedor()
        {
            Console.WriteLine("Pega os dados do fornecedor");
            Console.WriteLine("Trata os dados");
            Console.WriteLine("Salva no arquivo");
        }

        void CadastrarMateriaPrima()
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

            Console.Write(@"[ 1 ] Cadastrar cliente
                            [ 2 ] Cadastrar fornecedor
                            [ 3 ] Cadastro matéria-prima
                            [ 4 ] Cadastrar produto
                            [ 0 ] Voltar");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 0 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    CadastrarCliente();
                    break;
                case 2:
                    CadastrarFornecedor();
                    break;
                case 3:
                    CadastrarMateriaPrima();
                    break;
                default:
                    CadastrarProduto();
                    break;
            }
        }

    }
}
