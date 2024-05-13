using _5by5_Biltiful.Utils;
using System;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes
{
    public static class ValidarCliente
    {
        public static bool CPF(string cpf)
        {
            cpf = Formato.LimparFormatacao(cpf);

            if (cpf.Length != 11)
                return false;

            if (cpf.Count(value => value == cpf[0]) > cpf.Length - 1)
                return false;

            return ValidarDV(cpf, 1) && ValidarDV(cpf, 2);
        }

        private static bool ValidarDV(string cpf, int dv)
        {
            int result = 0;

            for (int posicao = 0, multiplicador = 9 + dv; posicao < 8 + dv; posicao++, multiplicador--)
                result += int.Parse(cpf.Substring(posicao, 1)) * multiplicador;

            result = (result * 10) % 11;

            return (result == 10 ? 0 : result) == int.Parse(cpf.Substring(8 + dv, 1));
        }

        public static bool Nome(string nome)
        {
            return !string.IsNullOrEmpty(nome);
        }

        public static bool DataNascimento(string? data)
        {
            return (DateOnly.TryParseExact(data, "ddMMyyyy", out DateOnly dateOnly) && !(dateOnly > DateOnly.FromDateTime(DateTime.Now)));
        }

        public static bool Sexo(string sexo)
        {
            return !string.IsNullOrEmpty(sexo) && sexo.Length == 1;
        }
    }
}