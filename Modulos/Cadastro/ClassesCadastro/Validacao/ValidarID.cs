using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacao
{
    internal class ValidarID
    {
        public static bool VerificarID(string id)
        {
            if (id.Length != 6)
                return false;

            if (id[0] != 'M' || id[1] != 'P')
                return false;

            return int.TryParse(id.Substring(2, 4), out _);
        }
    }
}