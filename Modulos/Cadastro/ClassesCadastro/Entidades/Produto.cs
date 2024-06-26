﻿using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class Produto
    {
        public string CodigoDeBarras { get; set; }        //13  (0-12)
        public string Nome { get; set; }                  //20  (13-32)
        public string ValorVenda { get; set; }               //5   (33-37)
        public DateOnly DataUltimaVenda { get; set; }     //8   (38-45)
        public DateOnly DataCadastro { get; set; }        //8   (46-53)
        public char Situacao { get; set; }                //1   (54)

        public Produto(string codigoDeBarras, string nome, string valorVenda)
        {
            CodigoDeBarras = codigoDeBarras;
            Nome = nome.PadRight(20).Substring(0, 20);
            ValorVenda = $"{valorVenda:000.00}";
            DataUltimaVenda = DateOnly.FromDateTime(DateTime.Now); ;
            DataCadastro = DateOnly.FromDateTime(DateTime.Now); ;
            Situacao = 'A';
        }

        public Produto(string data)
        {
            CodigoDeBarras = data.Substring(0, 13);
            Nome = data.Substring(13, 20);
            ValorVenda = data.Substring(33, 5);

            DataUltimaVenda = Formato.ConverterParaData(data.Substring(38, 8));
            DataCadastro = Formato.ConverterParaData(data.Substring(46, 8));

            Situacao = char.Parse(data.Substring(54, 1));
        }

        public string FormatarParaArquivo()
        {
            return CodigoDeBarras + Nome + ValorVenda + Formato.LimparFormatacao(DataUltimaVenda.ToString()) + Formato.LimparFormatacao(DataCadastro.ToString()) + Situacao;
        }

        public override string ToString()
        {
            return $"Codigo de Barras: {CodigoDeBarras}\nNome: {Nome}\nValor de Venda: {ValorVenda}\nData ultima venda: {DataUltimaVenda}\nData cadastro: {DataCadastro}\nSituacao: {Situacao}";
        }
    }
}