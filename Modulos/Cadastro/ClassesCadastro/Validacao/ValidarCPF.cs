using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacao;

public static class ValidarCPF
{
    public static bool VerificarCPF(string cpf)
    {
        cpf = Cliente.LimparFormatacao(cpf);

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
}