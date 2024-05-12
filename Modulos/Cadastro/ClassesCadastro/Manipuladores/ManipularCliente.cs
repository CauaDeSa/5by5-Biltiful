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
            char sexo;
            Console.Write("Insira o sexo (M/F): ");

            while (!ValidarCliente.Sexo(sexo = char.Parse(Console.ReadLine())))
                Console.Write("Sexo invalido, tente novamente: ");

            return sexo;
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

            Console.WriteLine(">>> CADASTRO DE CLIENTE <<<");

            cpf = LerCPF();
            while (RecuperarArquivo().Exists(cliente => cliente.CPF == cpf))
            {
                Console.WriteLine("CPF já cadastrado");
                cpf = LerCPF();
            }

            nome = LerNome().PadRight(50).Substring(0, 50);

            dataNascimento = Formato.ConverterParaData(Formato.LimparFormatacao(LerDataNascimento()));

            sexo = LerSexo();

            List<Cliente> clientes = RecuperarArquivo();

            clientes.Add(new Cliente(cpf + nome + dataNascimento + sexo));
            clientes.Sort((cliente1, cliente2) => cliente1.Nome.CompareTo(cliente2.Nome));

            SalvarArquivo(clientes);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void Editar()
        {
            List<Cliente> clientes = RecuperarArquivo();
            Cliente cliente;
            string cpfCliente;

            Console.WriteLine(">>> EDIÇÃO DE CLIENTE <<<");

            cpfCliente = LerCPF();

            cliente = clientes.Find(cliente => cliente.CPF == cpfCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
                return;
            }

            Console.WriteLine($"Cliente encontrado: \n{cliente.ToString()}\n\n");

            Console.WriteLine(@">>> Menu edicao <<<

                                [ 1 ] - Nome
                                [ 2 ] - Data de Nascimento
                                [ 3 ] - Sexo
                                [ 4 ] - Situacao");

            switch (IO.LerOpcao(3))
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

            SalvarArquivo(clientes);
        }   

        private Cliente? BuscarPorCPF()
        {
            string cpf;

            Console.WriteLine(">>> BUSCA DE CLIENTES <<<");

            Console.Write("Insira CPF: ");
            cpf = Console.ReadLine();

            List<Cliente> clientes = RecuperarArquivo();

            return clientes.Find(cliente => cliente.CPF == cpf);
        }

        public void Localizar()
        {
            Cliente? cliente = BuscarPorCPF();

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
                return;
            }

            Console.WriteLine(cliente.ToString());
        }
    }
}