namespace LZW;

public class ByteBuffer
{
    /// <summary>
    /// Result output list of compressed bytes.  
    /// </summary>
    public List<byte> CompressedBytes { get; } = new();
    
    /// <summary>
    /// Result output list of decompressed bytes. 
    /// </summary>
    public List<int> DecompressedCodes { get; } = new();

    /// <summary>
    /// Current size of one new "byte".
    /// </summary>
    public int CurrentByteSize { get; set; } = 8;
    
    private int byteSize = 8;
    private int currentLengthOfByteBuffer;
    private byte byteBuffer;
    private int codeBuffer;
    private int currentLengthOfCodeBuffer;

    /// <summary>
    /// Add word code to result compressed bytes.
    /// </summary>
    public void AddCodeToCompressedBytes(int code)
    {
        var bits = IntToBits(code);

        foreach (var bit in bits)
        {
            byteBuffer = (byte)((byteBuffer << 1) + bit);
            ++currentLengthOfByteBuffer;
            if (currentLengthOfByteBuffer == byteSize)
            {
                CompressedBytes.Add(byteBuffer);
                currentLengthOfByteBuffer = 0;
                byteBuffer = 0;
            }
        }
    }

    private byte[] IntToBits(int code)
    {
        var bitsOfCode = new byte[CurrentByteSize];
        for (var i = CurrentByteSize - 1; i >= 0; --i)
        {
            bitsOfCode[i] = (byte)(code % 2);
            code /= 2;
        }
        return bitsOfCode;
    }

    /// <summary>
    /// Add unfinished byte to compression result
    /// </summary>
    public void AddIncompleteByteToCompressedBytes()
    {
        if (currentLengthOfByteBuffer != 0)
        {
            CompressedBytes.Add(byteBuffer);
        }
    }
    
    /// <summary>
    /// Add byte to decompression result
    /// </summary>
    public bool AddByteToDecompressedBytes(byte element)
    {
        var bits = ByteToBits(element);
        bool wasAdded = false;

        foreach (var bit in bits)
        {
            codeBuffer = (codeBuffer << 1) + bit;
            ++currentLengthOfCodeBuffer;
            if (currentLengthOfCodeBuffer == CurrentByteSize)
            {
                DecompressedCodes.Add(codeBuffer);
                currentLengthOfCodeBuffer = 0;
                codeBuffer = 0;
                wasAdded = true;
            }
        }
        return wasAdded;
    }

    /// <summary>
    /// Add last byte to decompressed bytes if it necessary.
    /// </summary>
    public void AddIncompleteByteToDecompressedBytes(byte element)
    {
        if (currentLengthOfCodeBuffer + byteSize == CurrentByteSize)
        {
            AddByteToDecompressedBytes(element);
        }
        else
        {
            var bits = IncompleteByteToBits(element);
            foreach (var bit in bits)
            {
                codeBuffer = ((codeBuffer << 1) + bit);
                ++currentLengthOfCodeBuffer;
                if (currentLengthOfCodeBuffer == CurrentByteSize)
                {
                    DecompressedCodes.Add(codeBuffer);
                    currentLengthOfCodeBuffer = 0;
                    codeBuffer = 0;
                }
            }
        }
    }

    private byte[] IncompleteByteToBits(byte element)
    {
        var bits = new byte[CurrentByteSize - currentLengthOfCodeBuffer];

        var digitCounter = 0;
        for (var i = CurrentByteSize - currentLengthOfCodeBuffer - 1; element > 0; --i)
        {
            bits[i] = (byte)(element % 2);
            element /= 2;
            ++digitCounter;
        }

        return bits;
    }

    private byte[] ByteToBits(byte element)
    {
        var bits = new byte[byteSize];

        for (var i = byteSize - 1; i >= 0; --i)
        {
            bits[i] = (byte)(element % 2);
            element /= 2;
        }

        return bits;
    }
}