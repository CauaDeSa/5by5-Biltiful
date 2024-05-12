using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularFornecedor : EditorArquivo
    {
        public ManipularFornecedor(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<Fornecedor> RecuperarArquivo()
        {
            List<Fornecedor> fornecedores = new();

            foreach (string linha in Ler())
                fornecedores.Add(new Fornecedor(linha));

            return fornecedores;
        }

        public void SalvarArquivo(List<Fornecedor> fornecedores)
        {
            List<string> conteudo = new();

            foreach (Fornecedor fornecedor in fornecedores)
                conteudo.Add(fornecedor.ToString());

            Escrever(conteudo);
        }

        public string LerCNPJ()
        {
            string cnpj;
            Console.Write("Insira o CNPJ: ");

            while (!ValidarFornecedor.CNPJ(cnpj = Console.ReadLine()))
                Console.Write("CNPJ inválido, tente novamente: ");

            return cnpj;
        }

        public string LerRazaoSocial()
        {
            string nome;
            Console.Write("Insira a razao social: ");

            while (ValidarFornecedor.RazaoSocial(nome = Console.ReadLine()))
                Console.Write("Razao social inválida, tente novamente: ");

            return nome;
        }

        public string LerDataAbertura()
        {
            string dataAbertura;
            Console.Write("Insira a data de abertura: ");

            while (!ValidarFornecedor.DataAbertura(dataAbertura = Console.ReadLine()))
                Console.Write("Data inválida, tente novamente: ");

            return dataAbertura;
        }

        public char LerSituacao()
        {
            char situacao;
            Console.Write("Insira a situacao (A/I): ");

            while (!char.TryParse(Console.ReadLine(), out situacao) || (situacao != 'A' && situacao != 'I'))
                Console.Write("Situacao invalida, tente novamente: ");

            return situacao;
        }

        public void Cadastrar()
        {
            string cnpjFornecedor, razaoSocial;
            DateOnly dataAbertura;

            List<Fornecedor> fornecedores = RecuperarArquivo();

            Console.WriteLine(">>> CADASTRO DE FORNECEDOR <<<");

            cnpjFornecedor = LerCNPJ();

            while (fornecedores.Exists(f => f.CNPJ == cnpjFornecedor))
            {
                Console.WriteLine("Fornecedor já cadastrado");
                cnpjFornecedor = LerCNPJ();
            }

            razaoSocial = LerRazaoSocial();

            dataAbertura = Formato.ConverterParaData(Formato.LimparFormatacao(LerDataAbertura()));

            fornecedores.Add(new Fornecedor(cnpjFornecedor, razaoSocial, dataAbertura));

            SalvarArquivo(fornecedores);
        }

        public void Editar()
        {
            Fornecedor? fornecedor;
            string cnpjFornecedor;
            int opcao;

            List<Fornecedor> fornecedores = RecuperarArquivo();

            Console.WriteLine(">>> EDIÇÃO DE FORNECEDORES <<<");

            cnpjFornecedor = LerCNPJ();

            fornecedor = fornecedores.Find(f => f.CNPJ == cnpjFornecedor);

            if (fornecedor == null)
            {
                Console.WriteLine("Fornecedor não encontrado");
                return;
            }

            Console.WriteLine($"Cliente encontrado: \n{fornecedor}\n\n");

            do
            {
                Console.WriteLine(@">>> Menu edicao <<<

                                    [ 1 ] Razao Social
                                    [ 2 ] Data Abertura
                                    [ 3 ] Situacao
                                    [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        fornecedor.RazaoSocial = LerRazaoSocial().PadRight(50).Substring(0, 50);
                        break;
                    case 2:
                        fornecedor.DataAbertura = Formato.ConverterParaData(Formato.LimparFormatacao(LerDataAbertura()));
                        break;
                    case 3:
                        fornecedor.Situacao = LerSituacao();
                        break;
                }
            } while (opcao != 0);

            SalvarArquivo(fornecedores);
        }

        public Fornecedor? BuscarPorCNPJ()
        {
            string cnpj;

            Console.WriteLine(" ---- BUSCA DE FORNECEDORES ----");

            cnpj = LerCNPJ();

            List<Fornecedor> fornecedores = RecuperarArquivo();

            return fornecedores.Find(f => f.CNPJ == cnpj);
        }

        public void Localizar()
        {
            Fornecedor? fornecedor = BuscarPorCNPJ();

            if (fornecedor == null)
            {
                Console.WriteLine("Fornecedor não encontrado");
                return;
            }

            Console.WriteLine($"\n{fornecedor}\n\n");
        }

        public void Imprimir()
        {
            List<Fornecedor> fornecedores = RecuperarArquivo();
            int opcao, indice;

            if (fornecedores.Count == 0)
            {
                Console.WriteLine("Nenhum fornecedor cadastrado");
                return;
            }

            indice = 0;

            do
            {
                Console.Clear();

                Console.WriteLine($"\n{fornecedores[indice]}\n\n");

                opcao = IO.LerOpcao(4);

                Console.WriteLine(@">>> Menu impressao <<<

                                [ 1 ] Proximo
                                [ 2 ] Anterior
                                [ 3 ] Inicio
                                [ 4 ] Final
                                [ 0 ] Voltar");

                switch (opcao)
                {
                    case 1:
                        indice = indice == fornecedores.Count - 1 ? 0 : indice + 1;
                        break;
                    case 2:
                        indice = indice == 0 ? fornecedores.Count - 1 : indice - 1;
                        break;
                    case 3:
                        indice = 0;
                        break;
                    case 4:
                        indice = fornecedores.Count - 1;
                        break;
                }
            } while (opcao != 0);
        }
    }
}