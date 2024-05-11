using _5by5_Biltiful.Modulos.Producao.ClassesProducao;

namespace biltiful.Modulos
{
    internal class ModuloProducao
    {
        ManipuladorArquivoPrd mProducao;
        ManipuladorArquivoPrd mItemProducao;

        Producao prd = new Producao();
        ItemProducao itemprd = new ItemProducao();

        public ModuloProducao(string diretorio, string prd, string itemprd)
        {
            mProducao = new ManipuladorArquivoPrd(diretorio, prd);
            mItemProducao = new ManipuladorArquivoPrd(diretorio, itemprd);
        }
        List <ItemProducao> CadastrarItem(List<ItemProducao> copia, int id, DateOnly data)
        {
            ItemProducao i = new ItemProducao();


            List<ItemProducao> novo = i.CriaritemProducao(copia, id, data);

            return novo;

        }

        List <Producao> CadastrarCosmetico (List <Producao> copia)
        {
            Producao producao = new Producao();

            List <Producao> p1 = new List<Producao>();
            foreach (Producao p in copia)
                p1.Add(p);


            producao = producao.CadastrarProducao(p1);
            

            if (producao != null)
            {             
                
                p1.Add(producao);
            }
            return p1;
                       
        }

        void LocalizarCosmetico()
        {
            Console.WriteLine("pega os dados para localizar cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo tudo que for necessario");
        }

        void ExcluirCosmetico()
        {
            Console.WriteLine("pega os dados para excluir cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("exclui Cosmetico");
        }

        void ExibirCosmetico()
        {
            Console.WriteLine("pega os dados para exibir cosmetico");
            Console.WriteLine("faz trativas");
            Console.WriteLine("le do arquivo e exibe cosmetico");
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Cadastrar cosmetico");
            Console.WriteLine("[ 2 ] Localizar cosmetico");
            Console.WriteLine("[ 3 ] Excluir cosmetico");
            Console.WriteLine("[ 4 ] Exibir cosmetico");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    List<Producao> copiado = prd.CopiarArquivo();
                    List<ItemProducao> itemProducaoCopiado = itemprd.CopiarArquivoItemProducao() ;
                    
                    List<Producao> novo = CadastrarCosmetico(copiado);
                    List<ItemProducao> novoItemPrd = CadastrarItem(itemProducaoCopiado, novo.Last().Id, novo.Last().DataProducao);
                    if ((novo.Count > copiado.Count && novoItemPrd.Count > itemProducaoCopiado.Count))
                    {
                        prd.SalvarArquivoProd(novo);
                        itemprd.SalvarArquivoItemProd(novoItemPrd);
                    }
                    else
                    {
                        Console.WriteLine("cadastro não realizado");
                    }
                    
                    break;
                case 2:
                    LocalizarCosmetico();
                    break;
                case 3:
                    ExcluirCosmetico();
                    break;
                default:
                    ExibirCosmetico();
                    break;
            }
        }

    }
}
