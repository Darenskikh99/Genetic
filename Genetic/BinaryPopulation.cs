using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic
{
    internal class BinaryPopulation
    {
        public List<BinaryIndividual> Create(List<Individual> population, DataPopulation dataPopulation)
        {
            var randomIndividual = new Random();
            var rnd1 = 0;
            var rnd2 = 0;
            var binaryPopulation = new List<BinaryIndividual>();

            for(var i = 0; i < population.Count; i++)
            {
                do
                {
                    rnd1 = randomIndividual.Next(population.Count);
                    rnd2 = randomIndividual.Next(population.Count);
                }
                while (rnd1 == rnd2);

                var c = new Convert();
                var random1BinaryIndividual = c.ConvertToBinary(population[rnd1], dataPopulation);
                var random2BinaryIndividual = c.ConvertToBinary(population[rnd2], dataPopulation);

                var binaryCrossing = new Crossing();
                var binaryChild = binaryCrossing.BinaryCrossing(random1BinaryIndividual, random2BinaryIndividual, dataPopulation);

                binaryPopulation.Add(binaryChild);
            }
            return binaryPopulation;
        }
    }
}
