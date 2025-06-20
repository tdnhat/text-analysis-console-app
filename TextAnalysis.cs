using System.Text;

namespace text_analysis_app
{
    public class TextAnalysis
    {
        public static async Task AnalyzeTextAsync(string inputFile, string outputFile)
        {
            try
            {
                Console.WriteLine("Reading file asynchronously...");
                
                // Async file reading - demonstrates async/await
                string text = await File.ReadAllTextAsync(inputFile);
                Console.WriteLine($"File read successfully. Length: {text.Length} characters");
                
                // Simulate some async processing time
                await Task.Delay(500);
                Console.WriteLine("Processing text with LINQ...");
                
                // LINQ operations for text analysis
                var results = await PerformComplexAnalysisAsync(text);
                
                Console.WriteLine("Saving results asynchronously...");
                
                // Async file writing
                await File.WriteAllTextAsync(outputFile, results);
                Console.WriteLine($"Analysis results saved to {outputFile}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{inputFile}' was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        private static async Task<string> PerformComplexAnalysisAsync(string text)
        {
            // Simulate async processing
            await Task.Delay(300);
            
            var sb = new StringBuilder();
            sb.AppendLine("📊 COMPREHENSIVE TEXT ANALYSIS REPORT");
            sb.AppendLine("=====================================\n");
            
            // Clean and split text into words - demonstrates LINQ
            var words = text
                .Split(new[] { ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?', '"', '(', ')', '-' }, 
                       StringSplitOptions.RemoveEmptyEntries)
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .Select(word => word.ToLowerInvariant().Trim())
                .Where(word => word.Length > 0)
                .ToList();
            
            // Basic statistics
            sb.AppendLine("📈 BASIC STATISTICS:");
            sb.AppendLine($"   Total words: {words.Count}");
            sb.AppendLine($"   Unique words: {words.Distinct().Count()}");
            sb.AppendLine($"   Average word length: {words.Average(w => w.Length):F2}");
            sb.AppendLine($"   Shortest word: '{words.OrderBy(w => w.Length).First()}' ({words.Min(w => w.Length)} chars)");
            sb.AppendLine($"   Longest word: '{words.OrderByDescending(w => w.Length).First()}' ({words.Max(w => w.Length)} chars)");
            sb.AppendLine();
            
            // Word frequency analysis - complex LINQ with grouping
            sb.AppendLine("🔤 TOP 10 MOST FREQUENT WORDS:");
            var topWords = words
                .GroupBy(word => word)
                .Select(group => new { Word = group.Key, Count = group.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();
            
            foreach (var item in topWords)
            {
                sb.AppendLine($"   '{item.Word}' appears {item.Count} time(s)");
            }
            sb.AppendLine();
            
            // Word length distribution - LINQ with complex grouping
            sb.AppendLine("📏 WORD LENGTH DISTRIBUTION:");
            var lengthDistribution = words
                .GroupBy(word => word.Length)
                .Select(group => new { Length = group.Key, Count = group.Count() })
                .OrderBy(x => x.Length)
                .ToList();
            
            foreach (var item in lengthDistribution)
            {
                string bar = new string('█', Math.Min(item.Count, 20));
                sb.AppendLine($"   {item.Length,2} chars: {bar} ({item.Count})");
            }
            sb.AppendLine();
            
            // Words starting with vowels vs consonants - advanced LINQ
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            var vowelWords = words.Where(w => vowels.Contains(w[0])).Count();
            var consonantWords = words.Where(w => !vowels.Contains(w[0]) && char.IsLetter(w[0])).Count();
            
            sb.AppendLine("🅰️ VOWEL vs CONSONANT START:");
            sb.AppendLine($"   Words starting with vowels: {vowelWords}");
            sb.AppendLine($"   Words starting with consonants: {consonantWords}");
            sb.AppendLine();
            
            // Sentence analysis - multiple LINQ operations
            var sentences = text
                .Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();
            
            sb.AppendLine("📝 SENTENCE ANALYSIS:");
            sb.AppendLine($"   Total sentences: {sentences.Count}");
            if (sentences.Any())
            {
                sb.AppendLine($"   Average words per sentence: {sentences.Average(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length):F2}");
                sb.AppendLine($"   Shortest sentence: {sentences.OrderBy(s => s.Length).First().Length} characters");
                sb.AppendLine($"   Longest sentence: {sentences.OrderByDescending(s => s.Length).First().Length} characters");
            }
            sb.AppendLine();
            
            // Advanced LINQ: Words that appear more than once and their positions
            var duplicateWords = words
                .Select((word, index) => new { Word = word, Index = index })
                .GroupBy(x => x.Word)
                .Where(group => group.Count() > 1)
                .Select(group => new { 
                    Word = group.Key, 
                    Count = group.Count(),
                    Positions = group.Select(x => x.Index).ToList()
                })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();
            
            sb.AppendLine("🔄 REPEATED WORDS (Top 5):");
            foreach (var item in duplicateWords)
            {
                sb.AppendLine($"   '{item.Word}' appears {item.Count} times at positions: {string.Join(", ", item.Positions)}");
            }
            
            sb.AppendLine("\n=====================================");
            sb.AppendLine("Analysis completed using async/await and LINQ!");
            
            return sb.ToString();
        }
    }
}