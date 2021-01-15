using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExercicioLogica
{
    public class Program
    {

        /// <summary>
        /// Recebe um inteiro não negativo como parâmetro e retorna seus dígitos em ordem descendente.
        /// </summary>
        /// <param name="num">Valor inteiro não negativo.</param>
        /// <returns>Número com dígitos em ordem descendente.</returns>
        public static int GetDescendingOrder(int num)
        {
            var digits = new List<int>();
            var result = 0;
            while (num > 0)
            {
                digits.Add(num % 10);
                num /= 10;
            }
            digits.Sort((a, b) => b.CompareTo(a));

            foreach (var t in digits)
            {
                result *= 10;
                result += t;
            }

            return result;
        }

        /// <summary>
        /// Recebe uma string e retorna o caractere que está no meio da string.
        /// Se a string tiver tamanho par, serão retornados 2 caracteres (ex.: "testar" retorna "st").
        /// </summary>
        /// <param name="str">string não null.</param>
        /// <returns>Caracter(es) do meio da string.</returns>
        public static string GetTheMiddleCharacter(string str)
        {
            return str.Length % 2 == 0 ? str.Substring(str.Length / 2 - 1, 2) : str.Substring(str.Length / 2, 1);
        }

        /// <summary>
        /// Aplica uma máscara usando o caractere #, que oculta todos os caracteres exceto os 4 últimos (ex.: "12345678" retorna "####5678").
        /// </summary>
        /// <param name="str">string não null.</param>
        /// <returns>String com a máscara.</returns>
        public static string Maskfy(string str)
        {
            return str.Length > 4 ? string.Concat("", new string('#', str.Length - 4), str.Substring(str.Length - 4)) : str;
        }

        /// <summary>
        /// A partir de uma lista de inteiros não negativos e strings, filtrar a lista retornando apenas objetos do tipo T.
        /// </summary>
        /// <param name="list">Lista de números inteiros não negativos e strings.</param>
        /// <returns>Lista contendo apenas elementos do tipo T.</returns>
        public static IEnumerable<T> ListFilter<T>(List<object> list)
        {
            var filtro = typeof(T) != typeof(object) ? list.Where(x => x.GetType() == typeof(T)) : list;
            var lst = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T)));
            foreach (var item in filtro)
            {
                lst.Add(item);
            }
            return (IEnumerable<T>)lst;
        }

        static void Main()
        {
            Console.WriteLine("Testes para o exercício 1:");
            Console.WriteLine("Esperado: 654321 - Resultado {0}", GetDescendingOrder(145263));
            Console.WriteLine("Esperado: 654321 - Resultado {0}", GetDescendingOrder(543216));
            Console.WriteLine("Esperado: 77710 - Resultado {0}", GetDescendingOrder(17077));

            Console.WriteLine("\nTestes para o exercício 2:");
            Console.WriteLine("Esperado: s - Resultado {0}", GetTheMiddleCharacter("teste"));
            Console.WriteLine("Esperado: st - Resultado {0}", GetTheMiddleCharacter("testar"));
            Console.WriteLine("Esperado: a - Resultado {0}", GetTheMiddleCharacter("a"));

            Console.WriteLine("\nTestes para o exercício 3:");
            Console.WriteLine("Esperado: ####5678 - Resultado {0}", Maskfy("12345678"));
            Console.WriteLine("Esperado: #####4321 - Resultado {0}", Maskfy("987654321"));
            Console.WriteLine("Esperado: 123 - Resultado {0}", Maskfy("123"));

            Console.WriteLine("\nTestes para o exercício 4:");
            WriteLine(ListFilter<int>(new List<object> { 1, 2, "a", "b" }));
            WriteLine(ListFilter<string>(new List<object> { 1, 2, "a", "b", 0, 15 }));
            WriteLine(ListFilter<object>(new List<object> { 1, 2, "a", "b", "aasf", "1", "123", 231 }));
            Console.ReadKey();
        }

        public static void WriteLine<T>(IEnumerable<T> list)
        {
            Console.WriteLine(list != null ? string.Join(" ", list) : "");
        }
    }
}
