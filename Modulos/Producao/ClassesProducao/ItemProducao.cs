using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Producao.ClassesProducao
{
    internal class ItemProducao
    {
        int Id;
        DateOnly DataProducao;
        string MateriaPrima;
        double QuantidadeMateriaPrima;
        internal string Diretorio = @"C:\Biltiful\";
        internal string ArquivoMateria = "Materia.dat";
        internal string ArquivoItemProducao = "ItemProducao.dat";
        internal ManipuladorArquivoPrd ManipularArquivoItemProducao;
        internal ManipuladorArquivoPrd ManipularArquivoMateriaPrima;

        public ItemProducao()
        {
            this.ManipularArquivoItemProducao = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoItemProducao);
            this.ManipularArquivoMateriaPrima = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoMateria);
        }
        public ItemProducao(int id, DateOnly dt, string mp, double qtd)
        {
            this.Id = id;
            this.DataProducao = dt;
            this.MateriaPrima = mp;
            this.QuantidadeMateriaPrima = qtd;
        }

        public List<ItemProducao> CopiarArquivoItemProducao()
        {
            List<ItemProducao> copia = new List<ItemProducao>();
            foreach (var line in ManipularArquivoItemProducao.LerArquivo())
            {
                if (line != "")
                {
                    string copiaId = line.Substring(0, 5);
                    string copiaData = line.Substring(5, 8);
                    string copiaMP = line.Substring(13, 6);
                    string copiaQtd = line.Substring(18, 5).Insert(3, ",");
                    copiaData = copiaData.Substring(0, 2) + "/" + copiaData.Substring(2, 2) + "/" + copiaData.Substring(4, 4);

                    int parametroId = int.Parse(copiaId);
                    DateOnly parametroData = DateOnly.Parse(copiaData);
                    double parametroQtd = double.Parse(copiaQtd);
                    string parametroProduto = copiaMP;

                    copia.Add(new ItemProducao(parametroId, parametroData, parametroProduto, parametroQtd));
                }
            }

            return copia;
        }
        


        public List<ItemProducao> CriaritemProducao(List <ItemProducao> copia, int id, DateOnly data)
        {
            List <ItemProducao> copiado = new List <ItemProducao>();

            foreach (var item in copia)
            {
                copiado.Add(item);
            }

            Console.WriteLine("Digite o número de materias primas que serão utilizadas na produção");
            int materiasPrimas = 0;
            do
            {
                try
                {
                    materiasPrimas = int.Parse(Console.ReadLine());
                    if (materiasPrimas < 2)
                    {
                        Console.WriteLine("Digite pelo menos 2 matérias primas");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Valor invalido!");
                }
            } while (materiasPrimas < 2);

            int count = 0;
            ItemProducao[] itensProduzidos = new ItemProducao[materiasPrimas];
            while (materiasPrimas != count)
            {   
                Console.WriteLine("Digite o código da materia prima (por exemplo: MP0001)");
                string codMP = Console.ReadLine();
                if (VerirficarMP(codMP))
                {
                    string nome = VerificarEAtiva(codMP);
                    if ( nome != "")
                    {
                        double qtd = 0;
                        do
                        {

                            try
                            {
                                Console.WriteLine($"Quanto de {nome} será usado na produção");
                                qtd = double.Parse(Console.ReadLine());
                                if (qtd <= 0 || qtd > 999.99)
                                {
                                    Console.WriteLine("Quantidade zerada/menor ou acima do maxímo(999,99)");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Digite um valor valido");
                            }
                        } while (qtd <= 0 || qtd > 999.99);

                        itensProduzidos[count] = new ItemProducao(id,data, codMP, qtd);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Materia Prima: {codMP} não ativa");
                    }
                }
                else
                {
                    Console.WriteLine($"Materia Prima: {codMP} não cadastrada");
                }
            }
            for (int i = 0; i < materiasPrimas; i++)
            {
                copiado.Add(itensProduzidos[i]);
            }

            if (copia.Count <  copiado.Count)
            {
                return copiado;
            }
            
            else
            {
                return copia;
            }

        }

        bool VerirficarMP(string codMP)
        {
            bool controle = false;
            foreach (var item in ManipularArquivoMateriaPrima.LerArquivo())
            {
                if (codMP == item.Substring(0,6))
                {
                    controle = true; 
                }
            }
            return controle;
        }
        string VerificarEAtiva(string codMP)
        {
            string nome = "";
            foreach (var item in ManipularArquivoMateriaPrima.LerArquivo())
            {
                if ("A" == item.Substring(42, 1) && codMP == item.Substring(0, 6))
                {
                    nome = item.Substring(6,20) ;
                }
            }
            return nome;
        }

        public void ImprimirItensProducao(List<ItemProducao> itens, int id)
        {
            
            foreach (var item in itens)
            {
                if (item.Id  == id)
                {
                    Console.Write("id Item Produção: " + item.Id.ToString().PadLeft(5,'0'));
                    Console.Write(" ,Data Item Produção" + item.DataProducao);
                    string nomeMP = VerificarEAtiva(item.MateriaPrima);
                    Console.Write($",nome matéria-prima: {nomeMP} e código: {item.MateriaPrima} ");
                    Console.WriteLine(" ,quantidade de matéria-prima utilizada: " + item.QuantidadeMateriaPrima);
                    Console.WriteLine();
                }
            }
        }

        public List<ItemProducao> ExcluirItem(List<ItemProducao> copia, int id)
        {
            List<ItemProducao> copiado = new List<ItemProducao>();

            foreach (var item in copia)
            {
                copiado.Add(item);
            }

            foreach (var item in copia)
            {
                if (item.Id.Equals(id))
                    copiado.Remove(item);
            }
            return copiado;
        }

        public void SalvarArquivoItemProd(List <ItemProducao> atual)
        {
            StreamWriter sw = new StreamWriter(this.Diretorio + this.ArquivoItemProducao);
            foreach (var item in atual)
            {
                string id = item.Id.ToString();
                string data = item.DataProducao.ToString("ddMMyyyy");
                string mp = item.MateriaPrima;
                string qtd = item.QuantidadeMateriaPrima.ToString("000.00").Remove(3, 1);

                string linha = (id.PadLeft(5, '0') + data + mp + qtd);
                sw.WriteLine(linha);    
            }
            sw.Close();
        }
    }
}

