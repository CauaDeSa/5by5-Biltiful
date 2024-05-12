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

        void Pause()
        {
            Producao p = new Producao();
            p.Pause();
        }

        void LocalizarProducao(List<Producao> producoes, List<ItemProducao> itens)
        {
            Producao p = new Producao();

            p.LocalizarProducao(producoes, itens);
        }

        void ExcluirProducao(List<Producao> atual, List<ItemProducao> itensAtual)
        {
            Producao p = new Producao();
            ItemProducao i = new ItemProducao();    
            int id = p.RetornarIdExcluisao();

            List<Producao> producaos = p.ExcluirProducao(atual, id);
            List<ItemProducao> ip = i.ExcluirItem(itensAtual, id);

            prd.SalvarArquivoProd(producaos);
            itemprd.SalvarArquivoItemProd(ip);
        }

        void ExibirTodaProducao(List<Producao> producoes, List<ItemProducao> itens)
        {
            Producao p = new Producao();

            p.ImprimirProducao(producoes, itens);
        }

        public void Executar()
        {
            int opcao;
            do
            {
                opcao = -1;
                Console.Clear();
                Console.WriteLine("[ 1 ] Cadastrar Produção");
                Console.WriteLine("[ 2 ] Localizar Produção");
                Console.WriteLine("[ 3 ] Excluir Produção");
                Console.WriteLine("[ 4 ] Exibir todas as Produções");
                Console.WriteLine("[ 0 ] Sair da Produção");




                while (opcao < 0 || opcao > 4)
                {
                    try
                    {
                        opcao = int.Parse(Console.ReadLine());
                        if (opcao < 0 || opcao > 4)
                            Console.WriteLine(opcao + "Opção Inexistente");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Valor invalido!");
                    }

                }

                switch (opcao)
                {
                    case 1:
                        List<Producao> copiado = prd.CopiarArquivo();
                        List<ItemProducao> itemProducaoCopiado = itemprd.CopiarArquivoItemProducao();

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
                        Pause();
                        break;
                    case 2:
                        List<Producao> producoesLocaliza = prd.CopiarArquivo();
                        List<ItemProducao> itemProducaoLocaliza = itemprd.CopiarArquivoItemProducao();
                        LocalizarProducao(producoesLocaliza, itemProducaoLocaliza);
                        Pause();
                        break;
                    case 3:
                        List<Producao> preExclusao = prd.CopiarArquivo();
                        List<ItemProducao> itemPreExclusao = itemprd.CopiarArquivoItemProducao();
                        ExcluirProducao(preExclusao, itemPreExclusao);
                        Pause();
                        break;
                    case 4:
                        List<Producao> producoesExiste = prd.CopiarArquivo();
                        List<ItemProducao> itensProducao = itemprd.CopiarArquivoItemProducao();
                        ExibirTodaProducao(producoesExiste, itensProducao);
                        Pause();
                        break;
                    case 0:
                        Console.WriteLine("Saindo da Produção...");
                        Pause();
                        break;
                    default:
                        Console.WriteLine("Opção não existente!");
                        break;
                }
            } while (opcao != 0);
        }

    }
}
