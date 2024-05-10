﻿namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class Produto
    {
        public string CodigoDeBarras { get; set; }        //13  (0-12)
        public string Nome { get; set; }                  //20  (13-32)
        public int ValorVenda { get; set; }               //5   (33-37)
        public DateOnly DataUltimaVenda { get; set; }     //8   (38-45)
        public DateOnly DataCadastro { get; set; }        //8   (46-53)
        public char Situacao { get; set; }                //1   (54)

        public Produto(string codigoDeBarras, string nome, int valorVenda, DateOnly dataUltimaVenda, DateOnly dataCadastro, char situacao)
        {
            CodigoDeBarras = codigoDeBarras;
            Nome = FormatarNome(nome);
            ValorVenda = valorVenda;
            DataUltimaVenda = dataUltimaVenda;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public Produto(string data) 
        {
            CodigoDeBarras = data.Substring(0, 13);
            Nome = data.Substring(13, 20);
            ValorVenda = int.Parse(data.Substring(33, 5));

            DataUltimaVenda = ConverterParaData(data.Substring(38, 8));
            DataCadastro = ConverterParaData(data.Substring(46, 8));

            Situacao = char.Parse(data.Substring(54, 1));
        }

        public string FormatarParaArquivo()
        {
            return CodigoDeBarras + Nome + ValorVenda + LimparFormatacao(DataUltimaVenda.ToString()) + LimparFormatacao(DataCadastro.ToString()) + Situacao;
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
