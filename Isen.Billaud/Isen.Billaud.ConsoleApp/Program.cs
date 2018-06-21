using System;
using Isen.Billaud.Library;

namespace Isen.Billaud.ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var a = new Node("Bonjour");
            var b = new Node("fils de bonjour", a);
            
            Console.WriteLine($"element {nameof(a)} : {a}");
            Console.WriteLine($"element {nameof(b)} : {b}");
        }
    }
}