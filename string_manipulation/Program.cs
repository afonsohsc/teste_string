using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace string_manipulation
{
    class Program
    {
        static void Main(string[] args)
        {           
            string textoA = "https://raw.githubusercontent.com/financas360/provas/master/klingon-textoA.txt";
            //string textoB = "https://raw.githubusercontent.com/financas360/provas/master/klingon-textoB.txt";

            string URL = textoA;

            StreamReader reader = new StreamReader(WebRequest.Create(URL).GetResponse().GetResponseStream());

            string texto = reader.ReadToEnd();

            string[] retornoSplit = texto.Split(' ');

            int contVerbo = 0;
            int contVerboPrimeiraPessoa = 0;
            int contPreposicao = 0;

            foreach (string item in retornoSplit)
            {
                Palavra palavra = new Palavra(item);
                switch (palavra.GetTipo())
                {
                    case Palavra.TYPE_VERBO:
                        contVerbo++;
                        break;
                    case Palavra.TYPE_VERBO_PRIMEIRA_PESSOA:
                        //Dois contadores são incrementados pois um verbo em primeira pessoa também é um verbo
                        contVerboPrimeiraPessoa++;
                        contVerbo++;
                        break;
                    case Palavra.TYPE_PREPOSICAO:
                        contPreposicao++;
                        break;

                    default: break;
                }
            }

            Console.WriteLine("Verbos: {0}", contVerbo);
            Console.WriteLine("Verbos na primeira pessoa: {0}", (contVerboPrimeiraPessoa));
            Console.WriteLine("Preposições: {0}", contPreposicao);
            Console.ReadLine();          
               

        }
    }
}
