namespace DebugDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Debugging Demo ===");

        int[] numbers = { 5, 10, 15, 20, 25 };
        int total = 0;

        // Loop through the array
        for (int i = 0; i <= numbers.Length; i++) // <-- BUG: Should be < not <=
        {
            total += numbers[i]; // <-- This will cause an IndexOutOfRangeException
            Console.WriteLine($"Added {numbers[i]}, total: {total}");
        }

        int average = total / numbers.Length;
        Console.WriteLine($"Average: {average}");
    }
}