namespace _5by5_Biltiful.Modulos.Venda
{
    internal class ItemVendaProduto
    {
        public int IdVenda { get; set; }             //5  (0-4)
        public string Produto { get; set; } //é o código de barras do produto  - 13 (5-17)
        public int Quantidade { get; set; }             //3 (18-20)
        public int ValorUnitário { get; set; }          //5  (21-25)
        public int ValorTotal { get; set; }             //6  (26-31)

        public ItemVendaProduto(int idVenda, string produto, int quantidade, int valorUnitário, int valorTotal)
        {
            IdVenda = idVenda;
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitário = valorUnitário;
            ValorTotal = valorTotal;
        }
        public ItemVendaProduto(string data)
        {
            IdVenda = int.Parse(data.Substring(0, 5));
            Produto = data.Substring(5, 17);
            Quantidade = int.Parse(data.Substring(3, 20));
            ValorUnitário = int.Parse(data.Substring(5, 25));
            ValorTotal = int.Parse(data.Substring(6, 31));
        }
        private DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
        public string FormatarParaArquivoVenda()
        {
            return IdVenda + Produto + Quantidade + ValorUnitário + ValorTotal;
        }
    }
}
