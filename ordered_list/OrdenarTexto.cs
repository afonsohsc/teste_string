using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ordered_list
{
    class OrdenarTexto
    {
        private string[] alfabeto = { "k","b","w","r","q","d","n","f","x","j","m","l","v","h","t","c","g","z","p","s" };
        private SortedDictionary<string, int> valLetra = new SortedDictionary<string, int>();
        private List<string> palavras = new List<string>();
        private static string URL;
        
        public OrdenarTexto(string texto)
        {
            URL = texto;
            ValorLetra();
            Ordenar();
        }

        private void ValorLetra()
        {
            for (int i = 0; i < alfabeto.Length; i++)
            {
                valLetra.Add(alfabeto[i], i);
            }
        }

        public string Ordenar()
        {           
            palavras = Texto().ToList();

            palavras.Sort(Compare);

            palavras.Distinct();

            string textoMontado = string.Join(" ", palavras);

            return textoMontado;
        }
        
        
        private string[] Texto()
        {
            StreamReader reader = new StreamReader(WebRequest.Create(URL).GetResponse().GetResponseStream());

            string ler = reader.ReadLine();

            string[] retornoSplit = ler.Split(' ');

            return retornoSplit;
        }

        private int Compare(string x, string y)
        {           
            int quantCaracterX = x.Length;
            int quantCaracterY = y.Length;

            string menor = quantCaracterX < quantCaracterY ? x : y;

            for (int i = 0; i < menor.Length; i++)
            {
                string letra1 = x[i].ToString();
                string letra2 = y[i].ToString();

                if (valLetra[letra1] > valLetra[letra2])
                {
                    return 1;

                }
                else if (valLetra[letra1] < valLetra[letra2])
                {

                    return -1;
                }

            }
            return 0;
        }





    }
}
