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

int DirectoryDelete(string directory)
{
    int count = 0;

    var directories = DirSearch(directory)
        .Where(dir => dir.EndsWith("bin") || dir.EndsWith("obj") || dir.EndsWith(".vs"))
        .ToList();

    foreach (var dir in directories)
    {
        count++;

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

    return count;
}

int result = 0;
do {
    result = DirectoryDelete(@"D:\Source\FCng"); 
} while (result == 0);