namespace LZW;

/*

public class LZW
{
    private readonly int byteSize = 8;

    /// <summary>
    /// Method to encode byte array by LZW algorithm.
    /// </summary>
    /// <param name="arrayOfBytes">byte array that need to be encoded.</param>
    /// <returns>encoded byte array.</returns>
    public byte[] Compress(byte[] arrayOfBytes)
    {

        int currentPowerOfTwo = byteSize;
        int currentMaxNumberOfElementsInTrie = 256;

        var trie = new Trie();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte) i);
            trie.Add(newElement, i);
        }

        var newBytes = new List<byte>();
        var result = new List<byte>();
        var listOfCurrentBits = new List<bool>();

        for (int i = 0; i < arrayOfBytes.Length; ++i)
        {
            var elementToAdd = new List<byte>();

            elementToAdd.AddRange(newBytes);
            elementToAdd.Add(arrayOfBytes[i]);

            if (trie.Contains(elementToAdd))
            {
                newBytes = elementToAdd;
            }
            else
            {
                var key = trie.GetCode(newBytes);
                var bitsToAdd = BinaryConverter.ConvertIntToBits(currentPowerOfTwo, key);

                AddNewByte(bitsToAdd, ref listOfCurrentBits, result);

                if (trie.Size == currentMaxNumberOfElementsInTrie)
                {
                    ++currentPowerOfTwo;
                    currentMaxNumberOfElementsInTrie *= 2;
                }

                trie.Add(elementToAdd, trie.Size);

                newBytes.Clear();
                newBytes.Add(arrayOfBytes[i]);
            }
        }

         //var lastKey = trie.GetValueOfElement(newBytes);
         //var bitToAdd = BinaryConverter.ConvertIntToBits(currentPowerOfTwo, lastKey);

         //AddNewByte(bitToAdd, ref listOfCurrentBits, result);

        // if (!(listOfCurrentBits.Count == 0 || BinaryConverter.ConvertBitsToInt(listOfCurrentBits) == 0))
        // {
            // while (listOfCurrentBits.Count < byteSize)
            // {
                // listOfCurrentBits.Add(false);
            // }

            // result.Add((byte)BinaryConverter.ConvertBitsToInt(listOfCurrentBits));
        // }

        return result.ToArray();
    }
    
    private void AddNewByte(List<bool> bitsToAdd, ref List<bool> listOfCurrentBits, List<byte> result)
    {
        while (bitsToAdd.Count + listOfCurrentBits.Count >= byteSize)
        {
            while (listOfCurrentBits.Count < byteSize)
            {
                var firstElement = bitsToAdd.First();
                bitsToAdd.RemoveAt(0);
                listOfCurrentBits.Add(firstElement);
            }

            result.Add((byte)BinaryConverter.ConvertBitsToInt(listOfCurrentBits));
            listOfCurrentBits.Clear();
        }

        listOfCurrentBits = bitsToAdd;
    }
    
    private int currentPowerOfTwoD = 8;
    private int currentMaxNumberOfElementsInDictionaryD = 256;
    
    /// <summary>
    /// Method to decode byte array by LZW algorithm.
    /// </summary>
    /// <param name="arrayOfBytes">array of bytes that need to be decoded.</param>
    /// <returns>decoded array of bytes.</returns>
    public byte[] Decompress(byte[] arrayOfBytes)
    {
        var listOfBytes = arrayOfBytes.ToList();

        var dictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte) i);
            dictionary.Add(i, newElement);
        }

        var result = InverseLZW(listOfBytes, dictionary);

        return result.ToArray();
    }

    private List<byte> InverseLZW(List<byte> listOfBytes, Dictionary<int, List<byte>> dictionary)
    {
        /*
        var newBytes = new List<byte>();
        var result = new List<byte>();
        
        for (int i = 0; i < listOfBytes.Count; ++i)
        {
            if (dictionary.Count == currentMaxNumberOfElementsInDictionaryD)
            {
                ++currentPowerOfTwoD;
                currentMaxNumberOfElementsInDictionaryD *= 2;
            }
            
            var elementToAdd = new List<byte>();

            elementToAdd.AddRange(newBytes);
            elementToAdd.Add(listOfBytes[i]);

            if (dictionary.ContainsKey(elementToAdd))
            {
                newBytes = elementToAdd;
            }
            else
            {

                dictionary.Add(elementToAdd, trie.Size);

                newBytes.Clear();
                newBytes.Add(arrayOfBytes[i]);
            }
        }
        */
        /*
        var firstByte = new List<byte>();
        firstByte.Add(listOfBytes.First());
        listOfBytes.RemoveAt(0);

        var result = new List<byte>();
        result.Add(firstByte[0]);

        var currentByte = new List<bool>();
        var remainingBits = new List<bool>();

        foreach (var element in listOfBytes)
        {
            if (dictionary.Count == currentMaxNumberOfElementsInDictionaryD)
            {
                ++currentPowerOfTwoD;
                currentMaxNumberOfElementsInDictionaryD *= 2;
            }

            if (!PrepareNewByte(element, remainingBits, currentByte))
            {
                continue;
            }

            int newKey = BinaryConverter.ConvertBitsToInt(currentByte);

            currentByte.Clear();

            List<byte> entry = new List<byte>();
            if (dictionary.ContainsKey(newKey))
            {
                entry.AddRange(dictionary[newKey]);
            }
            else
            {
                entry.AddRange(firstByte);
                entry.Add(firstByte[0]);
            }

            result.AddRange(entry);

            var newElement = new List<byte>();

            newElement.AddRange(firstByte);
            newElement.Add(entry[0]);
            dictionary.Add(dictionary.Count, newElement);

            firstByte = entry;
        }
        

        return result;
    }

    private bool PrepareNewByte(byte element, List<bool> remainingBits, List<bool> currentByte)
    {
        var newByte = BinaryConverter.ConvertIntToBits(byteSize, element);
        while (newByte.Count > 0)
        {
            remainingBits.Add(newByte.ElementAt(0));
            newByte.RemoveAt(0);
        }

        if (remainingBits.Count < currentPowerOfTwoD)
        {
            return false;
        }

        while (currentByte.Count < currentPowerOfTwoD)
        {
            currentByte.Add(remainingBits.ElementAt(0));
            remainingBits.RemoveAt(0);
        }

        return true;
    }
    
    
}

*/