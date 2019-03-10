using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace number
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alfabeto = { 'k', 'b', 'w', 'r', 'q', 'd', 'n', 'f', 'x', 'j', 'm', 'l', 'v', 'h', 't', 'c', 'g', 'z', 'p', 's' };
            string textoA = "https://raw.githubusercontent.com/financas360/provas/master/klingon-textoA.txt";
            //string textoB = "https://raw.githubusercontent.com/financas360/provas/master/klingon-textoB.txt";
            string URL = textoA;

            List<string> texto = new List<string>();        
      
            int numBonito = 0;

            StreamReader reader = new StreamReader(WebRequest.Create(URL).GetResponse().GetResponseStream());
            string ler = reader.ReadToEnd();
            string[] retornoSplit = ler.Split(' ');

            foreach (string palavra in retornoSplit)
            {
                Numero numero = new Numero(palavra);
                if (numero.GetTipo() == numero.TYPE_NUMERO_BONITO)
                {
                    numBonito++;
                }

            }

            Console.WriteLine("Quantidade de números bonitos distintos: {0}", numBonito);

            Console.ReadKey();
        }
    }
}
