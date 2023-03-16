using System;
using System.Collections.Generic;

namespace Genetic
{
    internal class Selection
    {
        public List<Individual> SelectIndividuals(List<Individual> population)
        {
            var newPopulation = new List<Individual>(population.Count);
            var randomIndividual = new Random();

            for (var i = 0; i < population.Count; i++)
            {
                int rndInd1;
                int rndInd2;
                do
                {
                    rndInd1 = randomIndividual.Next(0, population.Count);
                    rndInd2 = randomIndividual.Next(0, population.Count);
                }
                while (rndInd1 == rndInd2);
                if (population[rndInd1].funcValue < population[rndInd2].funcValue)
                {
                    newPopulation.Add(population[rndInd1]);
                }
                else
                {
                    newPopulation.Add(population[rndInd2]);
                }
            }
            return newPopulation;
        }
    }
}
