using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacao
{
    public static class ValidarCB
    {
        public static bool VerificarCB(string cb)
        {
            if (cb.Length != 13)
                return false;

            if (!int.TryParse(cb.Substring(0, 3), out _))
                return false;

            return ValidarDV(cb);
        }

        private static bool ValidarDV(string cb)
        {
            int result = 0;

            for (int i = 0; i < cb.Length; i += 2)
                result += int.Parse(cb.Substring(i, 1));

            for (int i = 1; i < cb.Length; i += 2)
                result += int.Parse(cb.Substring(i, 1)) * 3;

            return 10 - (result % 10);
        }   
    }
}