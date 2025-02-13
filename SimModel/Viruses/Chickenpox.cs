using System;


namespace SimModel.Viruses
{
    class Chickenpox : Virus
    {
        private static Random _rand = new Random();

        public Chickenpox(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {
            _lethality = LethalityCoef + (float)_rand.Next(-30, 30) / 100;
        }
        public override int AgeToInfect => 3;

        public override int DayToRecover => 14;

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
