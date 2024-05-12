using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularProduto : EditorArquivo
    {
        public ManipularProduto(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<Produto> RecuperarArquivo()
        {
            List<Produto> produtos = new();

            foreach (string linha in Ler())
                produtos.Add(new Produto(linha));

            return produtos;
        }

        public void SalvarArquivo(List<Produto> produtos)
        {
            List<string> conteudo = new();

            produtos.Sort((produtoA, produtoB) => produtoA.Nome.CompareTo(produtoB.Nome))

            foreach (Produto produto in produtos)
                conteudo.Add(produto.ToString());

            Escrever(conteudo);
        }

        public string LerCodigoBarras()
        {
            string codigoBarras;
            Console.Write("Insira o Código de Barras: ");

            while (!ValidarProduto.CodigoBarras(codigoBarras = Console.ReadLine()))
                Console.Write("Código de Barras inválido, tente novamente: ");

            return codigoBarras;
        }

        public string LerNome()
        {
            string nome;
            Console.Write("Insira o nome: ");

            while (ValidarProduto.Nome(nome = Console.ReadLine()))
                Console.Write("Nome inválido, tente novamente: ");

            return nome;
        }

        public int LerValorVenda()
        {
            float valorVenda;
            Console.Write("Insira o preço: R$");

            while (ValidarProduto.ValorVenda(valorVenda = Console.ReadLine())))
                Console.Write("Preço inválido, tente novamente: R$");

            return float.Parse(valorVenda);
        }

        public void Cadastrar()
        {
            string codigoBarras, nome, descricao, valorVenda;

            Console.WriteLine(">>> CADASTRO DE PRODUTO <<<");

            codigoBarras = LerCodigoBarras();

            while (RecuperarArquivo().Exists(produto => produto.CodigoDeBarras.Equals(codigoBarras)))
            {
                Console.WriteLine("codigo já cadastrado");
                codigoBarras = LerCodigoBarras();
            }

            nome = LerNome();

            valorVenda = LerValorVenda();

            List<Produto> produtos = RecuperarArquivo();

            produtos.Add(new Produto(codigoBarras, nome, valorVenda));

            SalvarArquivo(produtos);
        }

        public char LerSituacao()
        {
            char situacao;
            Console.Write("Insira a situacao (A/I): ");

            while (!char.TryParse(Console.ReadLine(), out situacao) || (situacao != 'A' && situacao != 'I'))
                Console.Write("Situacao invalida, tente novamente: ");

            return situacao;
        }

        public void Editar()
        {
            string codigoBarras, nome, descricao, valorVenda;

            Console.WriteLine(">>> EDIÇÃO DE PRODUTOS <<<");

            codigoBarras = LerCodigoBarras();

            List<Produto> produtos = RecuperarArquivo();

            Produto produto = produtos.Find(p => p.CodigoDeBarras.Equals(codigoBarras));

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
                return;
            }

            Console.WriteLine($"Produto encontrado: \n{produto.ToString()}\n\n");

            do
            {
                Console.WriteLine(@">>> Menu edicao <<<

                                    [ 1 ] Nome
                                    [ 2 ] Valor venda
                                    [ 3 ] Situacao
                                    [ 0 ] Voltar");

                switch (IO.LerOpcao(3))
                {
                    case 1:
                        produto.Nome = LerNome().PadRight(20).Substring(0, 20);
                        break;
                    case 2:
                        produto.ValorVenda = LerValorVenda();
                    case 3: 
                        produto.Situacao = LerSituacao();
                        break;
                }
            } while (opcao != 0);

            SalvarArquivo(produtos);

            Console.WriteLine("Produto editado com sucesso!");
        }

        public Produto? BuscarPorCodigoBarras()
        {
            string codigoBarras;

            Console.WriteLine(">>> BUSCA DE PRODUTOS <<<");

            codigoBarras = LerCodigoBarras();

            return RecuperarArquivo().Find(p => p.CodigoDeBarras.Equals(codigoBarras)); ;
        }

        public void Localizar()
        {
            Produto? produto = BuscarPorCodigoBarras();

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
                return;
            }

            Console.WriteLine($"\n{produto.ToString()}\n\n");
        }

        public void Imprimir()
        {
            List<Produto> produtos = RecuperarArquivo();
            int option, indice;

            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado");
                return;
            }

            indice = 0;

            do
            {
                Console.Clear();

                Console.WriteLine($"\n{clientes[indice].ToString()}\n\n");

                option = IO.LerOpcao(4);

                Console.WriteLine(@">>> Menu impressao <<<

                                [ 1 ] Proximo
                                [ 2 ] Anterior
                                [ 3 ] Inicio
                                [ 4 ] Final
                                [ 0 ] Voltar");

                switch ()
                {
                    case 1:
                        indice = indice == clientes.Count - 1 ? 0 : indice + 1;
                        break;
                    case 2:
                        indice = indice == 0 ? clientes.Count - 1 : indice - 1;
                        break;
                    case 3:
                        indice = 0;
                        break;
                    case 4:
                        indice = clientes.Count - 1;
                        break;
                }
            } while (option != 0);
        }
    }
}
