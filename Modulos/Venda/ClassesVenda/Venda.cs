using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using System.Security.Cryptography;

namespace _5by5_Biltiful.Modulos.Venda.ClassesVenda
{
    internal class Venda
    {
        public int Id { get; set; }             //5  (0-4)
        public DateOnly DataVenda { get; set; }         //8  (5-12)
        public string Cliente { get; set; }                 //11 (13-23)
        public int ValorTotal { get; set; }             //7  (24-30)

        public Venda(int idVenda, DateOnly dataVenda, string cpfCliente, int valorTotal)
        {
            Id = idVenda;
            DataVenda = dataVenda;
            Cliente = cpfCliente;
            ValorTotal = valorTotal;
        }
        public Venda(string data)
        {
            Id = int.Parse(data.Substring(0, 5));
            DataVenda = ConverterParaData(data.Substring(5, 8));
            Cliente = data.Substring(13, 11);
            ValorTotal = int.Parse(data.Substring(24, 7));
        }
        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
        public string FormatarParaArquivo()
        {
            return Id + ";" + DataVenda + ";" + Cliente + ";" + ValorTotal;
        }
    }
}