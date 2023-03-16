using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic
{
    internal class Convert
    {
        public BinaryIndividual ConvertToBinary(Individual individual, DataPopulation dataPopulation)
        {
            BinaryIndividual binaryIndividual = new();
            int decimalX1Value = (int)((individual.x1Value - dataPopulation.x1Left) * (Math.Pow(2, dataPopulation.amountOfBits) - 1));
            int decimalX2Value = (int)((individual.x2Value - dataPopulation.x2Left) * (Math.Pow(2, dataPopulation.amountOfBits) - 1));
            
            binaryIndividual.x1 = new BitArray(BitConverter.GetBytes(decimalX1Value));
            binaryIndividual.x2 = new BitArray(BitConverter.GetBytes(decimalX2Value));

            return binaryIndividual;
        }

        public Individual ConvertToReal(BinaryIndividual binaryIndividual, DataPopulation dataPopulation)
        {
            var realIndividual = new Individual();
            int[] valueArray1 = new int[1];
            int[] valueArray2 = new int[1];

            binaryIndividual.x1.CopyTo(valueArray1, 0);
            binaryIndividual.x2.CopyTo(valueArray2, 0);

            realIndividual.x1Value = valueArray1[0] * (dataPopulation.x1Right - dataPopulation.x1Left) / (Math.Pow(2, dataPopulation.amountOfBits) - 1) + dataPopulation.x1Left;
            realIndividual.x2Value = valueArray2[0] * (dataPopulation.x2Right - dataPopulation.x2Left) / (Math.Pow(2, dataPopulation.amountOfBits) - 1) + dataPopulation.x2Left;

            return realIndividual;
        }
    }
}
