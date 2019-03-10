using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ordered_list
{
    class Program
    {      

        static void Main(string[] args)
        {

            string textoA = "https://raw.githubusercontent.com/financas360/provas/master/klingon-textoA.txt";
            //string textoB = "https://raw.githubusercontent.com/financas360/provas/master/klingon-textoB.txt";

            OrdenarTexto textoOrdenado = new OrdenarTexto(textoA);

            Console.WriteLine("Texto A ordenado");
            Console.WriteLine();
            Console.WriteLine(textoOrdenado.Ordenar());

            Console.ReadKey();


        }
    }
}
