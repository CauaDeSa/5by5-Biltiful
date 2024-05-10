using System.ComponentModel.DataAnnotations;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    public class Cliente
    {
        public string CPF { get; set; }                  //11 (0-10)
        public string Nome { get; set; }                 //50 (11-60)
        public DateOnly DataNascimento { get; set; }     //8  (61-68)
        public char Sexo { get; set; }                   //1  (69-69)
        public DateOnly DataUltimaCompra { get; set; }   //8  (70-77)
        public DateOnly DataCadastro { get; set; }       //8  (78-85)
        public char Situacao { get; set; }               //1  (86-86)

        public Cliente(string cpf, string nome, DateOnly dataNascimento, char sexo, DateOnly dataUltimaCompra, DateOnly dataCadastro, char situacao)
        {
            CPF = LimparFormatacao(cpf);
            Nome = FormatarNome(nome);
            DataNascimento = dataNascimento;
            Sexo = sexo;
            DataUltimaCompra = dataUltimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public Cliente(string data)
        {
            CPF = data.Substring(0, 11);
            Nome = data.Substring(11, 50);

            DataNascimento = ConverterParaData(data.Substring(61, 8));
            DataUltimaCompra = ConverterParaData(data.Substring(70, 8));
            DataCadastro = ConverterParaData(data.Substring(78, 8));

            Sexo = char.Parse(data.Substring(69, 1));
            Situacao = char.Parse(data.Substring(86, 1));
        }

        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }

        public string FormatarParaArquivo()
        {
            return CPF + Nome + LimparFormatacao(DataNascimento.ToString()) + Sexo + LimparFormatacao(DataUltimaCompra.ToString()) + LimparFormatacao(DataCadastro.ToString()) + Situacao;
        }

        static string FormatarNome(string nome)
        {
            for (int i = nome.Length; i < 50; i++)
                nome += " ";

            return nome.Substring(0, 50);
        }

        public static string LimparFormatacao(string data)
        {
            return data.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");
        }
    }
}
