/* TEST  
    1. Problem 1 - (A)
    Create an Object with a "hello" method that writes "Hello <name> in the console"

    2. Problem 1 - (B)
    How would you make name inmutable? "_Que no se puede cambiar_"
    (Can write or just describe)

    3. Problem 2
    Write a funtion that logs the 5 cities that occur the most in the array below in
    order from the most number of occurrences to least.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;



/* 1. Problem 1 - (A): There is two ways to solve the problem, one static and the other one dinamic. */


class Program
{
    // Static way
    static void StaticGreeter(string[] args)
    {
        string name = "John"; // This name cannot be change
        Greeter greeter = new Greeter(name);

        greeter.Hello();
    }

    class Greeter
    {
        private readonly string name;
        public Greeter(string name)
        {
            this.name = name; // Setting the name.
        }
        public void Hello()
        {
            Console.WriteLine($"{Environment.NewLine}Hello {name}!, this is the static way, if your name is not John, press any key to continue");
            Console.ReadKey(true);
        }
    }

    // Dinamic
    static void DynamicGreeter(string[] args)
    {
        string name;

        // Loop until a non-empty name is provided
        do
        {
            Console.Write($"{Environment.NewLine}What is your name? ");
            name = Console.ReadLine().Trim();
        } while (string.IsNullOrEmpty(name));

        Console.WriteLine($"{Environment.NewLine}Hello, {name}! This is the dynamic way");
        Console.Write($"{Environment.NewLine}Press any key to see the continue with for problem number 2... {Environment.NewLine}");
        Console.ReadKey(true);
        Console.WriteLine();
    }


/* 2. Problem 1 - (B): As I commented, the name is immutable because it's assigned in line 31 once and cannot be changed due to his readonly nature, 
    the same thing happens in line 41, once I set the name.
    In DynamicGreeter, name is treated as immutable, creating a new variable in each iteration without modifying the original value, that why I created a loop
*/


/* 3. Problem 2:This method prints the top 5 most common cities from the provided list of cities, order by the times its mentioned */

    
    static void PrintTop5Cities(string[] args)
    {
        string[] citiesList =
        {
            "nasville",
            "nasville",
            "los angeles",
            "nasville",
            "Madrid",
            "memphis",
            "barcelona",
            "los angeles",
            "sevilla",
            "Madrid",
            "canary islands",
            "barcelona",
            "Madrid",
            "Madrid",
            "nasville",
            "barcelona",
            "london",
            "berlin",
            "Madrid",
            "nasville",
            "london",
            "Madrid",
            "Madrid",
        };

        Dictionary<string, int> count = citiesList
            .GroupBy(p => p)
            .ToDictionary(g => g.Key, g => g.Count());

        // Order the dictionary by value (number of occurrences) from highest to lowest
        var getOrder = count.OrderByDescending(x => x.Value).Take(5);

        foreach (var kvp in getOrder)
        {
            Console.WriteLine($"{Environment.NewLine}{kvp.Key} {kvp.Value}");
        }
    }


    // Call methods to execute the solutions
    static void Main(string[] args)
    {
        StaticGreeter(args);
        DynamicGreeter(args);
        PrintTop5Cities(args);
    }


}
