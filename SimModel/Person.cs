namespace SimModel
{
    class Person
    {
        private const float _coefLostImmunity = 0.000017f; //Коэффициент потери иммунитета

        private string _gender; //Пол человека
        private int _age; //Измеряем в днях (365д = 1г)
        private float _initialImmunity; //Врожденный иммунитет
        private float _immunity; //Иммунитет
        private bool _totalImmunity; //Абсолютный иммунитет к вирусу
        private bool _isAlive; //Жив или мертв

        public int Age => _age;
        public string Gender => _gender;
        public float Immunity => _immunity;
        public bool TotalImmunity => _totalImmunity;
        public bool IsAlive => _isAlive;
        public bool Status { get; set; }

        public Person(string Gender, int Age, float Immunity)
        {
            _gender = Gender;
            _age = Age; 
            _initialImmunity = Immunity;
            _totalImmunity = false;
            _isAlive = true;

            Status = false;
            UpdateImmunity();
        }

        public void UpdateAge()
        {
            _age++;
            if (Age >= 29200) Death();
            UpdateImmunity();
        }

        public void Death() => _isAlive = false;
        public void CreateTotalImmunity()
        {
            _totalImmunity = true;
        }
        private void UpdateImmunity()
        {
            if (!_isAlive) return;
            _immunity = _initialImmunity - _coefLostImmunity * _age;
        }
    }
}
