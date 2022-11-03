

using System.IO.Compression;

var rawStr = "For fear of losing you,I would never cry.For fear of losing you,I would never cry.For fear of losing you,I would never cry.";
var bytes = Encoding.UTF8.GetBytes(rawStr);
Console.WriteLine(bytes.Length);
var ms = new MemoryStream();
using (Stream ds = new DeflateStream(ms, CompressionMode.Compress))
{
    ds.Write(bytes, 0, bytes.Length);
}

byte[] compressed = ms.ToArray();
Console.WriteLine(compressed.Length);

//Decompress
ms = new MemoryStream(compressed);
var primary = new MemoryStream();
using (Stream ds = new DeflateStream(ms, CompressionMode.Decompress))
{
    ds.CopyTo(primary);
}
Console.WriteLine(primary.ToArray().Length);


//private static void CompressFile()
//{
//    using FileStream originalFileStream = File.Open(OriginalFileName, FileMode.Open);
//    using FileStream compressedFileStream = File.Create(CompressedFileName);
//    using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
//    originalFileStream.CopyTo(compressor);
//}

//private static void DecompressFile()
//{
//    using FileStream compressedFileStream = File.Open(CompressedFileName, FileMode.Open);
//    using FileStream outputFileStream = File.Create(DecompressedFileName);
//    using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
//    decompressor.CopyTo(outputFileStream);
//}