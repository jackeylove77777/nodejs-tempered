var files = Directory.GetFiles(".");
files.ToList().ForEach(Console.WriteLine);

string path = @"./456.txt";
if (!File.Exists(path))
{
    using (StreamWriter sw = File.CreateText(path))
    {
        sw.WriteLine("Hello");
        sw.WriteLine("And");
        sw.WriteLine("Welcome");
    }
}

// Open the file to read from.
using (StreamReader sr = File.OpenText(path))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        Console.WriteLine(s);
    }
}