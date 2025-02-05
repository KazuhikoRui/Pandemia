using SimModel.Interfaces;


namespace SimModel.Viruses
{
    abstract class Virus : IVirus
    {
        protected string _code;
        protected bool _reinfection;
        protected float _infection;
        protected float _lethality;
        public Virus(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef)
        {
            _code = Code;
            _reinfection = Reinfection;
            _infection = InfectionCoef;
            _lethality = LethalityCoef;
        }

        public string Code { get => _code; }
        public bool Reinfection { get => _reinfection; }
        public float Infection { get => _infection; }
        public float Lethality { get => _lethality; }

        public abstract int AgeToInfect { get; }

        public abstract bool Death(Person person);
        public abstract void Infect(Person person);
    }
}
