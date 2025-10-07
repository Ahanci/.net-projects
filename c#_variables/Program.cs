using System;
public class Father
{
    public void Display()
    {
        Console.WriteLine("This is the father class");
    }
}

public abstract class Animal
{
    public abstract void MakeSound(); // zorunlu implement
    public void Eat()
    {
        Console.WriteLine("This animal is eating"); // opsiyonel, tüm hayvanlar bunu kullanabilir
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof Woof");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

public static class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

// var a = new Animal("Rex");
// Console.WriteLine(a.Name); // Rex

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {


            var sum = MathHelper.Add(5, 10);
            Console.WriteLine($"Sum: {sum}, type: {sum.GetType()}");
        }
    }
}