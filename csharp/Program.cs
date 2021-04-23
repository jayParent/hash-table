using System;
using System.Collections.Generic;
using System.IO;

namespace csharp
{
    class Program
    {
        public static Dictionary<string, string> Prompts = new Dictionary<string, string>
        {
            {"operations", "1: Ajouter\n2: Rechercher\n3: Supprimer\n4: Quitter\n"},
            {"word", "Entrez le mot: "}
        };
        private static StreamReader Dictionnaire = new StreamReader("dictionnaire.txt");

        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable();
            FillWithDict(hashTable);
            hashTable.Delete("a");
        }

        private static void Run()
        {
            HashTable hashTable = new HashTable();
            FillWithDict(hashTable);

            while (true)
            {
                Console.WriteLine($"{Prompts["operations"]}");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write($"{Prompts["word"]}");
                        string word = Console.ReadLine();
                        hashTable.Add(word);

                        break;

                    case "4":
                        break;
                }

                break;
            }
        }
        private static void FillWithDict(HashTable hashTable)
        {
            string word;

            while ((word = Dictionnaire.ReadLine()) != null)
            {
                hashTable.Add(word);
            }

            hashTable.Add("a");
            Dictionnaire.Close();
            var positions = hashTable.Find("aa");
            hashTable.ShowTableInfo();
        }
    }
}
