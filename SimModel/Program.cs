using SimModel.Utils;
using SimModel.Viruses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimModel
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            Virus virus = new Killar("Killar-86X", false, 0.3f, 0.001f); 
            Simulator sim = new Simulator(1000000, 3650, virus);
            sim.RunSimulation();
            Console.WriteLine(sim.InfectedPpopulation());
        }
    }
}
