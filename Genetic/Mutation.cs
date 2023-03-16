using System;
using System.Collections.Generic;

namespace Genetic
{
    internal class Mutation
    {
        public List<Individual> MutationIndividual(List<Individual> population, double probabilityMutation)
        {
            var newPopulation = population;
            var rndGenMutation = new Random();
            var rndRange = new Random();

            for (var i = 0; i < population.Count; i++)
            {
                var rndPercent = rndGenMutation.NextDouble() * 100;
                if (rndPercent <= probabilityMutation)
                {
                    var range = rndRange.NextDouble();
                    if (range > 0.5)
                    {
                        newPopulation[i].x1Value += (rndPercent - 0.5) * (-1);
                    }
                    else
                    {
                        newPopulation[i].x1Value += rndPercent;
                    }
                }
                rndPercent = rndRange.NextDouble() * 100;
                if (rndPercent <= probabilityMutation)
                {
                    var range = rndRange.NextDouble();
                    if (range > 0.5)
                    {
                        newPopulation[i].x2Value += (rndPercent - 0.5) * (-1);
                    }
                    else
                    {
                        newPopulation[i].x2Value += rndPercent;
                    }
                }
            }
            return newPopulation;
        }

        public List<Individual> BinaryMutation(List<BinaryIndividual> population, DataPopulation dataPopulation)
        {
            var newPopulation = new List<Individual>();
            var rndGenMutation = new Random();
            var c = new Convert();

            for(var i = 0; i < population.Count; i++)
            {
                for(var j = 0; j < dataPopulation.amountOfBits; j++)
                {
                    var random1 = rndGenMutation.NextDouble() * 100;
                    var random2 = rndGenMutation.NextDouble() * 100;

                    if (random1 <= dataPopulation.probabilityMutation)
                    {
                        population[i].x1[j] = !(population[i].x1[j]);
                    }
                    if (random2 <= dataPopulation.probabilityMutation)
                    {
                        population[i].x2[j] = !(population[i].x2[j]);
                    }
                }
                var realIndividual = c.ConvertToReal(population[i], dataPopulation);
                newPopulation.Add(realIndividual);
            }
            return newPopulation;
        }
    }
}
