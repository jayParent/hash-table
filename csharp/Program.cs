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
            FillWithDict();
        }

        private static void Run()
        {
            HashTable hashTable = new HashTable();
            FillWithDict();

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
        private static void FillWithDict()
        {
            string word;
            
            HashTable hashTable = new HashTable();

            while ((word = Dictionnaire.ReadLine()) != null)
            {
                hashTable.Add(word);
            }

            hashTable.Add("aa");
            Dictionnaire.Close();
            var positions = hashTable.Find("aa");
            hashTable.ShowTableInfo();
        }
    }
}
