namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades
{
    internal class MateriaPrima
    {
        public string Id { get; set; }                     //6  (0-5)
        public string Nome { get; set; }                   //20 (6-25)
        public DateOnly DataUltimaCompra { get; set; }     //8 (26-33)
        public DateOnly DataCadastro { get; set; }         //8 (34-41)
        public char Situacao { get; set; }                 //1 (42)

        public MateriaPrima(string id, string nome, DateOnly dataUltimaCompra, DateOnly dataCadastro, char situacao)
        {
            Id = id;
            Nome = nome;
            DataUltimaCompra = dataUltimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public MateriaPrima() 
        {
        
        }

        public string FormatarParaArquivo()
        {

        }

        static bool VerificarId(int id)
        {

        }
    }
}