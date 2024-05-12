using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Utils;
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
            Id = int.Parse(data.Substring(0, 5).Replace(" ", ""));
            DataVenda = ConverterParaData(data.Substring(5, 8).Replace(" ", ""));
            Cliente = data.Substring(13, 11).Replace(" ", "");
            ValorTotal = int.Parse(data.Substring(24, 7).Replace(" ", ""));
        }
        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
        public string FormatarParaArquivo()
        {
            //String coNum = customerOrderLine.PadRight(5, 'x');
            return Id.ToString().PadRight(5,' ') + Formato.LimparFormatacao(DataVenda.ToString()).PadRight(8,' ') + Cliente.PadRight(11, ' ') + ValorTotal.ToString().PadRight(7, ' ');
        }
    }
}