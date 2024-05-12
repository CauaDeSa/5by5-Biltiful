using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compras
{
    internal class ItemCompra
    {
        // Descrição do item
        public string Descricao { get; set; } // get e set permitem ler o valor da propriedade.

        // Quantidade do item
        public int Quantidade { get; set; }

        // Valor unidade item
        public decimal ValorUnitario { get; set; }

        // Valor total do item (quantidade x valor unidade)
        public decimal ValorTotalItem => Quantidade * ValorUnitario;


        // Método para solicitar e validar os dados do item ao usuário
        public void SolicitarDadosItem() // solicita ao usuário que insira os detalhes
        {
            Console.Write("Informe a descrição do item: ");
            Descricao = Console.ReadLine();

            //Console.Write("Informe a quantidade do item: ");
            int Quantidade;
            while (!int.TryParse(Console.ReadLine(), out Quantidade) || Quantidade <= 0 || Quantidade > 3) //um loop para que o usuário
                                                                                                           //insira a quantidade do item até que um inteiro
                                                                                                           //entre 1 e 3 seja inserido.
                                                                                                           //Verifica se a entrada do usuário pode ser analisada como um inteiro
            {
                Console.WriteLine("Quantidade inválida (máximo 3 itens). Digite um número inteiro positivo:");
                //Console.Write("Informe a quantidade do item: ");
            }
            //Console.Write("Informe o valor unitário do item: ");
            decimal ValorUnitario;
            while (!decimal.TryParse(Console.ReadLine(), out ValorUnitario) || ValorUnitario <= 0) //um loop para que o usuário
                                                                                                   //insira a quantidade do item até que um decimal
                                                                                                   //maior que 0 seja inserido.
            {
                Console.WriteLine("Valor unitário inválido. Digite um valor decimal positivo.");
                //Console.Write("Informe o valor unitário do item: ");
            }
        }

        // Método para salvar os dados de um arquivo
        public void SalvarDados(string arquivo) // recebe um parâmetro arquivo que representa
                                                // o caminho do arquivo onde os dados do item serão salvos.
        {
            try // possíveis exceções
            {
                using (StreamWriter writer = new StreamWriter(arquivo, append: true)) //StreamWriter é usado para gravar texto em um arquivo
                                                                                      //arquivo = caminho do arquivo no qual o objeto StreamWriter irá gravar
                                                                                      //append: true indica que novos dados devem ser escritos no final do arquivo
                                                                                      // garante que o arquivo seja fechado automaticamente quando o bloco using termina
                {
                    writer.WriteLine($"{Descricao},{Quantidade},{ValorUnitario}"); // gravar uma linha no arquivo contendo os dados do item
                }
            }
            catch (Exception ex) //Obtem qualquer exceção
            {
                Console.WriteLine($"Erro ao salvar dados do item: {ex.Message}"); //informa a mensagem da exceção capturada em ex.Message
            }
        }

        // Método para ler os dados de um arquivo
        public static List<ItemCompra> LerDados(string arquivo) //recebe um parâmetro arquivo
                                                                //indicando o caminho do arquivo do qual
                                                                //os dados do item serão lidos
        {
            List<ItemCompra> itens = new List<ItemCompra>(); //armazenar os itens recuperados do arquivo.

            try //possíveis exceções
            {
                using (StreamReader reader = new StreamReader(arquivo)) //abrindo o arquivo especificado no arquivo
                                                                        // automaticamente fechada quando o bloco using termina.
                {
                    string line; //line armazena o conteúdo de cada linha lida.
                    while ((line = reader.ReadLine()) != null) //retorna null quando o fim do arquivo é alcançado
                    {

                        string[] dados = line.Split(','); //Split() é um método da classe string em C#
                                                          //o método Split() deve dividir a string line com base em vírgulas


                        if (dados.Length == 3) //se o array dados contém exatamente três elementos
                        {
                            itens.Add(new ItemCompra() //se a verificação for bem-sucedida, cria uma nova instância do objeto

                            { ////e define suas propriedades com os valores extraídos do array dados
                                Descricao = dados[0],
                                Quantidade = int.Parse(dados[1]),
                                ValorUnitario = decimal.Parse(dados[2])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler dados do item: {ex.Message}"); //uma mensagem de erro indicando que houve
                                                                               //um problema ao ler os dados
            }

            return itens; // lista itens contendo todos os itens carregados do arquivo
        }

        // Método para gerar um relatório de compra
        public static void GerarRelatorioCompra(string arquivo, List<ItemCompra> itens) //arquivo = o caminho do arquivo onde o relatório de compra será salvo.
                                                                                        //list = uma lista contendo os itens da compra
        {
            try //possíveis exceções
            {
                using (StreamWriter writer = new StreamWriter(arquivo)) // criado um objeto StreamWriter que poem como texto as informações do arquivo 
                {
                    writer.WriteLine("Relatório de Compra"); // escreve Relatorio de Compra no arquivo
                    writer.WriteLine("------------------");

                    foreach (var item in itens)
                    {
                        writer.WriteLine($"{item.Descricao}: {item.Quantidade} x {item.ValorUnitario:F2} = {item.ValorTotalItem:F2}"); // pega os itens em forma decimal,
                                                                                                                                       // faz as contas e armazena no writer
                    }

                    writer.WriteLine(); //linha vazia para separar os itens do total da compra
                    writer.WriteLine("Total da Compra: {itens.Sum(i => i.ValorTotal):F2}"); // (soma dos valores totais de todos os itens)
                                                                                            // formatado com duas casas decimais
                }
            }
            catch (Exception ex) //capturar exceções durante a geração do relatório
            {
                Console.WriteLine($"Erro ao gerar relatório de compra: {ex.Message}"); // exibe o erro e qual a mensagem de erro
            }
        }

    }
}