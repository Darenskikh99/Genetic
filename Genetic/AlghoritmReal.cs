using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Genetic
{
    internal class AlghoritmReal
    {
        public Individual CalculateReal(Individual minimum, DataPopulation dataPopulation, List<Individual> population)
        {
            for (int i = 0; i < dataPopulation.sizeOfPopulation; i++)
            {
                var select = new Selection();
                var selectPopulation = select.SelectIndividuals(population);
                var cros = new Crossing();
                var crossingPopulation = cros.CrossingIndividual(selectPopulation);
                var mutate = new Mutation();
                var mutatedPopulation = mutate.MutationIndividual(crossingPopulation, dataPopulation.probabilityMutation);
                var calculate = new CalculateIndividual();
                var calculatePopulation = calculate.CalculateValues(mutatedPopulation, dataPopulation.function);
                var minimumOfFunction =  new MinimumOfFunction();
                minimum = minimumOfFunction.FindMinimumIndividual(calculatePopulation);
                population = calculatePopulation;
            }
            return minimum;
        }

        public Individual CalculateBinary(Individual minimum, DataPopulation dataPopulation, List<Individual> population)
        {
            for(var i = 0; i < dataPopulation.sizeOfPopulation; i++)
            {
                var select = new Selection();
                var selectPopulation = select.SelectIndividuals(population);
                var binaryPopulation = new BinaryPopulation();
                var newBinaryPopulation = binaryPopulation.Create(selectPopulation, dataPopulation);
                var mutate = new Mutation();
                var mutatePopulation = mutate.BinaryMutation(newBinaryPopulation, dataPopulation);
                var calculate = new CalculateIndividual();
                var calculatePopulation = calculate.CalculateValues(mutatePopulation, dataPopulation.function);
                var minimumOfFunction = new MinimumOfFunction();
                minimum = minimumOfFunction.FindMinimumIndividual(calculatePopulation);
                population = calculatePopulation;
            }
            return minimum;
        }
    }
}
