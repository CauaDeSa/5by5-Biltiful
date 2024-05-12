using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes
{
    public static class ValidarMateriaPrima
    {
        public static bool ID(string id)
        {
            if (id.Length != 6)
                return false;

            if (id[0] != 'M' || id[1] != 'P')
                return false;

            return int.TryParse(id.Substring(2, 4), out _);
        }

        public static bool Nome(string nome)
        {
            return string.IsNullOrEmpty(nome);
        }
    }
}