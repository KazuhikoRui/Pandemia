using System;

namespace SimModel.Viruses
{
    class Vanilla228 : Virus
    {
        private static Random _rand = new Random();

        public Vanilla228(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {
            _lethality = LethalityCoef + (float)_rand.Next(-15, 15) / 100;
        }
        public override int AgeToInfect => 7;
        public override int DayToRecover => 21;
        
        public override bool Death(Person person) => false;
        public override void Infect(Person person)
        {
            if (person.Immunity <= Infection)
                person.Infect();
        }
    }
}
