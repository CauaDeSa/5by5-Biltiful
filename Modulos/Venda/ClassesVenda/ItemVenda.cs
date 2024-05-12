using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Venda
{
    internal class ItemVenda
    {
        public int IdVenda { get; set; }             //5  (0-4)
        public string Produto { get; set; } //é o código de barras do produto  - 13 (5-17)
        public int Quantidade { get; set; }             //3 (18-20)
        public int ValorUnitario { get; set; }          //5  (21-25)
        public int ValorTotal { get; set; }             //6  (26-31)

        public ItemVenda(int idVenda, string produto, int quantidade, int valorUnitario, int valorTotal)
        {
            IdVenda = idVenda;
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
        }
        public ItemVenda(string data)
        {
            IdVenda = int.Parse(data.Substring(0, 5));
            Produto = data.Substring(5, 17);
            Quantidade = int.Parse(data.Substring(3, 20));
            ValorUnitario = int.Parse(data.Substring(5, 25));
            ValorTotal = int.Parse(data.Substring(6, 31));
        }
        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
        public string FormatarParaArquivo()
        {
            return IdVenda + ";" + Produto + ";" + Quantidade + ";" + ValorUnitario + ";" + ValorTotal;
        }
    }
}
