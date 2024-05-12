using _5by5_Biltiful.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Venda.ClassesVenda
{
    internal class ManipularVenda : EditorArquivo
    {
        public ManipularVenda(string diretorio, string arquivo) : base(diretorio, arquivo)
        {
        }
        public void CadastrarVenda(Venda venda)
        {
            Escrever(new List<string> { venda.FormatarParaArquivo() });
        }
        public void CadastrarItemVenda(List<ItemVenda> itens)
        {
            List<string> itensFormatados = new List<string>();
            for (int i = 0; i < itens.Count; i++)
            {
                itensFormatados.Add(itens[i].FormatarParaArquivo());
            }

            Escrever(itensFormatados);
        }
        public void Localizar()
        {
            List<string> vendasArquivo = Ler();
            List<Venda> vendas = new List<Venda>();
            for (int i = 0; i< vendasArquivo.Count; i++)
            {
                vendas.Add(new Venda(vendasArquivo[i]));
            }          

        }
        public List<Venda> BuscarVendas()
        {
            List<string> vendasArquivo = Ler();
            List<Venda> vendas = new List<Venda>();
            for (int i = 0; i < vendasArquivo.Count; i++)
            {
                vendas.Add(new Venda(vendasArquivo[i]));
            }

            return vendas;

        }
        public void Excluir()
        {

        }
        public void ImprimirPorRegistro()
        {

        }
    }
}
