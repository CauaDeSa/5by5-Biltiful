﻿using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class Fornecedor
    {
        public string CNPJ { get; set; }                //14 (0-13)
        public string RazaoSocial { get; set; }         //50 (14-63)
        public DateOnly DataAbertura { get; set; }      //8 (64-71)
        public DateOnly DataUltimaCompra { get; set; }  //8 (72-79)
        public DateOnly DataCadastro { get; set; }      //8 (80-87)
        public char Situacao { get; set; }              //1 (88-88)

        public Fornecedor(string cnpj, string razaoSocial, DateOnly dataAbertura)
        {
            CNPJ = Formato.LimparFormatacao(cnpj);
            RazaoSocial = razaoSocial.PadRight(50).Substring(0, 50);
            DataAbertura = dataAbertura;
            DataUltimaCompra = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public Fornecedor(string data)
        {
            CNPJ = data.Substring(0, 14);
            RazaoSocial = data.Substring(14, 50);

            DataAbertura = Formato.ConverterParaData(data.Substring(64, 8));
            DataUltimaCompra = Formato.ConverterParaData(data.Substring(72, 8));
            DataCadastro = Formato.ConverterParaData(data.Substring(80, 8));

            Situacao = char.Parse(data.Substring(88, 1));
        }

        public string FormatarParaArquivo()
        {
            return CNPJ + RazaoSocial + Formato.LimparFormatacao(DataAbertura.ToString()) + Formato.LimparFormatacao(DataUltimaCompra.ToString()) + Formato.LimparFormatacao(DataCadastro.ToString()) + Situacao;
        }

        public override string ToString()
        {
            return $"CNPJ: {CNPJ}\nRazao Social: {RazaoSocial}\nData de Abertura: {DataAbertura}\nData ultima compra: {DataUltimaCompra}\nData cadastro: {DataCadastro}\nSituacao: {Situacao}";
        }
    }
}