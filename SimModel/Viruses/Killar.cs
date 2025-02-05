namespace SimModel.Viruses
{
    class Killar : Virus
    {
        public Killar(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {

        }

        public override int AgeToInfect => 12;

        public override bool Death(Person person)
        {
            throw new System.NotImplementedException();
        }

        public override void Infect(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}
