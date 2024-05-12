namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class Produto
    {
        public string CodigoDeBarras { get; set; }        //13  (0-12)
        public string Nome { get; set; }                  //20  (13-32)
        public int ValorVenda { get; set; }               //5   (33-37)
        public DateOnly DataUltimaVenda { get; set; }     //8   (38-45)
        public DateOnly DataCadastro { get; set; }        //8   (46-53)
        public char Situacao { get; set; }                //1   (54)

        public Produto(string codigoDeBarras, string nome, int valorVenda, DateOnly dataUltimaVenda, DateOnly dataCadastro, char situacao)
        {
            CodigoDeBarras = codigoDeBarras;
            Nome = nome;
            ValorVenda = valorVenda;
            DataUltimaVenda = dataUltimaVenda;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public class Produto(string ProdutoEmFormatoArquivo)
        {

        }

        public string FormatarParaArquivo()
        {

        }

        static bool VerificarCodigoDeBarras(string codigo)
        {

        }
    }
}
