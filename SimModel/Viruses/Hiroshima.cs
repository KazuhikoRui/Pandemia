using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimModel.Viruses
{
    class Hiroshima : Virus
    {
        private static Random _rand = new Random();
        
        public Hiroshima(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {
            _lethality = LethalityCoef + (float)_rand.Next(-5, 5) / 100;
        }
        public override int AgeToInfect => 32;

        public override int DayToRecover => 3;

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
