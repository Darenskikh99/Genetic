using System;
using System.Collections.Generic;

namespace Genetic
{
    internal class DataPopulation
    {
        public double x1Left;
        public double x1Right;
        public double x2Left;
        public double x2Right;
        public int sizeOfPopulation;
        public int numberOfPopulation;
        public double probabilityMutation;
        public string function;
        public int amountOfBits = 10;

        public DataPopulation (string x1Left, string x1Right, string x2Left, string x2Right,
            string sizeOfPopulation, string numberOfPopulation, string probabilityMutation, string function)
        {
            this.x1Left = double.Parse(x1Left);
            this.x1Right = double.Parse(x1Right) ;
            this.x2Left = double.Parse(x2Left) ;
            this.x2Right = double.Parse(x2Right) ;
            this.sizeOfPopulation = int.Parse(sizeOfPopulation) ;
            this.numberOfPopulation = int.Parse(numberOfPopulation) ;
            this.probabilityMutation = double.Parse(probabilityMutation) ;
            this.function = function;
        }

        public List<Individual> Create()
        {
            var rndValue = new Random();
            var newPopulation = new List<Individual>(sizeOfPopulation);
            for (var i = 0; i < sizeOfPopulation; i++)
            {
                newPopulation.Add(new Individual());
                newPopulation[i].x1Value = rndValue.NextDouble() * (x1Right - x1Left) + x1Left;
                newPopulation[i].x2Value = rndValue.NextDouble() * (x2Right - x2Left) + x2Left;
            }
            return newPopulation;
        }
    }
}
