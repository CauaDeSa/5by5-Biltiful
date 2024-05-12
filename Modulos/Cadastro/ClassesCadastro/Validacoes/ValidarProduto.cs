namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes
{
    internal class ValidarProduto
    {
        public static bool CodigoBarras(string cb)
        {
            if (cb.Length != 13)
                return false;

            if (!int.TryParse(cb.Substring(0, 3), out int inicio))
                return false;

            return inicio == 789;
        }

        public static bool Nome(string nome)
        {
            return string.IsNullOrEmpty(nome);
        }

        public static bool ValorVenda(string valor)
        {
            if (!float.TryParse(valor, out float preco))
                return false;

            return preco >= 0 && preco <= 999.99;
        }
    }
}