using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Producao.ClassesProducao
{
    internal class Producao
    {
        internal int Id;
        internal DateOnly DataProducao;
        internal string Produto;
        internal int Quantidade;
        internal string Diretorio = @"C:\Biltful\";
        internal string ArquivoProdutos = "Cosmetico.dat";
        internal string ArquivoProducao = "Producao.dat";
        internal ManipuladorArquivoPrd EditarArquivoProducao;
        internal ManipuladorArquivoPrd EditarArquivoProduto;

        public Producao()
        {
            this.EditarArquivoProducao = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoProducao);
            this.EditarArquivoProduto = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoProdutos);
        }

        public Producao(int id, DateOnly d, string p, int qtd)
        {
            this.Id = id;
            this.DataProducao = d;
            this.Produto = p;
            this.Quantidade = qtd;
        }

        public List<Producao> CopiaArquivo()
        {
            List<Producao> copia = new List<Producao>();

            foreach (var line in EditarArquivoProducao.LerArquivo())
            {
                if (line != "")
                {
                    string copiaId = line.Substring(0, 5);
                    string copiaData = line.Substring(5, 8);
                    string copiaProduto = line.Substring(13, 13);
                    string copiaQtd = line.Substring(26, 5);

                    int parametroId = int.Parse(copiaId);
                    DateOnly parametroData = DateOnly.Parse(copiaData);
                    int parametroQtd = int.Parse(copiaQtd);
                    string parametroProduto = copiaProduto;

                    copia.Add(new Producao(parametroId, parametroData, parametroProduto, parametroQtd));
                }
            }
           
            return copia;
        }

        public string? VerificaProdutoExiste(string codBarras)
        {
            string? nome = "";
            foreach (var produto in EditarArquivoProduto.LerArquivo())
            {
                if (produto.Substring(0,13) == codBarras)
                {
                    nome = produto.Substring(13, 20);
                }
            }

            return nome;
        }

        int RetornaIdAtual(List <Producao> copia) // recebe a lista copiada como parametro
        {
            Producao last = copia.Last();
            int lastId = last.Id;
            int currentId = lastId + 1;
            return currentId;
        }
        
        public Producao Cadastro(List<Producao> copia) // recebe a lista que foi copiada para realizar o cadastro
        {
            Producao cadastro = new Producao();
            try
            {
                bool controle= false;
                int id = RetornaIdAtual(copia);
                do
                {
                    Console.WriteLine("Digite o Codigo de barras do Produto que deseja produzir");
                    string CodBarrasProduto = Console.ReadLine();
                    if (CodBarrasProduto[0] != '7' || CodBarrasProduto[1] != '8' || CodBarrasProduto[2] != '9')
                    {
                        Console.WriteLine("Codigo invalido!");
                    }
                    else
                    {
                        string nome = VerificaProdutoExiste(CodBarrasProduto);
                        if (nome != "")
                        {
                            Console.WriteLine($"Produção de: {nome}");
                            controle = true;                            
                        }
                        else
                        {
                            Console.WriteLine("Codigo não existente!");
                        }
                    }

                } while (controle == false);

                
                return cadastro;

            }
            catch (Exception)
            {

                throw;
            }

            
        }


        public void SaveArquivoProd(List<Producao> atual)
        {
            StreamWriter sw = new StreamWriter(this.Diretorio + this.ArquivoProducao);
            foreach (var producao in atual)
            {
                string linha;
                linha = producao.Id.ToString().PadLeft(5, '0');
                linha = linha + (producao.DataProducao.ToString("ddmmyyyy"));
                linha = linha + producao.Produto;
                linha = linha + (producao.Quantidade.ToString().PadLeft(5, '0'));
                
                sw.WriteLine(linha);
            }
            sw.Close();
        }
    }
}

