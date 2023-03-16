using System.Collections.Generic;

namespace Genetic
{
    internal class MinimumOfFunction
    {
        public Individual FindMinimumIndividual(List<Individual> population)
        {
            Individual minimum = population[0];
            for (var i = 0; i < population.Count; i++)
            {
                if(minimum.funcValue > population[i].funcValue)
                {
                    minimum = population[i];
                }
            }
            /*foreach (Individual i in population)
            {
                if(minimum.funcValue > i.funcValue)
                {
                    minimum = i;
                }
            }*/
            return minimum;
        }
    }
}
