using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
    internal class KnuthMorrisPrattAlgorithm
    {
        public static List<int> FindAllOccurances(string text, string pattern)
        {
            List<int> result = new();


            return result;
        }

        private static int[] PrefixFunction(string text)
        {
            int[] result = new int[text.Length];
            for(int i = 1; i < result.Length; i++)
            {
                int currentPrefixWeight = result[i - 1];
                while(currentPrefixWeight > 0 && text[i] != text[currentPrefixWeight])
                {
                    currentPrefixWeight = result[currentPrefixWeight - 1];
                }
                if (text[i] == text[currentPrefixWeight])
                    currentPrefixWeight++;
                result[i] = currentPrefixWeight;
            }

            return result;
        }
    }
}
