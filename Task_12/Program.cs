using Task_12;

namespace Task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = File.ReadAllText((@"..\..\..\input.txt"));
            string pattern = "AABA";
            var result = KnuthMorrisPrattAlgorithm.FindAllOccurances(text, pattern);
			Console.WriteLine(String.Join(" ", result));
        }
    }
}
