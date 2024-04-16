namespace LZW;

/// <summary>
/// Class that implements LZW
/// </summary>
public class LZW
{
    private const int StartMaximumOfCodes = 256;

    /// <summary>
    /// Compress input array of bytes by LZW.
    /// </summary>
    public byte[] Compress(byte[] input)
    {
        var trie = new Trie();
        for (int i = 0; i < 256; ++i)
        {
            var newElementOfTrie = new List<byte>();
            newElementOfTrie.Add((byte) i);
            trie.Add(newElementOfTrie);
        }

        ByteBuffer buffer = new();
        var currentWord = new List<byte>();
        var currentMaximumOfCodes = StartMaximumOfCodes;
        
        for (var i = 0; i < input.Length; ++i)
        {
            var currentWordWithExtraByte = new List<byte>();
            currentWordWithExtraByte.AddRange(currentWord);
            currentWordWithExtraByte.Add(input[i]);

            if (trie.Contains(currentWordWithExtraByte))
            {
                currentWord = currentWordWithExtraByte;
            }
            else
            {
                if (trie.Size == currentMaximumOfCodes)
                {
                    currentMaximumOfCodes *= 2;
                    ++buffer.CurrentByteSize;
                }
                
                buffer.AddCodeToCompressedBytes(trie.GetValue(currentWord));
                trie.Add(currentWordWithExtraByte);
                currentWord.Clear();
                currentWord.Add(input[i]);
            }
        }
        buffer.AddCodeToCompressedBytes(trie.GetValue(currentWord));
        buffer.AddIncompleteByteToCompressedBytes();
        
        return buffer.CompressedBytes.ToArray();
    }
    
    /// <summary>
    /// Decompress input array of compressed bytes.
    /// </summary>
    public byte[] Decode(byte[] input)
    {
        var result = new List<byte>();
        var dictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            dictionary[i] = new List<byte> { (byte) i };
        }
        
        List<int> codes = GetCodes(input);
        var currentCode = StartMaximumOfCodes;
        var dictionarySize = StartMaximumOfCodes;
        var currentWord = new List<byte>();

        for (var i = 0; i < codes.Count; ++i)
        {
            if (dictionary.ContainsKey(codes[i]))
            {
                if (dictionarySize != StartMaximumOfCodes)
                {
                    while (dictionary.ContainsKey(currentCode))
                    {
                        ++currentCode;
                    }

                    currentWord = new List<byte>(dictionary[codes[i - 1]]);
                    currentWord.Add(dictionary[codes[i]][0]);

                    dictionary.Add(currentCode++, currentWord);
                }

                result.AddRange(dictionary[codes[i]]);
            }
            else
            {
                currentWord = new List<byte>(dictionary[codes[i - 1]]);
                currentWord.Add(dictionary[codes[i - 1]][0]);
                dictionary.Add(codes[i], currentWord);
                result.AddRange(currentWord);
            }
            ++dictionarySize;
        }

        return result.ToArray();
    }  
    
    private List<int> GetCodes(byte[] input)
    {
        var buffer = new ByteBuffer();
        var dictionarySize = StartMaximumOfCodes;
        var currentMaximumOfCodes = StartMaximumOfCodes;

        for (var i = 0; i < input.Length - 1; ++i)
        {
            if (dictionarySize == currentMaximumOfCodes)
            {
                currentMaximumOfCodes *= 2;
                ++buffer.CurrentByteSize;
            }

            if (buffer.AddByteToDecompressedBytes(input[i]))
            {
                ++dictionarySize;
            }
        }
        buffer.AddIncompleteByteToDecompressedBytes(input[^1]);

        return buffer.DecompressedCodes;
    }
    
    
}
