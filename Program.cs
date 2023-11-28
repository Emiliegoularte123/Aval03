using System;
using System.IO;
using System.Linq;
using System.Text;

//Emilie Mendes Mattos Goularte

class Program
{
   static void Main()
   {
        //Decifra Texto
       string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
       string textoDecifrado = decifrar(textoCifrado);
       textoDecifrado = textoDecifrado.Replace("@", "\n");

       //Verifica Palindromo
       string[] palindromos = isPalindromo(textoDecifrado);
       foreach (var p in palindromos)
       {
           if (p.Length > 2)
           Console.WriteLine(p);
       }
       textoDecifrado = substituirPalindromos(textoDecifrado, palindromos);
       Console.WriteLine("\nTexto decifrado em maiúsculas: \n" + textoDecifrado.ToUpper());
   }
   static string decifrar(string textoCifrado)
   {
       char[] caracteresCifrados = textoCifrado.ToCharArray();
       for (int i = 0; i < caracteresCifrados.Length; i++)
       {
           int chave = (i % 5 == 0) ? 8 : 16;
           caracteresCifrados[i] = (char)(caracteresCifrados[i] - chave);
       }
       return new string(caracteresCifrados);
   }
   static string[] isPalindromo(string texto)
   {
       return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Where(palavra =>
           {
               char[] caracteres = palavra.ToCharArray();
               Array.Reverse(caracteres);
               return palavra.Equals(new string(caracteres), StringComparison.OrdinalIgnoreCase);
           })
           .ToArray();
   }
   static string substituirPalindromos(string texto, string[] palindromos)
   {
       foreach (var palavra in palindromos)
       {
           if (palavra.Length > 2)
           {
               string substituicao = "";
               switch (palavra.ToLower())
               {
                   case "arara":
                       substituicao = "gloriosa";
                       break;
                   case "ovo":
                       substituicao = "bondade";
                       break;
                   case "osso":
                       substituicao = "passam";
                       break;
               }
               texto = texto.Replace(palavra, substituicao);
           }
       }
       return texto;
   }
}