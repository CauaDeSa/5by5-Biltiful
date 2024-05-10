using System.Security.Cryptography;

namespace _5by5_Biltiful.Modulos.Venda.ClassesVenda
{
    internal class VendaDeProduto
    {
        public int IdVenda { get; set; }             //5  (0-4)
        public DateOnly DataVenda { get; set; }         //8  (5-12)
        public string CPF { get; set; }                 //11 (13-23)
        public int ValorTotal { get; set; }             //7  (24-30)

        public VendaDeProduto(int idVenda, DateOnly dataVenda, string cpf, int valorTotal)
        {
            IdVenda = idVenda;
            DataVenda = dataVenda;
            CPF = cpf;
            ValorTotal = valorTotal;
        }

        public VendaDeProduto(string data)
        {
            IdVenda = int.Parse(data.Substring(0, 5));
            DataVenda = ConverterParaData(data.Substring(5, 8));
            CPF = data.Substring(13, 11);
            ValorTotal = int.Parse(data.Substring(24, 7));
        }
        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
        public string FormatarParaArquivoVenda()
        {
           // return IdVenda + DataVenda + CPF + ValorTotal;///fazer conversao
        }
    }

}