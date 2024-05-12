using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularCliente : EditorArquivo
    {
        public ManipularCliente(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<Cliente> RecuperarArquivo()
        {
            List<Cliente> clientes = new();

            foreach (string linha in Ler())
                clientes.Add(new Cliente(linha));

            return clientes;
        }

        public void SalvarArquivo(List<Cliente> clientes)
        {
            List<string> conteudo = new();

            clientes.Sort((cliente1, cliente2) => cliente1.Nome.CompareTo(cliente2.Nome));

            foreach (Cliente cliente in clientes)
                conteudo.Add(cliente.FormatarParaArquivo());

            Escrever(conteudo);
        }

        public string LerCPF()
        {
            string cpf;
            Console.Write("Insira o CPF: ");

            while (!ValidarCliente.CPF(cpf = Console.ReadLine()))
                Console.Write("CPF invalido, tente novamente: ");

            return cpf;
        }

        public string LerNome()
        {
            string nome;
            Console.Write("Insira o nome: ");

            while (ValidarCliente.Nome(nome = Console.ReadLine()))
                Console.Write("Nome invalido, tente novamente: ");

            return nome;
        }

        public string LerDataNascimento()
        {
            string dataNascimento;
            Console.Write("Insira a data de nascimento: ");

            while (!ValidarCliente.DataNascimento(dataNascimento = Console.ReadLine()))
                Console.Write("Data de nascimento invalida, tente novamente: ");

            return dataNascimento;
        }

        public char LerSexo()
        {
            string sexo;
            Console.Write("Insira o sexo (M/F): ");

            while (!ValidarCliente.Sexo(sexo = Console.ReadLine()))
                Console.Write("Sexo invalido, tente novamente: ");

            return char.Parse(sexo);
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
            string cpf, nome;
            DateOnly dataNascimento;
            char sexo;

            List<Cliente> clientes = RecuperarArquivo();

            Console.WriteLine(">>> CADASTRO DE CLIENTE <<<");

            cpf = LerCPF();

            while (clientes.Exists(cliente => cliente.CPF == cpf))
            {
                Console.WriteLine("CPF já cadastrado");
                cpf = LerCPF();
            }

            nome = LerNome();

            dataNascimento = Formato.ConverterParaData(Formato.LimparFormatacao(LerDataNascimento()));

            sexo = LerSexo();

            clientes.Add(new Cliente(cpf, nome, dataNascimento, sexo));

            SalvarArquivo(clientes);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void Editar()
        {
            List<Cliente> clientes = RecuperarArquivo();
            Cliente? cliente;
            string cpfCliente;
            int opcao;

            Console.WriteLine(">>> EDIÇÃO DE CLIENTE <<<");

            cpfCliente = LerCPF();

            cliente = clientes.Find(cliente => cliente.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
                return;
            }

            Console.WriteLine($"Cliente encontrado: \n{cliente}\n\n");

            do
            {
                Console.WriteLine(@">>> Menu edicao <<<

                                    [ 1 ] Nome
                                    [ 2 ] Data de Nascimento
                                    [ 3 ] Sexo
                                    [ 4 ] Situacao
                                    [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        cliente.Nome = LerNome().PadRight(50).Substring(0, 50);
                        break;
                    case 2:
                        cliente.DataNascimento = Formato.ConverterParaData(Formato.LimparFormatacao(LerDataNascimento()));
                        break;
                    case 3:
                        cliente.Sexo = LerSexo();
                        break;
                    case 4:
                        cliente.Situacao = LerSituacao();
                        break;
                }
            } while (opcao != 0);

            SalvarArquivo(clientes);
        }   

        private Cliente? BuscarPorCPF()
        {
            string cpf;

            Console.WriteLine(">>> BUSCA DE CLIENTES <<<");

            cpf = LerCPF();

            return RecuperarArquivo().Find(cliente => cliente.CPF == cpf);
        }

        public void Localizar()
        {
            Cliente? cliente = BuscarPorCPF();

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
                return;
            }

            Console.WriteLine($"\n{cliente}\n\n");
        }

        public void Imprimir()
        {
            List<Cliente> clientes = RecuperarArquivo();
            int opcao, indice;

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado");
                return;
            }

            indice = 0;

            do
            {
                Console.Clear();

                Console.WriteLine($"\n{clientes[indice]}\n\n");

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
                        indice = indice == clientes.Count - 1 ? 0 : indice + 1;
                        break;
                    case 2:
                        indice = indice == 0 ? clientes.Count - 1 : indice - 1;
                        break;
                    case 3:
                        indice = 0;
                        break;
                    case 4:
                        indice = clientes.Count - 1;
                        break;
                }
            } while (opcao != 0);
        }
    }
}