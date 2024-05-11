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
            mInadimplente = new(caminhoDiretorio, caminhoRisco);
            mBloqueado = new(caminhoDiretorio, caminhoBloqueado);
        }

        void SubModuloCliente()
        {
            Console.Write(@"----------- Cliente -----------

                            [ 1 ] Cadastrar
                            [ 2 ] Localizar
                            [ 3 ] Editar
                            [ 4 ] Imprimir
                            [ 0 ] Voltar");

            switch (IO.LerOpcao(4))
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
            }
        }

        void SubModuloFornecedor()
        {
            Console.Write(@"----------- Fornecedor -----------

                            [ 1 ] Cadastrar
                            [ 2 ] Localizar
                            [ 3 ] Editar
                            [ 4 ] Imprimir
                            [ 0 ] Voltar");

            switch (IO.LerOpcao(4))
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
            }
        }

        void SubModuloMateriaPrima()
        {
            Console.Write(@"----------- Matéria-prima -----------

                            [ 1 ] Cadastrar
                            [ 2 ] Localizar
                            [ 3 ] Editar
                            [ 4 ] Imprimir
                            [ 0 ] Voltar");

            switch (IO.LerOpcao(4))
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
        }

        void SubModuloProduto()
        {
            Console.Write(@"----------- Produto -----------

                            [ 1 ] Cadastrar
                            [ 2 ] Localizar
                            [ 3 ] Editar
                            [ 4 ] Imprimir
                            [ 0 ] Voltar");

            switch (IO.LerOpcao(4))
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
        }

        public void Executar()
        {
            Console.Clear();

            Console.Write(@"----------- CADASTRO -----------

                            [ 1 ] Cliente
                            [ 2 ] Fornecedor
                            [ 3 ] Matéria-prima
                            [ 4 ] Produto
                            [ 0 ] Voltar");

            switch (IO.LerOpcao(4))
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
        }
    }
}