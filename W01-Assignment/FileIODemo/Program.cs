using System.Text;

namespace FileIODemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== File I/O Demo ===");

        // Path to the sales folder
        string salesFolderPath = "/workspaces/CSE325-Max/W01-Assignment/sales";

        // Check if folder exists
        if (!Directory.Exists(salesFolderPath))
        {
            Console.WriteLine($"Error: Folder '{salesFolderPath}' not found.");
            return;
        }

        // Generate the sales summary
        GenerateSalesSummary(salesFolderPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Generates a sales summary report from all sales_*.txt files in the given folder.
    /// </summary>
    /// <param name="folderPath">Path to the folder containing sales files.</param>
    static void GenerateSalesSummary(string folderPath)
    {
        Console.WriteLine($"\nGenerating sales summary from: {folderPath}");

        // Get all files that start with "sales_" and end with ".txt"
        string[] salesFiles = Directory.GetFiles(folderPath, "sales_*.txt");

        if (salesFiles.Length == 0)
        {
            Console.WriteLine("No sales files found.");
            return;
        }

        // Build the report using StringBuilder
        StringBuilder summary = new StringBuilder();
        decimal totalSales = 0;
        List<string> details = new List<string>();

        // Process each file
        foreach (string filePath in salesFiles)
        {
            try
            {
                // Read the content of the file
                string content = File.ReadAllText(filePath).Trim();

                // Try to parse the content as a decimal
                if (decimal.TryParse(content, out decimal salesAmount))
                {
                    totalSales += salesAmount;
                    details.Add($"  {Path.GetFileName(filePath)}: {salesAmount:C}");
                }
                else
                {
                    details.Add($"  {Path.GetFileName(filePath)}: (Invalid data)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading {filePath}: {ex.Message}");
                details.Add($"  {Path.GetFileName(filePath)}: (Error reading)");
            }
        }

        // Build the report header
        summary.AppendLine("Sales Summary");
        summary.AppendLine("----------------------------");
        summary.AppendLine($" Total Sales: {totalSales:C}");
        summary.AppendLine();
        summary.AppendLine(" Details:");

        // Add all file details
        foreach (string detail in details)
        {
            summary.AppendLine(detail);
        }

        // Write the report to a file
        string reportPath = Path.Combine(folderPath, "sales_summary.txt");
        File.WriteAllText(reportPath, summary.ToString());

        // Output to console
        Console.WriteLine($"\n{summary.ToString()}");
        Console.WriteLine($"\nReport saved to: {reportPath}");
    }
}