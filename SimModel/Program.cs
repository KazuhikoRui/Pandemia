using SimModel.Viruses;
using System;
using System.Threading;

namespace SimModel
{
    class Program
    {
        private static int _population;
        private static int _days;
        static void Main(string[] args)
        {
            Virus virus = new Killar("Killar-86X", false, 0.3f, 0.001f);

            InputManager();

            Simulator sim = new Simulator(_population, _days, virus);
            Observer observer = new Observer(ref sim);
            observer.OnEndSimulation += Results;
            observer.Start();
        }

        private static void InputManager()
        {
            Console.Write("Введите кол-во человек в популяции: ");
            _population = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во дней симуляции: ");
            _days = int.Parse(Console.ReadLine());
            Console.WriteLine("Для досрочного завершения работы программы нажмите Enter");
        }

        private static void Results(Simulator simulator)
        {
            Console.WriteLine($"Популяция: {simulator.TotalPopulation}");
            Console.WriteLine($"Кол-во смертей: {simulator.DeadPopulation}");
            Console.WriteLine($"Кол-во заражений: {simulator.Illed}");
            Console.WriteLine($"Кол-во выздаровлений: {simulator.Recovered}");
            if (_days + 1 != simulator.Days)
                Console.WriteLine($"Кол-во дней: {simulator.Days}");
        }
    }
}
