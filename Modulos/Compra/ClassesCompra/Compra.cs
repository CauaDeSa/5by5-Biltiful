using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras
{
    internal class Compra
    {
        // Atributos da classe
        public int Id { get; set; }
        public DateTime DataCompra { get; set; } // get e set permitem ler o valor da propriedade
        public string CnpjFornecedor { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItemCompra> ItensCompras { get; set; }

        // Declara e inicializa a lista de compras
        private List<Compra> listaDeCompras = new List<Compra>();

        // Construtor para inicializar a lista de itens
        public Compra()
        {
            ItensCompras = new List<ItemCompra>();
        }

        private void ValidarDadosCompra(int id, DateTime dataCompra, string cnpjFornecedor)
        {
            // valida os dados da compra
            if (id <= 0)
            {
                throw new ArgumentException("O ID da compra deve ser um número positivo."); // uso do throw new é para sinalizar erros
            }

            if (dataCompra < DateTime.MinValue) // representa a data e hora mais antiga corresponde a 12:00:00 AM de 1º de janeiro do ano 0001
            {
                throw new ArgumentException("A data da compra não pode ser anterior à data mínima.");
            }

            if (string.IsNullOrEmpty(cnpjFornecedor)) // objeto para dizer se o cnpj é nulo ou vazio
            {
                throw new ArgumentException("O CNPJ do fornecedor não pode ser vazio.");
            }
        }

        public void CadastrarCompra(int id, DateTime dataCompra, string cnpjFornecedor)
        {
            // Valida os dados da compra
            ValidarDadosCompra(id, dataCompra, cnpjFornecedor);

            // Verifica se o Id já existe
            if (BuscarCompraPorId(id) != null)
            {
                throw new Exception("Já existe uma compra com o Id informado."); // sinaliza erro caso ja exista um ID igual
            }

            // Cria a nova compra
            Compra compra = new Compra()
            {
                Id = id,
                DataCompra = dataCompra,
                CnpjFornecedor = cnpjFornecedor,
                ItensCompras = new List<ItemCompra>() // Inicializa lista de itens vazia
            };

            // Calcula o valor total da compra com base nos itens da compra
            decimal valorTotalCompra = 0; // Inicializa valor total
            foreach (ItemCompra item in compra.ItensCompras)
                valorTotalCompra += item.ValorTotalItem; // Soma o valor total de cada item

            compra.ValorTotal = valorTotalCompra; // Atualiza o valor total da compra

            // Armazena a compra na lista de compras
            listaDeCompras.Add(compra);

            // Exibe mensagem de sucesso
            Console.WriteLine($"Compra {compra.Id} cadastrada com sucesso!");
        }

        // Método para buscar uma compra por ID
        public Compra BuscarCompraPorId(int id)
        {
            // Busca a compra na lista de compras
            return listaDeCompras.FirstOrDefault(c => c.Id == id);
        }

        private void ValidarDadosExclusao(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID da compra deve ser um número positivo.");
            }

            if (!listaDeCompras.Any(c => c.Id == id))
            {
                throw new Exception($"Compra com o ID {id} não encontrada.");
            }
        }
        public void ExcluirCompra(int id)
        {
            // Valida os dados da exclusão
            ValidarDadosExclusao(id);
            // Busca a compra na lista de compras
            Compra compraEncontrada = BuscarCompraPorId(id);
            // Remove a compra da lista de compras
            listaDeCompras.Remove(compraEncontrada);
            // Exibe mensagem de sucesso
            Console.WriteLine("\nCompra {id} excluída com sucesso!");
        }

        public void ImprimirCompraPorRegistro(int indiceAtual)
        {
            // Verifica se o índice está dentro dos limites da lista
            if (indiceAtual >= 0 && indiceAtual < listaDeCompras.Count)
            {
                // Recupera a compra do índice atual
                Compra compra = listaDeCompras[indiceAtual];

                // Exibe o cabeçalho da compra
                Console.WriteLine("\n=====================================================");
                Console.WriteLine($"Compra {compra.Id} - {compra.DataCompra.ToString("dd/MM/yyyy")}");
                Console.WriteLine("Fornecedor: " + compra.CnpjFornecedor);
                Console.WriteLine("Valor Total: R$" + compra.ValorTotal.ToString("F2"));
                Console.WriteLine("=====================================================");

                // Exibe os itens da compra
                Console.WriteLine("\nItens da Compra:");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("| Nº | Descrição                 | Quantidade | Valor Unit. | Valor Total |");
                Console.WriteLine("-----------------------------------------------------");

                for (int i = 0; i < compra.ItensCompras.Count; i++) //informa quantos itens estão incluídos na lista ItensCompras
                {
                    ItemCompra item = compra.ItensCompras[i];
                    // (i + 1,2) calcula o índice do item atual mais um formata com uma largura de dois caracteres 2
                    // (-25) formata como uma string alinhada à esquerda com uma largura máxima de 25 caracteres
                    // (3) alinhada à direita com uma largura mínima de três caracteres 
                    // (7:f2) largura mínima de sete caracteres, e aplica duas casas decimais F2
                    Console.WriteLine($"| {i + 1,2} | {item.Descricao,-25} | {item.Quantidade,3} | R${item.ValorUnitario,7:F2} | R${item.ValorTotalItem,7:F2} |");
                }

                Console.WriteLine("-----------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Índice inválido. Nenhuma compra a ser impressa.");
            }
        }

    }
}