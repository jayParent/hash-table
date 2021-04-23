using System;
using System.Collections.Generic;
using System.Linq;

public class HashTable
{
    public List<string>[] Table { get; set; }
    public int Size { get; set; } = 1000;

    public HashTable()
    {
        Table = new List<string>[Size];
    }
    ~HashTable()
    {
        Table = null;
    }
    private ulong Hash(char[] buffer, uint n)
    {
        ulong sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += buffer[i];
        }

        return sum;
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
        }
        else
        {
            Table[h].Add(word);
        }

    }
    public List<int[]> Find(string word)
    {
        char[] buffer = word.ToCharArray();
        uint n = (uint)buffer.Length;
        ulong h = Hash(buffer, n);
        List<int[]> position = GetPositions(word, h);

        return position;

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
    }
    public void ShowTableInfo()
    {
        int filledSlots = 0;

        for (int i = 0; i < Table.Length; i++)
        {
            if (Table[i] != null)
                filledSlots++;
        }

        Console.WriteLine($"{filledSlots}");
    }
}