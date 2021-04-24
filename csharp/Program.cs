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
            Run();
        }

        private static void Run()
        {
            HashTable hashTable = new HashTable();
            FillWithDict(hashTable);
            hashTable.ShowTableInfo();
            bool running = true;

            while (running)
            {
                Console.WriteLine($"{Prompts["operations"]}");
                string input = Console.ReadLine();
                string word = "";

                switch (input)
                {
                    case "1":
                        Console.Write($"{Prompts["word"]}");
                        word = Console.ReadLine();
                        hashTable.Add(word);
                        hashTable.ShowTableInfo();
                        break;
                    
                    case "2":
                        Console.Write($"{Prompts["word"]}");
                        word = Console.ReadLine();
                        hashTable.Find(word);
                        break;

                    case "3":
                        Console.Write($"{Prompts["word"]}");
                        word = Console.ReadLine();
                        hashTable.Delete(word);
                        hashTable.ShowTableInfo();
                        break;

                    case "4":
                        running = false;
                        break;
                }
            }
        }
        private static void Test()
        {
            HashTable hashTable = new HashTable();
            FillWithDict(hashTable);
            hashTable.ShowTableInfo();
        }
        private static void FillWithDict(HashTable hashTable)
        {
            string word;

            while ((word = Dictionnaire.ReadLine()) != null)
            {
                hashTable.Add(word);
            }

            Dictionnaire.Close();
        }
    }
}
