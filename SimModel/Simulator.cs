using SimModel.Viruses;
using System;
using System.Collections.Generic;

namespace SimModel
{
    class Simulator
    {
        private const double _mortality = (double) 14 / 1000;
        private const double _birthrate = (double) 8 / 1000;

        private static Random rand = new Random();
        
        private List<Person> _alive;
        private List<Person> _dead;
        private int _maxDays;
        private int _day;
        private Virus _virus;
        public int Days => _day;

        public int TotalPopulation => _alive.Count;
        public Simulator(int count, int maxDays, Virus virus)
        {
            _alive = new List<Person>();
            _dead = new List<Person>();
            _day = 1;
            _maxDays = maxDays;
            _virus = virus;
            Population(count);
        }

        public void RunSimulation()
        {
            StartInfection();
            for (int i = 1; i < _maxDays; i++)
            {
                _day = i;
                if (i % 365 == 0)
                    _alive.RemoveAll((p) =>
                    {
                        p.UpdateAge();
                        if (p.Age >= p.MaxAge)
                        {
                            _dead.Add(p);
                            return true;
                        }
                        return false;
                    });
                
                //Заражаемость!
                
                Mortality();
                Birth();
            }
        }

        private void Mortality()
        {
            int mort = (int)Math.Round(_mortality * _alive.Count / 365);
            List<Person> toDead = _alive.GetRange(0, mort);
            _alive.RemoveRange(0, mort);
            _dead.AddRange(toDead);
        }
        private void Birth()
        {
            int birth = (int)Math.Round(_birthrate * _alive.Count / 365);
            for (int i = 0; i < birth; i++)
            {
                Person newPerson = new Person(
                    rand.Next(0, 2) == 0 ? "Ж" : "М", 0,
                    (float)rand.Next(65, 76) / 100);
                _alive.Add(newPerson);
            }
        } 
        private void StartInfection()
        {
            //Пусть 2% населения уже будут заражены.
            //И желательно, чтобы больны были люди от N лет
            // N необходимо указывать в вирусе
        }
        private void Infection()
        {

        }
        private void Population(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Person newPerson = new Person(
                    rand.Next(0, 2) == 0 ? "Ж" : "М",
                    rand.Next(0, 81),
                    (float)rand.Next(65, 76) / 100
                    );
                if (newPerson.Age >= newPerson.MaxAge)
                    _dead.Add(newPerson);
                else
                    _alive.Add(newPerson);
            }
        }
    }
}
