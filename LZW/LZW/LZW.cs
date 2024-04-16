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
    /// Decodes input array of compressed bytes.
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
        var dictionaryPointer = StartMaximumOfCodes;
        var dictionarySize = StartMaximumOfCodes;
        var sequence = new List<byte>();

        for (var i = 0; i < codes.Count; ++i)
        {
            if (dictionary.ContainsKey(codes[i]))
            {
                if (dictionarySize != StartMaximumOfCodes)
                {
                    while (dictionary.ContainsKey(dictionaryPointer))
                    {
                        ++dictionaryPointer;
                    }

                    sequence = new List<byte>(dictionary[codes[i - 1]]) { dictionary[codes[i]][0] };

                    dictionary.Add(dictionaryPointer++, sequence);
                }

                result.AddRange(dictionary[codes[i]]);
            }
            else
            {
                sequence = new List<byte>(dictionary[codes[i - 1]]) { dictionary[codes[i - 1]][0] };

                dictionary.Add(codes[i], sequence);
                result.AddRange(sequence);
            }
            ++dictionarySize;
        }

        return result.ToArray();
    }  
    
    private List<int> GetCodes(byte[] input)
    {
        var buffer = new ByteBuffer();
        var dictionarySize = StartMaximumOfCodes;
        var currentMaximumAmountOfCodesNumber = StartMaximumOfCodes;

        for (var i = 0; i < input.Length - 1; ++i)
        {
            if (dictionarySize == currentMaximumAmountOfCodesNumber)
            {
                currentMaximumAmountOfCodesNumber *= 2;
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
