using System;
using System.Collections.Generic;
using System.Linq;

public class HashTable
{
    public List<string>[] Table { get; set; }
    public ulong Items { get; set; }
    public ulong Size { get; set; }
    public double LoadFactor { get; set; }
    public const ulong Magie = 173773926194192273;
    public const ulong Prime = 67430303149321687;

    public HashTable(ulong size = 10000)
    {
        Size = size;
        Table = new List<string>[Size];
    }
    private ulong CutDeck(ulong h)
    {
        return h << 32 | h >> 32;
    }
    private ulong Bricolage(char[] buffer, uint n) // Pour comparaison
    {
        ulong h = 0;

        for (int i = 0; i < n; i++)
        {
            h = CutDeck(h) + (buffer[i] * Magie);
        }

        return h % Size;
    }
    private ulong CheckSum(char[] buffer, uint n) // Pour comparaison
    {
        ulong sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += buffer[i];
        }

        return sum;
    }
    private ulong Hash(char[] buffer, uint n)
    {
        ulong h = 0;

        for (int i = 0; i < n; i++)
        {
            h = (buffer[i] * Prime) + h ^ buffer[i] + (h << buffer[i] | h >> buffer[i]);
        }

        return h % Size;
    }
    public void Add(string word)
    {
        char[] buffer = word.ToCharArray();
        uint n = (uint)buffer.Length;
        ulong h = Hash(buffer, n);

        if (Table[h] == null)
        {
            Table[h] = new List<string>();
            Table[h].Add(word);
            Items++;
        }
        else
        {
            if(!Table[h].Contains(word)){
                Table[h].Add(word);
                Items++;
            }
        }
        
        
        LoadFactor = (double)Items / (double)Size;
    }

    public List<int[]> Find(string word)
    {
        char[] buffer = word.ToCharArray();
        uint n = (uint)buffer.Length;
        ulong h = Hash(buffer, n);
        List<int[]> positions = GetPositions(word, h);
        string positionString = BuildPositionString(positions);

        if (positions.Count > 0)
            Console.WriteLine($"Mot: {word}\n{positionString}");
        else
            Console.WriteLine($"Mot: {word} pas trouv??.");
            

        return positions;

    }
    private List<int[]> GetPositions(string word, ulong h)
    {
        int tablePosition = (int)h;
        int listPosition = 0;
        List<int[]> positions = new List<int[]>();

        for (int i = 0; i < Table[tablePosition].Count; i++)
        {
            if (Table[tablePosition][i] == word)
            {
                int[] position = new int[2];
                listPosition = i;
                position[0] = tablePosition;
                position[1] = listPosition;
                positions.Add(position);
            }
        }

        return positions;
    }

    private static string BuildPositionString(List<int[]> positions)
    {
        string positionsString = "";

        for (int i = 0; i < positions.Count; i++)
        {
            int[] position = positions[i];
            positionsString += $"[{position[0]}, {position[1]}]\n";
        }

        return positionsString;
    }

    public void Delete(string word)
    {
        List<int[]> positions = Find(word);

        for (int i = 0; i < positions.Count; i++)
        {
            int tablePosition = positions[i][0];
            int listPosition = positions[i][1];

            Table[tablePosition][listPosition] = null;

            if (Table[tablePosition].Where(el => el != null).Count() > 0)
                continue;
            else
                Table[tablePosition] = null;
        }

        Items -= 1;
        Console.WriteLine($"Mot: {word} supprim??.");

    }
    public void ShowTableInfo()
    {
        int filledSlots = 0;
        int min = Int32.MaxValue;
        int max = 0;
        int total = 0;

        for (int i = 0; i < Table.Length; i++)
        {
            if (Table[i] != null)
            {
                filledSlots++;

                if (Table[i].Count < min)
                    min = Table[i].Count;

                if (Table[i].Count > max)
                    max = Table[i].Count;
            }

            if (Table[i] != null)
                total += Table[i].Count;
        }

        Console.WriteLine($"Items: {Items}\nLoad Factor: {LoadFactor}\nFilled: {filledSlots}\nMin Collisions: {min}\nMax Collisions: {max}\n");
    }
}