using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personagem_RPG.src
{
    public class Sorcerer : Personagem
    {
        public Sorcerer(string nome)
        {
            Name = nome;
            Level = 1;
            AddDexterityPoints(15);
            AddVitalityPoints(15);
            AddIntelligencePoints(25);
            AddStrengthPoints(5);
        }

        public override string ToString()
        {
            return $"Classe Feiticeiro \n" +
                   $"Nome: {Name}\n" +
                   $"Level: {Level}\n" +
                   $"Pontos de Vitalidade: {VitalityAttribute} \n" +
                   $"Pontos de Força: {StrengthAttribute} \n" +
                   $"Pontos de Destreza: {DexterityAttribute} \n" +
                   $"Pontos de Inteligência: {IntelligenceAttribute} \n" +
                   $"Pontos de HP:{HPMax}\n" +
                   $"Pontos de MP:{MPMax}";
        }
    }
}
