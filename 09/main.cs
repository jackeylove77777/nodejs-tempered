if (File.Exists("text.txt"))
{
    File.Delete("text.txt");
}
using (var writer = File.CreateText("text.txt"))
{
    writer.WriteLine(@"using (var writer = File.CreateText(""text.txt""))");
}
//流读写
using (var readStream = File.OpenRead("text.txt"))
{
    using var writeStream = File.Create("writeTo.txt");
    readStream.CopyTo(writeStream);
}

//侦听文件系统更改通知，并在目录或目录中的文件发生更改时引发事件。
using var watcher = new FileSystemWatcher(@".");
watcher.NotifyFilter = NotifyFilters.Attributes
                     | NotifyFilters.CreationTime
                     | NotifyFilters.DirectoryName
                     | NotifyFilters.FileName
                     | NotifyFilters.LastAccess
                     | NotifyFilters.LastWrite
                     | NotifyFilters.Security
                     | NotifyFilters.Size;
//添加事件回调
watcher.Changed += OnChanged;
watcher.Created += OnCreated;
watcher.Deleted += OnDeleted;
watcher.Renamed += OnRenamed;

watcher.Filter = "*.txt";
watcher.IncludeSubdirectories = true;
watcher.EnableRaisingEvents = true;

Console.WriteLine("Press enter to exit:\n ");
//修改文件信息，查看回调方法调用情况
string filename = $"text-{Guid.NewGuid()}.txt";
Task.Run(() =>
{
    File.Move("text.txt",filename );
    File.AppendAllText(filename, "hausihashduasdhuasdhashi");
});

//使用FileShare初始化FileStream实现文件锁
using var stream = new FileStream("lock.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

//尝试打开被锁的文件
try
{
    using var lockfile = File.OpenText("lock.txt");
    Console.WriteLine(lockfile.ReadLine());
}
catch(Exception ex)
{ 
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}



Console.ReadKey();

//文件系统发生事件的动作回调
static void OnChanged(object sender, FileSystemEventArgs e)
{
    if (e.ChangeType != WatcherChangeTypes.Changed)
    {
        return;
    }
    Console.WriteLine($"Changed: {e.FullPath}");
}

static void OnCreated(object sender, FileSystemEventArgs e)
{
    string value = $"Created: {e.FullPath}";
    Console.WriteLine(value);
}

static void OnDeleted(object sender, FileSystemEventArgs e) =>
    Console.WriteLine($"Deleted: {e.FullPath}");

static void OnRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"Renamed:");
    Console.WriteLine($"    Old: {e.OldFullPath}");
    Console.WriteLine($"    New: {e.FullPath}");
}