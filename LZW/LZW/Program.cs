namespace LZW;

using LZW;

public class Program {
    static void Main(string[] args)
    {
        
        
        string filePath = "..\\..\\..\\" + "test.txt";
        var fileByteContent = File.ReadAllBytes(filePath);
        var newFilePath = filePath + ".zipped";
        LZWEncoder encoder = new ();
        var bytes = encoder.Encode(fileByteContent);
        File.WriteAllBytes(newFilePath, bytes);
        var firstFileSize = new FileInfo(filePath).Length;
        var secondFileSize = new FileInfo(newFilePath).Length;
        Console.Write((double)firstFileSize / (double)secondFileSize);
        /*
        string filePath = "..\\..\\..\\" + "test.txt.zipped";
        var fileByteContent = File.ReadAllBytes(filePath);
        var newFilePath = "..\\..\\..\\" + "testtest.txt";
        LZWDecoder decoder = new ();
        var bytes = decoder.Decode(fileByteContent);
        File.WriteAllBytes(newFilePath, bytes);
        var firstFileSize = new FileInfo(filePath).Length;
        var secondFileSize = new FileInfo(newFilePath).Length;
        Console.Write((double)firstFileSize / (double)secondFileSize);
        */
    }
}
