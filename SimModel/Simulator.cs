using SimModel.Viruses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimModel
{
    public class Simulator
    {
        private const double _mortality = (double) 14 / 1000;
        private const double _birthrate = (double) 8 / 1000;

        private static Random rand = new Random();
        
        private List<Person> _alive;
        private List<Person> _dead;
        private int _maxDays;
        private int _day;
        private Virus _virus;
        private int _illed;
        private int _recovered;
        public int Days => _day;

        public int TotalPopulation => _alive.Count;
        public int DeadPopulation => _dead.Count;
        public int Illed => _illed;
        public int Recovered => _recovered;
        public Simulator(int count, int maxDays, Virus virus)
        {
            _alive = new List<Person>();
            _dead = new List<Person>();
            _day = 1;
            _maxDays = maxDays;
            _virus = virus;
            _illed = 0;
            _recovered = 0;
            Population(count);
        }
        public void RunSimulation()
        {
            StartInfection();
            for (int i = 1; i < _maxDays; i++)
            {
                _day = i;
                _alive.RemoveAll((p) =>
                {
                    if (!p.IsAlive)
                    {
                        _dead.Add(p);
                        return true;
                    }  
                    return false;
                });
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

                Infection();
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
            for (int i = 0; i < Math.Round(_alive.Count * 0.02); i++)
            {
                _alive.Find((p) => (p.Age >= _virus.AgeToInfect) && (!p.Status)).Infect();
                _illed++;
            }
            _alive = _alive.OrderBy(_ => rand.Next()).ToList();
        }
        private void Infection()
        {
            var allInfected = _alive.FindAll((p) => p.Status);
            foreach (Person p in allInfected)
            {
                if (_virus.Death(p)) continue;

                if (p.UpdateInfection() == _virus.DayToRecover)
                {
                    if (!_virus.Reinfection)
                        p.CreateTotalImmunity();
                    p.Recover();
                    _recovered++;
                    continue;
                }
                if (rand.Next(101) <= 28) continue;

                for (int i = 0; i < p.Friends / 2; i++)
                {
                    Person meeting = _alive[rand.Next(0, _alive.Count)];
                    if (!meeting.Status && meeting.Age >= _virus.AgeToInfect && !meeting.TotalImmunity)
                    {
                        _virus.Infect(meeting);
                        _illed++;
                    }
                }
            }
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
