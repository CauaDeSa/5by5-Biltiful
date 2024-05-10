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

        public Fornecedor(string cnpj, string razaoSocial, DateOnly dataAbertura, char situacao)
        {
            CNPJ = LimparFormatacao(cnpj);
            RazaoSocial = FormatarRazaoSocial(razaoSocial);
            DataAbertura = dataAbertura;
            DataUltimaCompra = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = situacao;
        }


        public Fornecedor(string data)
        {
            CNPJ = data.Substring(0, 14);
            RazaoSocial = data.Substring(14, 50);

            DataAbertura = ConverterParaData(data.Substring(64, 8));
            DataUltimaCompra = ConverterParaData(data.Substring(72, 8));
            DataCadastro = ConverterParaData(data.Substring(80, 8));

            Situacao = char.Parse(data.Substring(88, 1));
        }

        public string FormatarParaArquivo()
        {
            return CNPJ + RazaoSocial + LimparFormatacao(DataAbertura.ToString()) + LimparFormatacao(DataUltimaCompra.ToString()) + LimparFormatacao(DataCadastro.ToString()) + Situacao;
        } 

        static string FormatarRazaoSocial(string razaoSocial)
        {
            for (int i = razaoSocial.Length; i < 50; i++)
                razaoSocial += " ";

            return razaoSocial.Substring(0, 50);
        }

        static string LimparFormatacao(string data)
        {
            return data.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");
        }

        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
    }
}