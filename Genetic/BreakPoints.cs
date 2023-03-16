using System;
using System.Collections.Generic;

namespace Genetic
{
    internal class BreakPoints
    {
        public List<int> Create (Random random, DataPopulation dataPopulation)
        {
            var breakPoints = new List<int>();
            var breakPoint1 = random.Next(0, dataPopulation.amountOfBits);
            var breakPoint2 = random.Next(0, dataPopulation.amountOfBits);

            do
            {
                breakPoint1 = random.Next(0, dataPopulation.amountOfBits);
                breakPoint2 = random.Next(0, dataPopulation.amountOfBits);
            }
            while(breakPoint1 ==  breakPoint2);
            if( breakPoint1 > breakPoint2 )
            {
                breakPoints.Add(breakPoint1);
                breakPoints.Add(breakPoint2);
            }
            else
            {
                breakPoints.Add(breakPoint2);
                breakPoints.Add(breakPoint1);
            }

            return breakPoints;
        }
    }
}
