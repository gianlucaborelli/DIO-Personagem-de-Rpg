using System;
using Personagem_RPG.src;

namespace Personagem_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Paladin paladin = new("Gianluca Borelli");
            Sorcerer sorcerer = new("Isadora Martins");
            Archer archer = new("Zé");
            
            Console.WriteLine(paladin.ToString());
            Console.WriteLine();
            Console.WriteLine(sorcerer.ToString());
            Console.WriteLine();
            Console.WriteLine(archer.ToString());

            Console.ReadLine();
        }
    }
}
