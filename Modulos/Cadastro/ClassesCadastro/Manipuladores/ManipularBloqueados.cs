using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularBloqueados : EditorArquivo
    {
        public ManipularBloqueados(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<string> Recuperar()
        {
            List<string> cnpjFornecedores = new();

            foreach (string linha in Ler())
                cnpjFornecedores.Add(linha);

            return cnpjFornecedores;
        }

        public void Salvar(List<string> cnpjFornecedores)
        {
            Escrever(cnpjFornecedores);
        }

        public void Cadastrar()
        {

        }

        public void Editar()
        {

        }

        public Fornecedor? BuscarPorCNPJ()
        {

        }
    }
}
