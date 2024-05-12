using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using Compras;
using System;

namespace biltiful.Modulos
{
    internal class ModuloCompra
    {
        private readonly string _caminhoArquivoCompras;
        private readonly string _caminhoArquivoItens;
        private readonly string caminhoDiretorio;

        public ModuloCompra(string caminhoDiretorioProjeto, string caminhoCompras, string caminhoItensCompra)
        {
            _caminhoArquivoCompras = caminhoCompras;
            _caminhoArquivoItens = caminhoItensCompra;
            caminhoDiretorio = caminhoDiretorioProjeto;
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Cadastrar MP");
            Console.WriteLine("[ 2 ] Localizar MP");
            Console.WriteLine("[ 3 ] Excluir MP");
            Console.WriteLine("[ 4 ] Exibir MP");

            int opcao = int.Parse(Console.ReadLine());

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opcao invalida, tente novamente: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    CadastrarMP();
                    break;
                case 2:
                    LocalizarMP();
                    break;
                case 3:
                    ExcluirMP();
                    break;
                default:
                    ExibirMP();
                    break;
            }
        }
        public void CadastrarMP()
        {
            // 1. Obter dados da compra do usuário
            Console.Write("Informe o ID da compra: ");
            int idCompra = int.Parse(Console.ReadLine());

            Console.Write("Informe a data da compra (dd/MM/yyyy): ");
            DateTime dataCompra = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            Console.Write("Informe o CNPJ do fornecedor: ");
            string cnpjFornecedor = Console.ReadLine();

            // 2. Criar um objeto Compra
            Compra compra = new Compra()
            {
                Id = idCompra,
                DataCompra = dataCompra,
                CnpjFornecedor = cnpjFornecedor,
                ItensCompras = new List<ItemCompra>()
            };

            // 3. Cadastrar itens da compra
            CadastrarItensCompra(compra);

            // 4. Salvar compra no arquivo
            SalvarCompra(compra);

            // 5. Exibir mensagem de sucesso
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
            // 1. Abrir arquivo de compras para escrita
            using (StreamWriter writerCompras = new StreamWriter(caminhoDiretorio + _caminhoArquivoCompras, append: true))
            {
                // 2. Escrever dados da compra no arquivo
                writerCompras.WriteLine($"{compra.Id},{compra.DataCompra},{compra.CnpjFornecedor}");
                // 3\. Salvar itens da compra no arquivo de itens
                SalvarItensCompra(compra.ItensCompras);
            }
        }

        public void SalvarItensCompra(List<ItemCompra> itensCompra)
        {
            // 1 Abrir arquivo de itens para escrita
            using (StreamWriter writerItens = new StreamWriter(caminhoDiretorio + _caminhoArquivoItens, append: true))
                // 2 Escrever dados de cada item no arquivo
                foreach (ItemCompra item in itensCompra)
                    writerItens.WriteLine($"{item.Descricao},{item.Quantidade},{item.ValorUnitario}");

        }

        public void LocalizarMP()
        {
            Console.Write("Informe o ID da compra para localizar: ");
            int idCompra = int.Parse(Console.ReadLine());

            // 1. Ler todas as compras do arquivo
            List<Compra> listaCompras = LerTodasAsCompras();

            // 2. Buscar a compra pelo ID informado
            Compra compraEncontrada = listaCompras.FirstOrDefault(c => c.Id == idCompra);

            if (compraEncontrada == null)
            {
                Console.WriteLine($"Compra com o ID {idCompra} não encontrada.");
            }
            else
            {
                // 3 Exibir os dados da compra encontrada
                Console.WriteLine($"Compra {compraEncontrada.Id} - {compraEncontrada.DataCompra.ToString("dd/MM/yyyy")}");
                Console.WriteLine("Fornecedor: " + compraEncontrada.CnpjFornecedor);
                Console.WriteLine("Valor Total: R$" + compraEncontrada.ValorTotal.ToString("F2"));
                Console.WriteLine("=====================================================");

                // 4. Exibir os itens da compra
                Console.WriteLine("\nItens da Compra:");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("| Nº | Descrição         | Quantidade | Valor Unit. | Valor Total |");
                Console.WriteLine("-----------------------------------------------------");

                foreach (ItemCompra item in compraEncontrada.ItensCompras)
                {
                    Console.WriteLine($"| {item.Descricao,-25} | {item.Quantidade,3} | R</span>{item.ValorUnitario,7:F2} | R${item.ValorTotalItem,7:F2} |");
                }
            }
        }
        public List<Compra> LerTodasAsCompras()
        {
            List<Compra> listaCompras = new List<Compra>();

            try
            {
                using (StreamReader reader = new StreamReader(caminhoDiretorio + _caminhoArquivoCompras))
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
                                //ItensCompras = CarregarItensCompra(compra.Id)
                            };
                            compra.ItensCompras = CarregarItensCompra(compra.Id);
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

            //string caminhoArquivoItens = Path.Combine(Path.GetDirectoryName(caminhoDiretorio + _caminhoArquivoCompras), $"itens_{idCompra}.txt");

            if (File.Exists(caminhoArquivoItens))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(caminhoDiretorio + caminhoArquivoItens))
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

            // 1. Ler todas as compras do arquivo (consider using existing function)
            List<Compra> listaCompras = LerTodasAsCompras();

            // 2. Localizar a compra pelo ID informado
            Compra compraParaExcluir = listaCompras.FirstOrDefault(c => c.Id == idCompra);

            if (compraParaExcluir == null)
            {
                Console.WriteLine($"Compra com o ID {idCompra} não encontrada.");
            }
            else
            {
                // 3. Confirmar exclusão com o usuário
                Console.WriteLine("\nConfirma a exclusão da compra {idCompra}? (S/N)");
                string confirmacao = Console.ReadLine().ToUpperInvariant();

                if (confirmacao == "S")
                {
                    // 4. Remover a compra da lista
                    listaCompras.Remove(compraParaExcluir);

                    // 5. Reescrever o arquivo de compras com a lista atualizada
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(caminhoDiretorio + _caminhoArquivoCompras, false)) 
                        {
                            foreach (Compra compra in listaCompras)
                            {
                                writer.WriteLine($"{compra.Id},{compra.DataCompra},{compra.CnpjFornecedor}");
                            }
                        }
                        // 6. Deletar o arquivo de itens associado
                        //string caminhoArquivoItens = Path.Combine(Path.GetDirectoryName(_caminhoArquivoCompras), $"itens_{idCompra}.txt");
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
            // 1. Ler todas as compras do arquivo
            List<Compra> listaCompras = LerTodasAsCompras();

            if (!listaCompras.Any())
            {
                Console.WriteLine("Nenhuma compra cadastrada.");
                return;
            }

            // 2. Exibir o cabeçalho da tabela
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("Lista de Compras");
            Console.WriteLine("=====================================================");
            Console.WriteLine("| Nº | Data da Compra | Fornecedor              |");
            Console.WriteLine("-----------------------------------------------------");

            // 3. Exibir cada compra resumidamente
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