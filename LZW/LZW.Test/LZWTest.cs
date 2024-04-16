namespace LZW.Test;

public class Tests
{
    private LZW lzw;
    
    [SetUp]
    public void Setup()
    {
        lzw = new LZW();
    }

    [Test]
    public void LZW_shouldCompressTheTextFile()
    {
        // arrange
        string filePath = "..\\..\\..\\" + "test.txt";
        var fileByteContent = File.ReadAllBytes(filePath);
        var newFilePath = filePath + ".zipped";
        // act
        var bytes = lzw.Compress(fileByteContent);
        File.WriteAllBytes(newFilePath, bytes);
        var firstFileSize = new FileInfo(filePath).Length;
        var secondFileSize = new FileInfo(newFilePath).Length;
        var compressFactor = (double)firstFileSize / secondFileSize;
        // assert
        Assert.That(compressFactor, Is.GreaterThan(1));
    }
    
    [Test]
    public void LZW_shouldDecompressFileCorrectly()
    {
        // arrange
        string sourceFilePath = "..\\..\\..\\" + "test.txt";
        var sourceBytes = File.ReadAllBytes(sourceFilePath);
        // act
        var compressedBytes = lzw.Compress(sourceBytes);
        var decompressBytes = lzw.Decode(compressedBytes);
        // assert
        Assert.That(sourceBytes, Is.EqualTo(decompressBytes));
    }
    
    [Test]
    public void LZW_shouldDecompressPNGFileCorrectly()
    {
        // arrange
        string sourceFilePath = "..\\..\\..\\" + "test.png";
        var sourceBytes = File.ReadAllBytes(sourceFilePath);
        // act
        var compressedBytes = lzw.Compress(sourceBytes);
        var decompressBytes = lzw.Decode(compressedBytes);
        // assert
        Assert.That(sourceBytes, Is.EqualTo(decompressBytes));
    }
}