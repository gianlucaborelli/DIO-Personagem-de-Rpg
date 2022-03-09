using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personagem_RPG.src
{
    public abstract class Personagem
    {

                                                 /*Regras de Jogo

            O level do personagem será de 1 ao maximo de 50.
            A cada Level do personagem será permitido distribuir 1 ponto de atributo a escolha do Jogador.

            - Pontos de Vitaliade dará ao personagem pontos de HP e um aumento na taxa de defesa.
            - Pontos de Força aumentará a força do ataque físico e acrescenta pontos de HP.
            - Pontos de Inteligencia aumentará a força de ataque magico e acrescenta pontos de MP.
            - Pontos de Destreza aumentará a Precisão e a chance de defesa.
            
            O Jogo sera baseado em turno, sendo que enquanto um personagem ataca, outro defende*/




        public string Name { get; set; }
        public int Level { get; set; }
        public int AttributePointsToDistribute { get; private set; }
        public int ExperiencePoint { get; private set; }
        public int ExperiencePointForNextLevel { get; private set; }
        public int VitalityAttribute { get; private set; }
        public int StrengthAttribute { get; private set; }
        public int IntelligenceAttribute { get; private set; }
        public int DexterityAttribute { get; private set; }
        public double HPActual { get; private set; }
        public double HPMax { get; private set; }
        public double MPActual { get; private set; }
        public double MPMax { get; private set; }
        public double PhysicalAttackPower { get; private set; }
        public double MagicAttackPower { get; private set; }
        public double DefensePower { get; private set; } //in percentage       
        public double Accuracy { get; private set; } //in percentage

        public enum Attribute
        {
            Vitality, Strength, Intelligence, Dexterity
        }

        protected void AddDexterityPoints(int points)
        {
            DexterityAttribute += points;
            RecalculateProperties();
        }

        protected void AddIntelligencePoints(int points)
        {
            IntelligenceAttribute += points;
            RecalculateProperties();
        }

        protected void AddStrengthPoints(int points)
        {
            StrengthAttribute += points;
            RecalculateProperties();
        }

        protected void AddVitalityPoints(int points)
        {
            VitalityAttribute += points;
            RecalculateProperties();
        }

        private void IncreasesExperience(int experienceToIncrease)
        {
            if ((experienceToIncrease + ExperiencePoint) >= ExperiencePointForNextLevel)
            {
                ExperiencePoint = (experienceToIncrease + ExperiencePoint) - ExperiencePointForNextLevel;
                LevelUp();
            }
            else
            {
                ExperiencePoint += experienceToIncrease;
            }
        }

        private void LevelUp()
        {
            AttributePointsToDistribute += 1;
            Level += 1;
            CalculateExperienceForNextLevel();
        }

        private void CalculateExperienceForNextLevel()
        {
            if(Level <= 50)
            {
                double experience = Math.Pow((Level * 100), 1.2);

                ExperiencePointForNextLevel = Convert.ToInt32(experience);
            }
        }

        private void DistributeAttributePoints (Attribute attribute, int amountOfPoints)
        {
            if ((amountOfPoints <= AttributePointsToDistribute) &&
                (amountOfPoints > 0))
            {
                switch (attribute)
                {
                    case Attribute.Dexterity:
                        AddDexterityPoints(amountOfPoints);
                        break;
                    case Attribute.Intelligence:
                        AddIntelligencePoints(amountOfPoints);
                        break;
                    case Attribute.Strength:
                        AddStrengthPoints(amountOfPoints);
                        break;
                    case Attribute.Vitality:
                        AddVitalityPoints(amountOfPoints);
                        break;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }            
        }        

        private void CalculateHpMaxPoints()
        {
            HPMax = (Level * 2) + (VitalityAttribute * 5) + (StrengthAttribute * 2);
        }
        
        private void CalculatePhysicalAttackPower()
        {
            PhysicalAttackPower = (Level * 0.25) + (StrengthAttribute * 2.5);
        }       

        private void CalculateDefensePower()
        {
            DefensePower = (30 + Math.Pow(2, (Level / 11.75)) + (DexterityAttribute * (50 / 70))) / 100;
        }

        private void CalculateAccuracy()
        {
            Accuracy = (50 + Math.Pow(2, (Level / 11.75)) + (DexterityAttribute * (30 / 70))) / 100;
        }

        private void CalculateMagicAttackPower()
        {
            MagicAttackPower = (Level * 0.25) + (IntelligenceAttribute * 2.5);
        }

        private void CalculateMpMaxPoints()
        {
            MPMax = (Level * 2) + (IntelligenceAttribute * 5) + (DexterityAttribute * 1.5);
        }

        private void RecalculateProperties()
        {
            CalculateHpMaxPoints();
            CalculatePhysicalAttackPower();
            CalculateDefensePower();
            CalculateAccuracy();
            CalculateMagicAttackPower();
            CalculateMpMaxPoints();
        }

        private void CalculateReceivedDamage(double damage) 
        {
            HPActual = HPActual - damage;
        }

        private void CalculateMpUsed (double mpUsed)
        {
            MPActual = MPActual - mpUsed;
        }
    }
}
