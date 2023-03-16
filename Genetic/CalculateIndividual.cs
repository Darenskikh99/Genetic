using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;
using Expression = org.mariuszgromada.math.mxparser.Expression;


namespace Genetic
{
    internal class CalculateIndividual
    {
        public Expression function;
        public Argument x1 = new Argument("x1");
        public Argument x2 = new Argument("x2");

        public List<Individual> CalculateValues (List<Individual> population, string func)
        {
            function = new Expression(func, x1, x2);
            var newPopulation = population;
            for (var i = 0; i < newPopulation.Count; i++)
            {
                x1.setArgumentValue(population[i].x1Value);
                x2.setArgumentValue(population[i].x2Value);
                newPopulation[i].funcValue = function.calculate();
            }
            /*foreach (var item in newPopulation)
            {
                x1.setArgumentValue(item.x1Value);
                x2.setArgumentValue(item.x2Value);
                item.funcValue = function.calculate();
            }*/
            return newPopulation;
        }
    }
}
