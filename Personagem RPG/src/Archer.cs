using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personagem_RPG.src
{
    internal class Archer : Personagem
    {
        public Archer(string nome)
        {
            Name = nome;
            Level = 1;
            AddDexterityPoints(25);
            AddVitalityPoints(15);
            AddIntelligencePoints(5);
            AddStrengthPoints(15);
        }

        public override string ToString()
        {
            return $"Classe Arqueiro \n" +
                   $"Nome: {Name}\n" +
                   $"Level: {Level}\n" +
                   $"Pontos de Vitalidade: {VitalityAttribute} \n" +
                   $"Pontos de Força: {StrengthAttribute} \n" +
                   $"Pontos de Destreza: {DexterityAttribute} \n" +
                   $"Pontos de Inteligência: {IntelligenceAttribute} \n" +
                   $"Pontos de HP:{HPMax}\n" +
                   $"Pontos de MP:{MPMax}\n";
        }

    }
}
