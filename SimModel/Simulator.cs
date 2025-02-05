using System;
using System.Collections.Generic;

namespace SimModel
{
    class Simulator
    {
        private const double _mortality = (double) 16 / 1000;
        private const double _birthrate = (double) 8 / 1000;

        private static Random rand = new Random();
        private List<Person> _alive;
        private List<Person> _dead;
        private int _maxDays;
        private int _day;

        public int MaxDays => _maxDays;

        public Simulator(int count, int maxDays)
        {
            _alive = new List<Person>();
            _dead = new List<Person>();
            _day = 0;
            _maxDays = maxDays;
            Population(count);
        }

        public void RunSimulation()
        {
            for (int i = 0; i < _maxDays; i++)
            {
                _day = i;
                _alive.RemoveAll((p) =>
                {
                    p.UpdateAge();
                    if (p.Age >= 29200)
                    {
                        _dead.Add(p);
                        return true;
                    }
                    return false;
                });
            }
            Console.WriteLine("End");
        }

        private void UpdatePopulation(int Start, int Count)
        {
            List<Person> list = _alive.GetRange(Start, Count);
            foreach (Person person in list)
            {
                _dead.Add(person);
                _alive.Remove(person);
            }
        }

        private void Population(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Person newPerson = new Person(
                    rand.Next(0, 2) == 0 ? "Ж" : "М",
                    rand.Next(0, 29201),
                    (float)rand.Next(65, 76) / 100
                    );
                if (newPerson.Age >= 29200)
                    _dead.Add(newPerson);
                else
                    _alive.Add(newPerson);
            }
        }
    }
}
