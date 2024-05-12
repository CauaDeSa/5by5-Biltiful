using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
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

        public void Salvar(List<Fornecedor> fornecedores)
        {
            List<string> conteudo = new();

            foreach (Fornecedor fornecedor in fornecedores)
                conteudo.Add(fornecedor.ToString());

            Escrever(conteudo);
        }

        public void Cadastrar()
        {
            string cnpj, nome, endereco, telefone;

            Console.WriteLine(">>> CADASTRO DE FORNECEDOR <<<");

            Console.Write("Insira CNPJ: ");
            cnpj = Console.ReadLine();

            if (!ValidarFornecedor.CNPJ(cnpj))
            {
                Console.WriteLine("CNPJ inválido");
                return;
            }

            Console.Write("Insira Nome: ");
            nome = Console.ReadLine();

            Console.Write("Insira Endereço: ");
            endereco = Console.ReadLine();

            Console.Write("Insira Telefone: ");
            telefone = Console.ReadLine();

            List<Fornecedor> fornecedores = RecuperarArquivo();

            fornecedores.Add(new Fornecedor(cnpj, nome, endereco, telefone));

            Salvar(fornecedores);   
        }

        public void Editar()
        {
            string cnpj, nome, endereco, telefone;

            Console.WriteLine(" ---- EDIÇÃO DE FORNECEDORES ----");

            Console.Write("Insira CNPJ: ");
            cnpj = Console.ReadLine();

            List<Fornecedor> fornecedores = RecuperarArquivo();

            Fornecedor fornecedor = fornecedores.Find(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                Console.WriteLine("Fornecedor não encontrado");
                return;
            }

            Console.Write("Insira Nome: ");
            nome = Console.ReadLine();

            Console.Write("Insira Endereço: ");
            endereco = Console.ReadLine();

            Console.Write("Insira Telefone: ");
            telefone = Console.ReadLine();

            fornecedor.Nome = nome;
            fornecedor.Endereco = endereco;
            fornecedor.Telefone = telefone;

            Salvar(fornecedores);
        }

        public Fornecedor? BuscarPorCNPJ()
        {
            string cnpj;

            Console.WriteLine(" ---- BUSCA DE FORNECEDORES ----");

            Console.Write("Insira CNPJ: ");
            cnpj = Console.ReadLine();

            List<Fornecedor> fornecedores = RecuperarArquivo();

            return fornecedores.Find(f => f.CNPJ == cnpj);
        }
    }
}