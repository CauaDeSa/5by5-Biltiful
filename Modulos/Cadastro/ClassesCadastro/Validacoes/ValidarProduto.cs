﻿namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes
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

        public static bool ValorVenda(string preco)
        {
            return int.TryParse(preco, out _);
        }
    }
}