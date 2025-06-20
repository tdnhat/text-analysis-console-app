# Text Analysis App

C# console app demonstrating async/await and LINQ operations.

## What it does

- Reads text file asynchronously
- Analyzes text using LINQ queries
- Generates comprehensive statistics report
- Shows word frequency, length distribution, and more

## How to run

```bash
dotnet run
```

Creates sample `input.txt` if missing, outputs results to `output.txt`.

## Key concepts shown

**Async/Await:**
- `File.ReadAllTextAsync()` and `File.WriteAllTextAsync()`
- Task composition with `await`
- Non-blocking I/O operations

**LINQ:**
- `.GroupBy()` for word frequency analysis
- `.Where()`, `.Select()`, `.OrderBy()` chaining
- `.Average()`, `.Count()`, `.Distinct()` aggregations
- Complex queries with anonymous types

## Files

- `Program.cs` - Main entry point
- `TextAnalysis.cs` - Core analysis logic with LINQ operations
