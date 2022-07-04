using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string[] arr = new string[] { "1", "2", "3", "4" };
            int[] arr1 = Array.ConvertAll<string, int>(arr, delegate (string s) { return int.Parse(s); });
            Console.WriteLine(arr1[0]);
            int[] arr2 = arr.Select(t => int.Parse(t)).ToArray();
        }
    }
}
