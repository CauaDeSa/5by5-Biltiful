using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes
{
    public static class ValidarCliente
    {
        public static bool CPF(string cpf)
        {
            cpf = Formato.LimparFormatacao(cpf);

            if (cpf.Length != 11)
                return false;

            if (!int.TryParse(cpf, out _))
                return false;

            if (cpf.Count(value => value == cpf[0]) > cpf.Length - 1)
                return false;

            return ValidarDV(cpf, 1) && ValidarDV(cpf, 2);
        }

        private static bool ValidarDV(string cpf, int dv)
        {
            int result = 0;

            for (int posicao = 0, multiplicador = 8 + dv; posicao < 9; posicao++, multiplicador--)
                result += int.Parse(cpf.Substring(posicao, 1)) * multiplicador;

            result %= 11;

            return (result == 10 ? 0 : result) == int.Parse(cpf.Substring(8 + dv, 1));
        }

        public static bool Nome(string nome)
        {
            return string.IsNullOrEmpty(nome);
        }

        public static bool DataNascimento(string data)
        {
            return data.Length == 8 DateOnly.TryParse(data, out _);
        }

        public static bool Sexo(string sexo)
        {
            return string.IsNullOrEmpty(sexo) && sexo.Length == 1;
        }
    }
}