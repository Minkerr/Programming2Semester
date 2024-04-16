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
        var currentPhrase = new List<byte>();
        var currentMaximumOfCodes = StartMaximumOfCodes;
        
        for (var i = 0; i < input.Length; ++i)
        {
            var currentPhraseWithExtraByte = new List<byte>();
            currentPhraseWithExtraByte.AddRange(currentPhrase);
            currentPhraseWithExtraByte.Add(input[i]);

            if (trie.Contains(currentPhraseWithExtraByte))
            {
                currentPhrase = currentPhraseWithExtraByte;
            }
            else
            {
                if (trie.Size == currentMaximumOfCodes)
                {
                    currentMaximumOfCodes *= 2;
                    ++buffer.CurrentByteSize;
                }
                
                buffer.AddCodeToCompressedBytes(trie.GetValue(currentPhrase));
                trie.Add(currentPhraseWithExtraByte);
                currentPhrase.Clear();
                currentPhrase.Add(input[i]);
            }
        }
        buffer.AddCodeToCompressedBytes(trie.GetValue(currentPhrase));
        buffer.AddIncompleteByteToCompressedBytes();
        
        return buffer.CompressedBytes.ToArray();
    }
    
    /// <summary>
    /// Decompress input array of compressed bytes.
    /// </summary>
    public byte[] Decompress(byte[] input)
    {
        var decompressedBytes = new List<byte>();
        var phraseDictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            phraseDictionary[i] = new List<byte>();
            phraseDictionary[i].Add((byte) i);
        }
        
        List<int> phraseCodes = GetPhraseCodes(input);
        var nextAvailableCode = StartMaximumOfCodes;
        decompressedBytes.AddRange(phraseDictionary[phraseCodes[0]]);

        for (var i = 1; i < phraseCodes.Count; ++i)
        {
            var currentPhrase = new List<byte>(phraseDictionary[phraseCodes[i - 1]]);
            if (phraseDictionary.ContainsKey(phraseCodes[i]))
            {
                while (phraseDictionary.ContainsKey(nextAvailableCode))
                {
                    ++nextAvailableCode;
                }
                currentPhrase.Add(phraseDictionary[phraseCodes[i]][0]);
                phraseDictionary.Add(nextAvailableCode++, currentPhrase);
                decompressedBytes.AddRange(phraseDictionary[phraseCodes[i]]);
            }
            else
            {
                currentPhrase.Add(phraseDictionary[phraseCodes[i - 1]][0]);
                phraseDictionary.Add(phraseCodes[i], currentPhrase);
                decompressedBytes.AddRange(currentPhrase);
            }
        }

        return decompressedBytes.ToArray();
    }  
    
    private List<int> GetPhraseCodes(byte[] input)
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
