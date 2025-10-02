using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            /*Console.WriteLine("I am Learning C#");
            Console.WriteLine("It is awesome!"); */
            Console.WriteLine("Lütfen bir şeyler yazın ve Enter'a basın:");
            var text = Console.ReadLine();
            Console.WriteLine($"You entered: {text}");
        }
    }
}