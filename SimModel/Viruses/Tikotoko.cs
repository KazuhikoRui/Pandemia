using System;

namespace SimModel.Viruses
{
    class Tikotoko : Virus
    {
        private static Random _rand = new Random();

        public Tikotoko(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {
            _lethality = LethalityCoef;
        }
        public override int AgeToInfect => 5;

        public override int DayToRecover => 120;

        public override bool Death(Person person)
        {
            if (_rand.NextDouble() <= Lethality)
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
