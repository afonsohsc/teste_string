using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_manipulation
{
    public class Palavra
    {
        public const string TYPE_VERBO = "verbo";
        public const string TYPE_VERBO_PRIMEIRA_PESSOA = "verboPrimeiraPessoa";
        public const string TYPE_PREPOSICAO = "preposicao";
        public const string NO_TYPE = "semTipo";
        char[] LETRA_FOO = { 's', 'l', 'f', 'w', 'k' };

        private string texto;
        private string tipo;

        public Palavra(string texto)
        {
            this.texto = texto;
            DefinirTipo();
        }

        public string GetTipo()
        {
            return tipo;
        }
        
        private void DefinirTipo()
        {
            if (IsVerbo())
            {
                if (IsNotVerboPrimeiraPessoa())
                {
                    tipo = TYPE_VERBO;
                }
                else
                {
                    tipo = TYPE_VERBO_PRIMEIRA_PESSOA;
                }

            }
            else if (IsPreposicao())
            {
                tipo = TYPE_PREPOSICAO;
            }
            else
            {
                tipo = NO_TYPE;
            }
        }

        private bool IsVerbo()
        {
            char ultimaLetra = texto.Last();
            if (texto.Length >= 8)
            {
                foreach (char letraFoo in LETRA_FOO)
                {
                    if (ultimaLetra.Equals(letraFoo))
                        return true;
                }
            }
            return false;
        }

        private bool IsNotVerboPrimeiraPessoa()
        {
            char primeiraLetra = texto.First();

            if (texto.Length >= 8)
            {
                foreach (char letraFoo in LETRA_FOO)
                {
                    if (primeiraLetra.Equals(letraFoo))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsPreposicao()
        {
            int cont = 0;

            if (texto.Length == 3 && !texto.Contains('d'))
            {
                foreach (char letraFoo in LETRA_FOO)
                {
                    if (!texto.EndsWith(letraFoo.ToString()))
                    {
                        cont++;
                    }
                }

                if (LETRA_FOO.Length == cont)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
