using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator sim = new Simulator(1000000, 3650);
            sim.RunSimulation();
        }
    }
}
