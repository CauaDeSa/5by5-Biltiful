using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularInadimplentes : EditorArquivo
    {
        public ManipularInadimplentes(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<string> Recuperar()
        {
            List<string> cnpjClientes = new();

            foreach (string linha in Ler())
                cnpjClientes.Add(linha);

            return cnpjClientes;
        }

        public void Salvar(List<string> cnpjClientes)
        {
            Escrever(cnpjClientes);
        }

        public void Adicionar()
        {

        }

        public void Remover()
        {

        }

        public Cliente? BuscarPorCPF()
        {

        }
    }
}
