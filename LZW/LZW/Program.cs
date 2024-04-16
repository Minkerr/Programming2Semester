namespace LZW;

public class Program {
    static void Main(string[] args)
    {
        /*
        string filePath = "..\\..\\..\\" + "test.txt";
        var fileByteContent = File.ReadAllBytes(filePath);
        var newFilePath = filePath + ".zipped";
        LZW lzw = new ();
        var bytes = lzw.Compress(fileByteContent);
        File.WriteAllBytes(newFilePath, bytes);
        var firstFileSize = new FileInfo(filePath).Length;
        var secondFileSize = new FileInfo(newFilePath).Length;
        Console.Write((double)firstFileSize / secondFileSize);
        */
        string filePath = "..\\..\\..\\" + "test.txt.zipped";
        var sourceBytes = File.ReadAllBytes(filePath);
        var newFilePath = "..\\..\\..\\" + "testtest.txt";
        LZW lzw = new ();
        var bytes = lzw.Decode(sourceBytes);
        File.WriteAllBytes(newFilePath, bytes);
        var firstFileSize = new FileInfo(filePath).Length;
        var secondFileSize = new FileInfo(newFilePath).Length;
        Console.Write((double) firstFileSize / secondFileSize);
        
    }
}
