using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro;
using _5by5_Biltiful.Utils;

namespace biltiful.Modulos
{
    internal class ModuloCadastro
    {
        ManipularCliente mCliente;
        ManipularProduto mProduto;
        ManipularMateriaPrima mPrima;
        ManipularFornecedor mFornecedor;
        ManipularInadimplentes mInadimplente;
        ManipularBloqueados mBloqueado;

        public ModuloCadastro(string caminhoDiretorio, string caminhoCliente, string caminhoProduto, string caminhoPrima, string caminhoFornecedor, string caminhoRisco, string caminhoBloqueado)
        {
            mCliente = new(caminhoDiretorio, caminhoCliente);
            mProduto = new(caminhoDiretorio, caminhoProduto);
            mPrima = new(caminhoDiretorio, caminhoPrima);
            mFornecedor = new(caminhoDiretorio, caminhoFornecedor);
            mInadimplente = new(caminhoDiretorio, caminhoRisco, caminhoCliente);
            mBloqueado = new(caminhoDiretorio, caminhoBloqueado, caminhoFornecedor);
        }

        void SubModuloCliente()
        {
            int opcao;

            do
            {
                Console.WriteLine(@"
                               >>> Sub Menu Cliente <<<

                                [ 1 ] Cadastrar
                                [ 2 ] Localizar
                                [ 3 ] Editar
                                [ 4 ] Imprimir
                                [ 5 ] Sub menu Inadimplentes
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(5);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        mCliente.Cadastrar();
                        break;
                    case 2:
                        mCliente.Localizar();
                        break;
                    case 3:
                        mCliente.Editar();
                        break;
                    case 4:
                        mCliente.Imprimir();
                        break;
                    case 5:
                        SubModuloInadimplente();
                        break;
                }
            } while (opcao != 0);
        }

        void SubModuloInadimplente()
        {
            int opcao;

            do
            {
                Console.WriteLine(@"
                               >>> Sub Menu Inadimplentes <<<

                                [ 1 ] Adicionar
                                [ 2 ] Remover
                                [ 3 ] Localizar
                                [ 4 ] Imprimir
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        mInadimplente.Cadastrar();
                        break;
                    case 2:
                        mInadimplente.Remover();
                        break;
                    case 3:
                        mInadimplente.Localizar();
                        break;
                    case 4:
                        mInadimplente.Imprimir();
                        break;
                }
            } while (opcao != 0);
        }

        void SubModuloFornecedor()
        {
            int opcao;

            do
            {
                Console.WriteLine(@"
                               >>> Sub Menu Fornecedor <<<

                                [ 1 ] Cadastrar
                                [ 2 ] Localizar
                                [ 3 ] Editar
                                [ 4 ] Imprimir
                                [ 5 ] Sub menu Bloqueados
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(5);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        mFornecedor.Cadastrar();
                        break;
                    case 2:
                        mFornecedor.Localizar();
                        break;
                    case 3:
                        mFornecedor.Editar();
                        break;
                    case 4:
                        mFornecedor.Imprimir();
                        break;
                    case 5:
                        SubmoduloBloqueados();
                        break;
                }
            } while (opcao != 0);
        }

        void SubmoduloBloqueados()
        {
            int opcao;

            do
            {
                Console.WriteLine(@"
                               >>> Sub Menu Bloqueados <<<

                                [ 1 ] Adcionar
                                [ 2 ] Remover
                                [ 3 ] Localizar
                                [ 4 ] Imprimir
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        mBloqueado.Cadastrar();
                        break;
                    case 2:
                        mBloqueado.Remover();
                        break;
                    case 3:
                        mBloqueado.Localizar();
                        break;
                    case 4:
                        mBloqueado.Imprimir();
                        break;
                }
            } while (opcao != 0);
        }

        void SubModuloMateriaPrima()
        {
            int opcao;
            do
            {
                Console.WriteLine(@"
                               >>> Sub Menu Materia-prima <<<

                                [ 1 ] Cadastrar
                                [ 2 ] Localizar
                                [ 3 ] Editar
                                [ 4 ] Imprimir
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        mPrima.Cadastrar();
                        break;
                    case 2:
                        mPrima.Localizar();
                        break;
                    case 3:
                        mPrima.Editar();
                        break;
                    case 4:
                        mPrima.Imprimir();
                        break;
                }
            } while (opcao != 0);
        }

        void SubModuloProduto()
        {
            int opcao;
            do
            {
                Console.WriteLine(@"
                               >>> Sub Menu Produto <<<

                                [ 1 ] Cadastrar
                                [ 2 ] Localizar
                                [ 3 ] Editar
                                [ 4 ] Imprimir
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        mProduto.Cadastrar();
                        break;
                    case 2:
                        mProduto.Localizar();
                        break;
                    case 3:
                        mProduto.Editar();
                        break;
                    case 4:
                        mProduto.Imprimir();
                        break;
                }
            } while (opcao != 0);
        }

        public void Executar()
        {
            int opcao;
            Console.Clear();

            do
            {
                Console.WriteLine(@"
                               >>> MENU CADASTRO <<<

                                [ 1 ] Cliente
                                [ 2 ] Fornecedor
                                [ 3 ] Matéria-prima
                                [ 4 ] Produto
                                [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        SubModuloCliente();
                        break;
                    case 2:
                        SubModuloFornecedor();
                        break;
                    case 3:
                        SubModuloMateriaPrima();
                        break;
                    case 4:
                        SubModuloProduto();
                        break;
                }
            } while (opcao != 0);
        }
    }
}