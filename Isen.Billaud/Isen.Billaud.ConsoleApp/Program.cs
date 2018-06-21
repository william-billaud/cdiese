using System;
using Isen.Billaud.Library;
using Newtonsoft.Json.Linq;

namespace Isen.Billaud.ConsoleApp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var a = new Node<string>("Bonjour");

            var b = new Node<string>("fils de bonjour", a);

            var c = new Node<string>("Au revois");

            var d = new Node<string>("Merci");

            var e = new Node<string>("de Rien");

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

            #region Question7

            Console.WriteLine(c.SerializeJSon().ToString());  
            
            JObject jobj = c.SerializeJSon();
 
            Console.WriteLine(jobj.ToString());
 
            var f = new Node<string>();
 
            f.UnserializeJson(jobj);
 
            Console.WriteLine($"unserialization : {System.Environment.NewLine}{f}");
 
            Console.WriteLine($"Original: {System.Environment.NewLine}{c}");


            #endregion
            
            a.RemoveChildNode(b);
 
            Console.WriteLine($"Remove: {System.Environment.NewLine}{c}");      
        }
    }
}