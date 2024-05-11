using biltiful.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Producao.ClassesProducao
{
    internal class MainPrd
    {
        static void Main(string[] args)
        {
             string caminhoProducoes = "Producao.dat";
             string caminhoItensProducao = "ItemProducao.dat"; 
            string caminhoDiretorioProjeto = "C://Biltiful//";

            ModuloProducao moduloProducao = new(caminhoDiretorioProjeto, caminhoProducoes, caminhoItensProducao);

            int opcao;

            do
            {
                Console.Clear();

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    //case 1:
                    //    moduloCadastro.Executar();
                    //    break;
                    //case 2:
                    //    moduloVenda.Executar();
                    //    break;
                    //case 3:
                    //    moduloCompra.Executar();
                    //    break;
                    case 4:
                        moduloProducao.Executar();
                        break;
                }

            } while (opcao != 0);
        }
    }
}
