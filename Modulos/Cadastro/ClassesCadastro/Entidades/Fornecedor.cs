namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class Fornecedor
    {
        public string CNPJ { get; set; }                //14 (0-13)
        public string RazaoSocial { get; set; }         //50 (14-63)
        public DateOnly DataAbertura { get; set; }      //8 (64-71)
        public DateOnly DataUltimaCompra { get; set; }  //8 (72-79)
        public DateOnly DataCadastro { get; set; }      //8 (80-87)
        public char Situacao { get; set; }              //1 (88-88)

        public Fornecedor(string cNPJ, string razaoSocial, DateOnly dataAbertura, DateOnly dataUltimaCompra, DateOnly dataCadastro, char situacao)
        {
            CNPJ = cNPJ;
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
            DataUltimaCompra = dataUltimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        //public class Fornecedor(string FornecedorEmFormatoArquivo)
        //{

        //}

        //public string FormatarParaArquivo()
        //{

        //}

        //static bool VerificarCodigoDeBarras(string codigo)
        //{

        //}
    }
}