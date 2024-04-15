namespace Task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "AABAACAADAABAAABAA";
            string pattern = "AABA";
            var result = FiniteAutomataSearch.FindAllOccurances(text, pattern);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
