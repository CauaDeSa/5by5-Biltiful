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
        internal double Quantidade;
        internal string Diretorio = @"C:\Biltiful\";
        internal string ArquivoProdutos = "Cosmetico.dat";
        internal string ArquivoProducao = "Producao.dat";
        internal ManipuladorArquivoPrd EditarArquivoProducao;
        internal ManipuladorArquivoPrd EditarArquivoProduto;

        public Producao()
        {
            this.EditarArquivoProducao = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoProducao);
            this.EditarArquivoProduto = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoProdutos);
        }

        public Producao(int id, DateOnly d, string p, double qtd)
        {
            this.Id = id;
            this.DataProducao = d;
            this.Produto = p;
            this.Quantidade = qtd;
        }

        public List<Producao> CopiarArquivo()
        {
            List<Producao> copia = new List<Producao>();

            foreach (var line in EditarArquivoProducao.LerArquivo())
            {
                if (line != "")
                {
                    string copiaId = line.Substring(0, 5);
                    string copiaData = line.Substring(5, 8);
                    string copiaProduto = line.Substring(13, 13);
                    string copiaQtd = line.Substring(26, 5).Insert(3, ",");
                    copiaData = copiaData.Substring(0, 2) + "/" + copiaData.Substring(2, 2) + "/" + copiaData.Substring(4, 4);

                    int parametroId = int.Parse(copiaId);
                    DateOnly parametroData = DateOnly.Parse(copiaData);
                    double parametroQtd = double.Parse(copiaQtd);
                    string parametroProduto = copiaProduto;

                    copia.Add(new Producao(parametroId, parametroData, parametroProduto, parametroQtd));
                }
            }
           
            return copia;
        }

        public string? VerificarProdutoExiste(string codBarras)
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

        int RetornarIdAtual(List <Producao> copia) // recebe a lista copiada como parametro
        {
            if (copia.Count != 0) 
            {
                Producao last = copia.Last();
                int lastId = last.Id;
                int currentId = lastId + 1;
                return currentId;
            }
            else
            {
                return 1;
            }
        }
        
        public Producao CadastrarProducao(List<Producao> copia) // recebe a lista que foi copiada para realizar o cadastro
        {
            Producao cadastro = new Producao();
            try
            {
                bool controle= false;
                int id = RetornarIdAtual(copia);
                DateOnly data;
                string nome;
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
                        nome = VerificarProdutoExiste(CodBarrasProduto);
                        if (nome != "")
                        {
                            Console.WriteLine($"Produção de: {nome}");
                            Console.WriteLine("Digite uma qtsd");
                            double qtd = double.Parse(Console.ReadLine());
                            controle = true;
                            data = DateOnly.FromDateTime(DateTime.Now);
                            
                            cadastro = new Producao(id, data, CodBarrasProduto, qtd);
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
                Console.WriteLine("O cadastro não foi possível");
                return null;
            }            
        }


        public void SalvarArquivoProd(List<Producao> atual)
        {
            StreamWriter sw = new StreamWriter(this.Diretorio + this.ArquivoProducao);
            foreach (var producao in atual)
            {
                string linha;
                linha = producao.Id.ToString().PadLeft(5, '0');
                linha = linha + (producao.DataProducao.ToString("ddMMyyyy"));
                linha = linha + producao.Produto;
                linha = linha + (producao.Quantidade.ToString("000.00").Remove(3,1));
                
                sw.WriteLine(linha);
            }
            sw.Close();
        }
    }
}

