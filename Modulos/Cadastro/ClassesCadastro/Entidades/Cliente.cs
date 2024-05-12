using _5by5_Biltiful.Utils;

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

        public Cliente(string cpf, string nome, DateOnly dataNascimento, char sexo)
        {
            CPF = Formato.LimparFormatacao(cpf);
            Nome = nome.PadRight(50).Substring(0, 50);
            DataNascimento = dataNascimento;
            Sexo = sexo;
            DataUltimaCompra = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
        }

        public Cliente(string data)
        {
            CPF = data.Substring(0, 11);
            Nome = data.Substring(11, 50);

            DataNascimento = Formato.ConverterParaData(data.Substring(61, 8));
            DataUltimaCompra = Formato.ConverterParaData(data.Substring(70, 8));
            DataCadastro = Formato.ConverterParaData(data.Substring(78, 8));

            Sexo = char.Parse(data.Substring(69, 1));
            Situacao = char.Parse(data.Substring(86, 1));
        }

        public string FormatarParaArquivo()
        {
            return CPF + Nome + Formato.LimparFormatacao(DataNascimento.ToString()) + Sexo + Formato.LimparFormatacao(DataUltimaCompra.ToString()) + Formato.LimparFormatacao(DataCadastro.ToString()) + Situacao;
        }

        public override string ToString()
        {
            return $"CPF: {CPF}\nNome: {Nome}\nData de Nascimento: {DataNascimento}\nSexo: {Sexo}\nSituacao: {Situacao}";
        }
    }
}