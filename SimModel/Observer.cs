using System;
using System.Threading;

namespace SimModel
{
    public class Observer
    {
        private Simulator _simulator;

        public event Action<Simulator> OnEndSimulation;
        public Observer(ref Simulator simulator)
        {
            _simulator = simulator;
        }

        public void Start()
        {
            var SimThread = new Thread(_simulator.RunSimulation);
            SimThread.Start();

            var ExitThread = new Thread(() => EarlyExit(SimThread));
            ExitThread.Start();

            SimThread.Join();
            OnEndSimulation?.Invoke(_simulator);
        }

        private void EarlyExit(Thread t)
        {
            while (t.IsAlive)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter && t.IsAlive)
                {
                    t.Abort();
                }
            }
        }
    }
}
