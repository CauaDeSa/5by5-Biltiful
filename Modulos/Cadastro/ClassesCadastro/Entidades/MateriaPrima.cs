namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class MateriaPrima
    {
        public string Id { get; set; }                     //6  (0-5)
        public string Nome { get; set; }                   //20 (6-25)
        public DateOnly DataUltimaCompra { get; set; }     //8 (26-33)
        public DateOnly DataCadastro { get; set; }         //8 (34-41)
        public char Situacao { get; set; }                 //1 (42)

        public MateriaPrima(string id, string nome, DateOnly dataUltimaCompra, DateOnly dataCadastro, char situacao)
        {
            Id = id;
            Nome = FormatarNome(nome);
            DataUltimaCompra = dataUltimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public MateriaPrima(string data) 
        {
            Id = data.Substring(0, 6);
            Nome = data.Substring(6, 20);

            DataUltimaCompra = ConverterParaData(data.Substring(26, 8));
            DataCadastro = ConverterParaData(data.Substring(34, 8));

            Situacao = char.Parse(data.Substring(42, 1));
        }

        public string FormatarParaArquivo()
        {
            return Id + Nome + LimparFormatacao(DataUltimaCompra.ToString()) + LimparFormatacao(DataCadastro.ToString()) + Situacao;
        }

        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }

        static string FormatarNome(string nome)
        {
            for (int i = nome.Length; i < 50; i++)
                nome += " ";

            return nome.Substring(0, 50);
        }

        static string LimparFormatacao(string data)
        {
            return data.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");
        }
    }
}