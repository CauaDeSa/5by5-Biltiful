using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularInadimplentes : EditorArquivo
    {
        ManipularCliente mCliente;
        public ManipularInadimplentes(string diretorio, string arquivoInadimplentes, string arquivoClientes) : base(diretorio, arquivoInadimplentes) { mCliente = new ManipularCliente(diretorio, arquivoClientes); }

        public List<string> RecuperarArquivo()
        {
            List<string> inadimplentes = new();

            foreach (string linha in Ler())
                inadimplentes.Add(linha);

            return inadimplentes;
        }

        public void SalvarArquivo(List<string> cpfs)
        {
            cpfs.Sort((cpf1, cpf2) => cpf1.CompareTo(cpf2));
            Escrever(cpfs);
        }

        public string LerCPF()
        {
            string cpf;
            Console.Write("Insira o CPF: ");

            while (!ValidarCliente.CPF(cpf = Console.ReadLine()))
                Console.Write("CPF invalido, tente novamente: ");

            return cpf;
        }

        public void Adicionar()
        {
            string cpf;
            List<string> inadimplentes = RecuperarArquivo();

            Console.WriteLine(">>> CADASTRO DE INADIMPLENCIA <<<");

            cpf = LerCPF();

            if (inadimplentes.Contains(cpf))
            {
                Console.WriteLine("CPF já cadastrado como inadimplente.");
                return;
            }

            inadimplentes.Add(cpf);

            Console.WriteLine("CPF cadastrado na lista de inadimplentes!");

            SalvarArquivo(inadimplentes);
        }

        public void Remover()
        {
            string cpf;
            List<string> inadimplentes = RecuperarArquivo();

            Console.WriteLine(">>> REMOCAO DE INADIMPLENCIA <<<");

            cpf = LerCPF();

            if (!inadimplentes.Contains(cpf))
            {
                Console.WriteLine("Este CPF não consta como inadimplente.");
                return;
            }

            inadimplentes.Remove(cpf);

            Console.WriteLine("CPF removido da lista de inadimplentes!");

            SalvarArquivo(inadimplentes);
        }

        public Cliente? BuscarPorCPF()
        {
            string cpf;
            List<string> inadimplentes = RecuperarArquivo();

            Console.WriteLine(">>> BUSCA DE INADIMPLENCIA <<<");

            cpf = LerCPF();

            if (!inadimplentes.Contains(cpf))
            {
                Console.WriteLine("Este CPF não consta como inadimplente.");
                return null;
            }

            return mCliente.RecuperarArquivo().Find(cliente => cliente.CPF.Equals(cpf));
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
            List<string> inadimplentes = RecuperarArquivo();

            if (inadimplentes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente inadimplente cadastrado");
                return;
            }

            foreach (var inadimplente in inadimplentes)
                Console.WriteLine(inadimplente);
        }
    }
}