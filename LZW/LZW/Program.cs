using LZW;

LZW.LZW lzw = new ();
string filePath = args[0];
var sourceBytes = File.ReadAllBytes(filePath);
if (args[1] == "-c")
{
    var newFilePath = filePath + ".zipped";
    var compressedBytes = lzw.Compress(sourceBytes);
    File.WriteAllBytes(newFilePath, compressedBytes);
    var firstFileSize = new FileInfo(filePath).Length;
    var secondFileSize = new FileInfo(newFilePath).Length;
    Console.Write((double)firstFileSize / secondFileSize);
}
else if (args[1] == "-u")
{
    var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.'));
    var decompressedBytes = lzw.Decompress(sourceBytes);
    File.WriteAllBytes(newFilePath, decompressedBytes);
}

