using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularBloqueados : EditorArquivo
    {
        public ManipularBloqueados(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<string> Recuperar()
        {
            base.Ler();


        }

        public void Salvar(List<string> cnpjFornecedores)
        {

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
