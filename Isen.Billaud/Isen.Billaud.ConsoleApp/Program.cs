using System;
using Isen.Billaud.Library;

namespace Isen.Billaud.ConsoleApp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var a = new Node("Bonjour");
            var b = new Node("fils de bonjour", a);
            var c = new Node("Au revois");
            var d = new Node("Merci");
            var e= new Node("de Rien");

            c.AddChildNode(a);

            #region Question4

            Console.WriteLine($"traversing c=>b Guid {c.FindTraversing(b.Id)}");

            Console.WriteLine($"traversing c=>d Guid {c.FindTraversing(d.Id)}");

            Console.WriteLine($"traversing c=>b Node {c.FindTraversing(b)}");

            Console.WriteLine($"traversing c=>d Node {c.FindTraversing(d)}");

            #endregion

            #region Question5

            a.AddChildNode(d);
 
            c.AddChildNode(e);
 
            Console.WriteLine(c.ToString());


            #endregion
        }
    }
}