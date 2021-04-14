using System.Runtime.CompilerServices;


List<string> DirSearch(string directory)
{
    var directories = new List<string>();
    foreach (var dir in Directory.EnumerateDirectories(directory))
    {
        directories.Add(dir);
        directories.AddRange(DirSearch(dir));
    }

    return directories;
}

var librariesPath = @"D:\Source\FCng";
var directories = DirSearch(librariesPath)
    .Where(dir => dir.EndsWith("bin") || dir.EndsWith("obj") || dir.EndsWith(".vs"))
    .ToList();

foreach (var dir in directories)
{
    try
    {
        Directory.Delete(dir, recursive: true);
        Console.WriteLine($"Deleted: {dir}");
    }
    catch
    {
        Console.WriteLine($"Deleting failed: {dir}");
    }
}