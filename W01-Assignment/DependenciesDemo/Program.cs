using Newtonsoft.Json;
using System.Text.Json; // Built-in JSON support

namespace DependenciesDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== .NET Dependencies Demo ===");

        // Create an object
        var person = new
        {
            Name = "Max",
            Age = 30,
            Email = "maxtinka7@gmail.com"
        };

        // Using Newtonsoft.Json (the NuGet package you added)
        string jsonNewtonsoft = JsonConvert.SerializeObject(person, Formatting.Indented);
        Console.WriteLine("\nNewtonsoft.Json Output:");
        Console.WriteLine(jsonNewtonsoft);

        // Using System.Text.Json (built-in, no package needed)
        string jsonSystem = System.Text.Json.JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("\nSystem.Text.Json Output:");
        Console.WriteLine(jsonSystem);

        Console.WriteLine("\nDependencies demo completed successfully!");
    }
}