using System;
using System.Collections;
using System.Collections.Generic;

namespace Genetic
{
    internal class Crossing
    {
        public List<Individual> CrossingIndividual(List<Individual> population)
        {
            var newPopulation = new List<Individual>(population.Count);
            var randomGen = new Random();
            var randomIndividual = new Random();

            for (var i = 0; i < population.Count; i++)
            {
                int rndInd1;
                int rndInd2;
                do
                {
                    rndInd1 = randomIndividual.Next(population.Count);
                    rndInd2 = randomIndividual.Next(population.Count);
                }
                while (rndInd1 == rndInd2);

                var newIndividual = new Individual();
                var rnd = randomGen.NextDouble();
                if (rnd > 0.5)
                {
                    newIndividual.x2Value = population[rndInd2].x2Value;
                }
                else
                {
                    newIndividual.x1Value = population[rndInd1].x1Value;
                }
                newPopulation.Add(newIndividual);
            }
            return newPopulation;
        }

        public BinaryIndividual BinaryCrossing(BinaryIndividual binaryIndividual1, BinaryIndividual binaryIndividual2, DataPopulation dataPopulation)
        {
            var binaryChild = new BinaryIndividual();

            binaryChild.x1 = new BitArray(dataPopulation.amountOfBits);
            binaryChild.x2 = new BitArray(dataPopulation.amountOfBits);

            var random = new Random();
            var twoBP = new BreakPoints();
            var breakPoint1 = twoBP.Create(random, dataPopulation);
            var breakPoint2 = twoBP.Create(random, dataPopulation);
            bool binX1 = true;
            var binX2 = true;
            var support1 = 0;
            var support2 = 0;
            for (var i = 0; i < dataPopulation.amountOfBits; i++)
            {
                if (i == breakPoint1[support1])
                {
                    binX1 = !binX1;
                    if (support1 != 1)
                    {
                        support1++;
                    }
                }
                if (binX1)
                {
                    binaryChild.x1[i] = binaryIndividual1.x1[i];
                }
                else
                {
                    binaryChild.x1[i] = binaryIndividual2.x1[i];
                }
                if (i == breakPoint2[support2])
                {
                    binX2 = !binX2;
                    if (support2 != 1)
                    {
                        support2++;
                    }
                }
                if (binX2)
                {
                    binaryChild.x2[i] = binaryIndividual1.x2[i];
                }
                else
                {
                    binaryChild.x2[i] = binaryIndividual2.x2[i];
                }
            }
            return binaryChild;

        }
    }
}
