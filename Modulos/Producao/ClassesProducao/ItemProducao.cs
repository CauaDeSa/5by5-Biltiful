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
        int QuantidadeMateriaPrima;
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
    }
}

