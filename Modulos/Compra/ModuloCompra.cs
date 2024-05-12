using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using Compras;
using System;
namespace biltiful.Modulos
{
    internal class ModuloCompra
    {
        static void Main(string[] args)
        {
            string caminhoDiretorio = ;
            string caminhoArquivoCompras = "";
            string caminhoArquivoItens = "";

            // Criar uma instância da classe Compras
            Compras compras = new Compras(caminhoDiretorio, caminhoArquivoCompras, caminhoArquivoItens);

            // Chamar o método Executar para iniciar o programa
            //compras.Executar();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 0 ] Sair do programa");
                Console.WriteLine("[ 1 ] Cadastrar Compras");
                Console.WriteLine("[ 2 ] Localizar Compras");
                Console.WriteLine("[ 3 ] Excluir Compras");
                Console.WriteLine("[ 4 ] Exibir Compras");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        // Encerrar o programa
                        return;
                    case 1:
                        compras.CadastrarMP();
                        break;
                    case 2:
                        compras.LocalizarMP();
                        break;
                    case 3:
                        compras.ExcluirMP();
                        break;
                    case 4:
                        compras.ExibirMP();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                // Aguardar o usuário pressionar uma tecla antes de fechar o programa
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
            }
        }
    }
    internal class Compras
    {
        private readonly string _caminhoArquivoCompras;
        private readonly string _caminhoArquivoItens;
        private readonly string _caminhoDiretorio;

        public Compras(string caminhoDiretorioProjeto, string caminhoCompras, string caminhoItensCompra)
        {
            _caminhoArquivoCompras = caminhoCompras;
            _caminhoArquivoItens = caminhoItensCompra;
            _caminhoDiretorio = caminhoDiretorioProjeto;

            if (!Directory.Exists(_caminhoDiretorio))
                Directory.CreateDirectory(_caminhoDiretorio);

            if (!File.Exists(Path.Combine(_caminhoDiretorio, _caminhoArquivoCompras)))
            {
                var aux = File.Create(Path.Combine(_caminhoDiretorio, _caminhoArquivoCompras));
                aux.Close();
            }
        }
        #region
        //public void Executar()
        //{
        //    Console.Clear();
        //    Console.WriteLine("[ 1 ] Cadastrar Compras");
        //    Console.WriteLine("[ 2 ] Localizar Compras");
        //    Console.WriteLine("[ 3 ] Excluir Compras");
        //    Console.WriteLine("[ 4 ] Exibir Compras");

        //    int opcao = int.Parse(Console.ReadLine());

        //    while (opcao < 1 || opcao > 4)
        //    {
        //        Console.Write("Opcao invalida, tente novamente: ");
        //        opcao = int.Parse(Console.ReadLine());
        //    }

        //    switch (opcao)
        //    {
        //        case 1:
        //            CadastrarMP();
        //            break;
        //        case 2:
        //            LocalizarMP();
        //            break;
        //        case 3:
        //            ExcluirMP();
        //            break;
        //        default:
        //            ExibirMP();
        //            break;
        //    }
        //}
        #endregion
        public void CadastrarMP()
        {
            // Obter dados da compra do usuário
            Console.Write("Informe o ID da compra: ");
            int idCompra = int.Parse(Console.ReadLine());

            Console.Write("Informe a data da compra (dd/MM/yyyy): ");
            DateTime dataCompra = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //usado quando você sabe exatamente
            //o formato da data que está sendo fornecida        //garantir que o formato seja interpretado exatamente
            //como especificado 

            Console.Write("Informe o CNPJ do fornecedor: ");
            string cnpjFornecedor = Console.ReadLine();

            //  Criar um objeto Compra
            Compra compra = new Compra()
            {
                Id = idCompra,
                DataCompra = dataCompra,
                CnpjFornecedor = cnpjFornecedor,
                ItensCompras = new List<ItemCompra>()
            };

            //  Cadastrar itens da compra
            CadastrarItensCompra(compra);

            //  Salvar compra no arquivo
            SalvarCompra(compra);

            //  Exibir mensagem de sucesso
            Console.WriteLine($"Compra {compra.Id} cadastrada com sucesso!");
        }
        public void CadastrarItensCompra(Compra compra)
        {
            int quantidadeItens;
            do
            {
                Console.Write("Quantos itens deseja cadastrar? ");
                quantidadeItens = int.Parse(Console.ReadLine());
            } while (quantidadeItens <= 0);
            for (int i = 0; i < quantidadeItens; i++)
            {
                Console.WriteLine($"\nItem {i + 1}:");

                ItemCompra item = new ItemCompra();
                item.SolicitarDadosItem();

                compra.ItensCompras.Add(item);
            }
        }

        public void SalvarCompra(Compra compra)
        {
            //  Abrir arquivo de compras para escrita
            using (StreamWriter writerCompras = new StreamWriter(_caminhoDiretorio + _caminhoArquivoCompras, append: true))
            {
                //  Escrever dados da compra no arquivo
                writerCompras.WriteLine($"{compra.Id},{compra.DataCompra},{compra.CnpjFornecedor}");
                //  Salvar itens da compra no arquivo de itens
                SalvarItensCompra(compra.ItensCompras);
            }
        }

        public void SalvarItensCompra(List<ItemCompra> itensCompra)
        {
            // Abrir arquivo de itens para escrita
            using (StreamWriter writerItens = new StreamWriter(_caminhoDiretorio + _caminhoArquivoItens, append: true))
                // Escrever dados de cada item no arquivo
                foreach (ItemCompra item in itensCompra)
                    writerItens.WriteLine($"{item.Descricao},{item.Quantidade},{item.ValorUnitario}");
        }

        public void LocalizarMP()
        {
            Console.Write("Informe o ID da compra para localizar: ");
            int idCompra = int.Parse(Console.ReadLine());

            // Ler todas as compras do arquivo
            List<Compra> listaCompras = LerTodasAsCompras();

            // Buscar a compra pelo ID informado
            Compra compraEncontrada = listaCompras.FirstOrDefault(c => c.Id == idCompra);

            if (compraEncontrada == null)
            {
                Console.WriteLine($"Compra com o ID {idCompra} não encontrada.");
            }
            else
            {
                //  Exibir os dados da compra encontrada
                Console.WriteLine($"Compra {compraEncontrada.Id} - {compraEncontrada.DataCompra.ToString("dd/MM/yyyy")}");
                Console.WriteLine("Fornecedor: " + compraEncontrada.CnpjFornecedor);
                Console.WriteLine("Valor Total: R$" + compraEncontrada.ValorTotal.ToString("F2"));
                Console.WriteLine("=====================================================");

                // Exibir os itens da compra
                //Console.WriteLine("\nItens da Compra:");
                //Console.WriteLine("-----------------------------------------------------");
                //Console.WriteLine("| Nº     | Descrição         | Quantidade | Valor Unit. | Valor Total |");
                //Console.WriteLine("-----------------------------------------------------");

                ExibirItensCompra(compraEncontrada.ItensCompras);
            }
        }
        public void ExibirItensCompra(List<ItemCompra> itensCompra)
        {
            if (itensCompra.Count == 0)
            {
                Console.WriteLine("Nenhum item encontrado para esta compra.");
            }
            else
            {
                Console.WriteLine("\nItens da Compra:");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("| Nº | Descrição          | Quantidade | Valor Unit. | Valor Total |");
                Console.WriteLine("-----------------------------------------------------");

                int contador = 1;
                foreach (ItemCompra item in itensCompra)
                {
                    Console.WriteLine($"| {contador,-3} | {item.Descricao,-20} | {item.Quantidade,10} | R${item.ValorUnitario,11:F2} | R${item.ValorTotalItem,11:F2} |");
                    contador++;
                }
            }
        }

        //foreach (ItemCompra item in compraEncontrada.ItensCompras)
        //{
        //    Console.WriteLine($"| {item.Descricao,-25} | {item.Quantidade,3} | R</span>{item.ValorUnitario,7:F2} | R${item.ValorTotalItem,7:F2} |");
        //}
        //int contador = 1;
        //        foreach (ItemCompra item in compraEncontrada.ItensCompras)
        //        {
        //            Console.WriteLine($"| {contador,-3} | {item.Descricao,-20} | {item.Quantidade,10} | R${item.ValorUnitario,11:F2} | R${item.ValorTotalItem,11:F2} |");
        //            contador++;
        //        }
        //    }
        //}
        public List<Compra> LerTodasAsCompras()
        {
            List<Compra> listaCompras = new List<Compra>();

            try
            {
                using (StreamReader reader = new StreamReader(_caminhoDiretorio + _caminhoArquivoCompras))
                {
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dadosCompra = linha.Split(',');

                        if (dadosCompra.Length == 3)
                        {
                            Compra compra = new Compra()
                            {
                                Id = int.Parse(dadosCompra[0]),
                                DataCompra = DateTime.Parse(dadosCompra[1]),
                                CnpjFornecedor = dadosCompra[2],
                                ItensCompras = CarregarItensCompra(int.Parse(dadosCompra[0]))
                            };
                            //compra.ItensCompras = CarregarItensCompra(compra.Id);
                            listaCompras.Add(compra);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo de compras: {ex.Message}");
            }
            return listaCompras;
        }

        public List<ItemCompra> CarregarItensCompra(int idCompra)
        {
            List<ItemCompra> itensCompra = new List<ItemCompra>();

            string caminhoArquivoItens = Path.Combine(_caminhoDiretorio, $"{_caminhoArquivoItens}_{idCompra}");
            //PATH = partes de caminhos de arquivo em uma única string
            //caminho de um arquivo em várias partes, como diretório, nome do arquivo e extensão.

            if (File.Exists(caminhoArquivoItens))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(_caminhoDiretorio + caminhoArquivoItens))
                    {
                        string linha;
                        while ((linha = reader.ReadLine()) != null)
                        {
                            string[] dadosItem = linha.Split(',');

                            if (dadosItem.Length == 3)
                            {
                                ItemCompra item = new ItemCompra()
                                {
                                    Descricao = dadosItem[0],
                                    Quantidade = int.Parse(dadosItem[1]),
                                    ValorUnitario = decimal.Parse(dadosItem[2])
                                };

                                itensCompra.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao ler o arquivo de itens da compra {idCompra}: {ex.Message}");
                }
            }

            return itensCompra;
        }

        public void ExcluirMP()
        {
            Console.Write("Informe o ID da compra para excluir: ");
            int idCompra = int.Parse(Console.ReadLine());

            //  Ler todas as compras do arquivo 
            List<Compra> listaCompras = LerTodasAsCompras();

            //  Localizar a compra pelo ID informado
            Compra compraParaExcluir = listaCompras.FirstOrDefault(c => c.Id == idCompra);

            if (compraParaExcluir == null)
            {
                Console.WriteLine($"Compra com o ID {idCompra} não encontrada.");
            }
            else
            {
                //  Confirmar exclusão com o usuário
                Console.WriteLine("\nConfirma a exclusão da compra {idCompra}? (S/N)");
                string confirmacao = Console.ReadLine().ToUpperInvariant();

                if (confirmacao == "S")
                {
                    // Remover a compra da lista
                    listaCompras.Remove(compraParaExcluir);

                    // Reescrever o arquivo de compras com a lista atualizada
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(_caminhoDiretorio + _caminhoArquivoCompras, false))
                        {
                            foreach (Compra compra in listaCompras)
                            {
                                writer.WriteLine($"{compra.Id},{compra.DataCompra},{compra.CnpjFornecedor}");
                            }
                        }
                        //  Deletar o arquivo de itens associado
                        string caminhoArquivoItens = Path.Combine(_caminhoDiretorio, $"{_caminhoArquivoItens}_{idCompra}");
                        //PATH = partes de caminhos de arquivo em uma única string
                        //caminho de um arquivo em várias partes, como diretório, nome do arquivo e extensão.

                        if (File.Exists(caminhoArquivoItens))
                        {
                            File.Delete(caminhoArquivoItens);
                        }
                        Console.WriteLine("Compra excluída com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nErro ao excluir a compra: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Exclusão cancelada.");
                }
            }
        }

        public void ExibirMP()
        {
            //  Ler todas as compras do arquivo
            List<Compra> listaCompras = LerTodasAsCompras();

            if (!listaCompras.Any())
            {
                Console.WriteLine("Nenhuma compra cadastrada.");
                return;
            }

            //  Exibir o cabeçalho da tabela
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("Lista de Compras");
            Console.WriteLine("=====================================================");
            Console.WriteLine("| Nº | Data da Compra | Fornecedor              |");
            Console.WriteLine("-----------------------------------------------------");

            //  Exibir cada compra resumidamente
            int contador = 1;
            foreach (Compra compra in listaCompras)
            {
                Console.WriteLine($"| {contador,2} | {compra.DataCompra.ToString("dd/MM/yyyy")} | {compra.CnpjFornecedor,-25} |");
                contador++;
            }

            Console.WriteLine("=====================================================");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}