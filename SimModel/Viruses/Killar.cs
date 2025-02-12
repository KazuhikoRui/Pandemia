using System;

namespace SimModel.Viruses
{
    class Killar : Virus
    {
        private static Random rand = new Random();
        public Killar(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {
            _lethality = LethalityCoef + (float)rand.Next(-10, 10) / 100;
        }

        public override int AgeToInfect => 12;
        public override int DayToRecover => 7;

        public override bool Death(Person person)
        {
            if (rand.NextDouble() <= Lethality)
            {
                person.Death();
                return true;
            }
            return false;
        }

        public override void Infect(Person person)
        {
            if (person.Immunity <= Infection)
                person.Infect();
        }
    }
}
