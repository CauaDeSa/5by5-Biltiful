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

        public void Cadastrar()
        {
            string cpf, nome, dataNascimento, sexo;

            Console.WriteLine(" ---- CADASTRO DE CLIENTES ----");
            
            do
            {
                Console.Write("Insira CPF: ");
                cpf = Console.ReadLine();

                if (!ValidarCliente.CPF(cpf))
                    Console.WriteLine("CPF inválido");

            } while (!ValidarCliente.CPF(cpf));

            do
            {
                Console.Write("Insira Nome: ");
                nome = Console.ReadLine();

                if (!ValidarCliente.Nome(nome))
                    Console.WriteLine("Nome inválido");

            } while (!ValidarCliente.Nome(nome));

            do
            {
                Console.Write("Insira Data de Nascimento: ");
                dataNascimento = Console.ReadLine();

                if (!ValidarCliente.DataNascimento(dataNascimento))
                    Console.WriteLine("Data de Nascimento inválida");

            } while (!ValidarCliente.DataNascimento(dataNascimento));

            do
            {
                Console.Write("Insira sexo: ");
                sexo = Console.ReadLine();

                if (!ValidarCliente.Sexo(sexo))
                    Console.WriteLine("Sexo inválido");

            } while (!ValidarCliente.Sexo(sexo))

            List<Cliente> clientes = RecuperarArquivo();

            clientes.Add(new Cliente(cpf, nome, dataNascimento, sexo));
            clientes.Sort((cliente1, cliente2) => cliente1.Nome.CompareTo(cliente2.Nome));

            SalvarArquivo(clientes);
        }

        public void Editar()
        {
            string cpf;

            Console.WriteLine("---- EDIÇÃO DE CLIENTES ----");

            do
            {
                Console.Write("Insira CPF: ");
                cpf = Console.ReadLine();

                if (!ValidarCliente.CPF(cpf))
                    Console.WriteLine("CPF inválido");

            } while (!ValidarCliente.CPF(cpf));

            List<Cliente> clientes = RecuperarArquivo();
            Cliente cliente = clientes.Find(cliente => cliente.CPF == cpf);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
                return;
            }

            Console.WriteLine("Cliente encontrado: " + cliente.Nome);



            switch (IO.LerOpcao(3))
            {
                case 1:
                    Console.Write("Insira Nome: ");
                    cliente.Nome = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Insira Data de Nascimento: ");
                    cliente.DataNascimento = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Insira sexo: ");
                    cliente.Sexo = Console.ReadLine();
                    break;
            }

            SalvarArquivo(clientes);
        }   

        public Cliente? BuscarPorCPF()
        {
            string cpf;

            Console.WriteLine(" ---- BUSCA DE CLIENTES ----");

            Console.Write("Insira CPF: ");
            cpf = Console.ReadLine();

            List<Cliente> clientes = RecuperarArquivo();

            return clientes.Find(cliente => cliente.CPF == cpf);
        }
    }
}