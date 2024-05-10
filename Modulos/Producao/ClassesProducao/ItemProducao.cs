using System;
using System.Collections.Generic;
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
        internal string Diretorio = @"C:\Biltful\";
        internal string ArquivoMaeria = "Materia.dat";
        internal string ArquivoItemProducao = "ItemProducao.dat";
        internal ManipuladorArquivoPrd EditarArquivoItemProducao;
        internal ManipuladorArquivoPrd EditarArquivoMateiraPrima;

        public ItemProducao()
        {
            this.EditarArquivoItemProducao = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoItemProducao);
            this.EditarArquivoMateiraPrima = new ManipuladorArquivoPrd(this.Diretorio, this.ArquivoMaeria);
        }
        public ItemProducao(int id,DateOnly dt ,string mp, double qtd)
        {
            this.Id = id;
            this.DataProducao = dt;
            this.MateriaPrima = mp;
            this.QuantidadeMateriaPrima= qtd;
        }

        public List <ItemProducao> CopiarArquivoItemProducao()
        {
            List<ItemProducao> copia = new List<ItemProducao>();
            foreach (var line in EditarArquivoItemProducao.LerArquivo())
            {                
                if (line != "")
                {
                    string copiaId = line.Substring(0, 5);
                    string copiaData = line.Substring(5, 8);
                    string copiaMP = line.Substring(13,6);
                    string copiaQtd = line.Substring(18,5).Insert(3, ",");

                    int parametroId = int.Parse(copiaId);
                    DateOnly parametroData = DateOnly.Parse(copiaData);
                    double parametroQtd = double.Parse(copiaQtd);
                    string parametroProduto = copiaMP;

                    copia.Add(new ItemProducao(parametroId, parametroData, parametroProduto, parametroQtd));
                }
            }

            return copia;
        }
    }
}

