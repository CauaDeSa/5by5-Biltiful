using _5by5_Biltiful.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Producao.ClassesProducao
{
    internal class ManipuladorArquivoPrd : EditorArquivo
    {
        public ManipuladorArquivoPrd(string d, string f) : base(d, f) { }   

        public List<string> LerArquivo()
        {
            return base.Ler();
        }


    }
}
