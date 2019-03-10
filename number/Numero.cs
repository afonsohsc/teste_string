using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number
{
    class Numero
    {
        public string TYPE_NUMERO = "numero";
        public string TYPE_NUMERO_BONITO = "numeroBonito";
        char[] alfabeto = { 'k', 'b', 'w', 'r', 'q', 'd', 'n', 'f', 'x', 'j', 'm', 'l', 'v', 'h', 't', 'c', 'g', 'z', 'p', 's' };
        List<int> posicaoLetras = new List<int>();

        private int posicao = 0;
        private readonly int numBase = 20;
        private readonly int numDivisivel = 3;
        private readonly int numMaiorIgual = 440566;
        private double soma = 0;

        private string texto;
        private string tipo;

        public Numero(string texto)
        {
            this.texto = texto;
            Position();
            ValuePalavra();
            DefinirNumero();            
            Zerar();
        }

        public string GetTipo()
        {
            return tipo;
        }

        private void DefinirNumero()
        {            
            if (NumeroBonito())
            {
                tipo = TYPE_NUMERO_BONITO;
            }
            else
            {
                tipo = TYPE_NUMERO;
            }

        }
      
        private void Zerar()
        {
            posicaoLetras.Clear();
            soma = 0;
        }

        private void Position()
        {
            foreach (char letra in texto)
            {
                posicao = Array.IndexOf(alfabeto, letra);
                posicaoLetras.Add(posicao);
            }
        }

        private void ValuePalavra()
        {
            for (int i = 0; i < posicaoLetras.Count; i++)
            {
                soma = (posicaoLetras[i] * Math.Pow(numBase, i)) + soma;
            }            
        }                      
        
        private bool NumeroBonito()
        {
            if (soma >= numMaiorIgual && soma % numDivisivel == 0)
            {
                return true;
            }
            return false;
        }
    }
}
