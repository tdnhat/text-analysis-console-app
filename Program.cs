using text_analysis_app;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Text Analysis Demo: Async/Await + LINQ ===\n");
        
        string inputFile = "input.txt";
        string outputFile = "output.txt";
        
        // Create sample input file if it doesn't exist
        await CreateSampleInputFileAsync(inputFile);

        try
        {
            await TextAnalysis.AnalyzeTextAsync(inputFile, outputFile);
            Console.WriteLine($"\nText analysis completed successfully. Results saved to {outputFile}.");
            
            // Display the results
            Console.WriteLine("\n=== Analysis Results ===");
            string results = await File.ReadAllTextAsync(outputFile);
            Console.WriteLine(results);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nText analysis completed.");
        }
    }
    
    static async Task CreateSampleInputFileAsync(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Creating sample input file...");
            
            string sampleText = @"
The quick brown fox jumps over the lazy dog. This is a classic pangram sentence.
Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
The quick brown fox appears again in this text for analysis.
Programming is fun and challenging. C# is a powerful language.
Async and await make asynchronous programming easier.
LINQ provides powerful query capabilities for data manipulation.
The fox jumps quickly. The dog is lazy but friendly.
Data analysis helps us understand patterns in text.
This sample contains various words of different lengths and frequencies.";
            
            await File.WriteAllTextAsync(fileName, sampleText);
            Console.WriteLine($"Sample file '{fileName}' created successfully.\n");
        }
    }
}