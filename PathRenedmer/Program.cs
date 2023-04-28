// See https://aka.ms/new-console-template for more information

string directoryPath = @"D:\Git\fluent-framework";
string extension = ".java";

// Find all files with the specified extension in the directory
var files = Directory.GetFiles(directoryPath, $"*{extension}", SearchOption.AllDirectories)
    .ToList();


// Output the list of files
Console.WriteLine($"Found {files.Count} files with extension '{extension}':");
Parallel.ForEach(files, file =>
{
    Console.WriteLine($"Open file "+file);
    bool textFound = false;
    string[] lines = File.ReadAllLines(file);
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        if (line.Contains("io.github.jwdeveloper.spigot.fluent.core"))
        {
            lines[i] = line.Replace("io.github.jwdeveloper.spigot.fluent.core", "io.github.jwdeveloper.ff.core");
            continue;
        }
        
        if (line.Contains("io.github.jwdeveloper.spigot.fluent.plugin"))
        {
            lines[i] = line.Replace("io.github.jwdeveloper.spigot.fluent.plugin", "io.github.jwdeveloper.ff.plugin");
            continue;
        }
        if (line.Contains("jw.fluent.api.database"))
        {
            lines[i] = line.Replace("jw.fluent.api.database", "io.github.jwdeveloper.ff.extension.database");
            continue;
        }
        
        if (lines[i].Contains("class"))
        {
            break;
        }
    }

    File.WriteAllLines(file, lines);
    Console.WriteLine($"Modified file: {file}");
});