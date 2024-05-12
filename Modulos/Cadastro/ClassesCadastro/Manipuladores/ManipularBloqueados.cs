using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularBloqueados : EditorArquivo
    {
        ManipularFornecedor mFornecedor;

        public ManipularBloqueados(string diretorio, string arquivoBloqueados, string arquivoFornecedores) : base(diretorio, arquivoBloqueados) { mFornecedor = new(diretorio, arquivoFornecedores); }

        public List<string> RecuperarArquivo()
        {
            List<string> cnpjFornecedores = new();

            foreach (string linha in Ler())
                cnpjFornecedores.Add(linha);

            return cnpjFornecedores;
        }

        public void SalvarArquivo(List<string> cnpjFornecedores)
        {
            Escrever(cnpjFornecedores);
        }

        public string LerCNPJ()
        {
            string cnpj;
            Console.Write("Insira o CNPJ: ");

            while (!ValidarFornecedor.CNPJ(cnpj = Console.ReadLine()))
                Console.Write("CNPJ inválido, tente novamente: ");

            return cnpj;
        }

        public void Cadastrar()
        {
            List<string> cnpjBloqueados = RecuperarArquivo();
            string cnpj;

            Console.WriteLine(">>> CADASTRO DE BLOQUEIO <<<");

            cnpj = LerCNPJ();

            if (cnpjBloqueados.Contains(cnpj))
            {
                Console.WriteLine("Este CNPJ já está bloqueado.");
                return;
            }

            cnpjBloqueados.Add(cnpj);

            Console.WriteLine("CNPJ cadastrado na lista de bloqueados!");

            SalvarArquivo(cnpjBloqueados);
        }

        public void Remover()
        {
            string cnpj;
            List<string> bloqueados = RecuperarArquivo();

            Console.WriteLine(">>> REMOCAO DE BLOQUEIO <<<");

            cnpj = LerCNPJ();

            if (!bloqueados.Contains(cnpj))
            {
                Console.WriteLine("Este CNPJ não consta como bloqueado.");
                return;
            }

            bloqueados.Remove(cnpj);

            Console.WriteLine("CNPJ removido da lista de bloqueados!");

            SalvarArquivo(bloqueados);
        }

        public Fornecedor? BuscarPorCNPJ()
        {
            string cnpj;
            List<string> bloqueados = RecuperarArquivo();

            Console.WriteLine(">>> BUSCA DE BLOQUEIO <<<");

            cnpj = LerCNPJ();

            if (!bloqueados.Contains(cnpj))
            {
                Console.WriteLine("Este CNPJ não consta como bloqueado.");
                return null;
            }

            return mFornecedor.RecuperarArquivo().Find(fornecedor => fornecedor.CNPJ.Equals(cnpj));
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
            List<string> bloqueados = RecuperarArquivo();

            if (bloqueados.Count == 0)
            {
                Console.WriteLine("Nenhum fornecedor bloqueado cadastrado");
                return;
            }

            foreach (var bloqueado in bloqueados)
                Console.WriteLine(bloqueado);
        }
    }
}