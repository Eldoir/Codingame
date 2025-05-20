using System.Collections.Generic;

namespace Codingame.WordleColorizer
{
    public static class Main
    {
        public static string GetResult()
        {
            return string.Join("\n", GetResults());
        }

        public static string[] GetResults()
        {
            string answer = Console.ReadLine();
            int N = int.Parse(Console.ReadLine());

            string[] results = new string[N];

            for (int i = 0; i < N; i++)
            {
                string attempt = Console.ReadLine();
                results[i] = GetResult(answer, attempt);
            }

            return results;
        }

        public static string GetResult(string answer, string attempt)
        {
            Dictionary<char, int> counts = [];
            char[] result = new char[attempt.Length];

            // First pass: mark exact matches (#) and count unmatched answer letters
            for (int i = 0; i < answer.Length; i++)
            {
                char c = answer[i];
                if (c == attempt[i])
                {
                    result[i] = '#';
                }
                else
                {
                    if (counts.ContainsKey(c))
                        counts[c]++;
                    else
                        counts[c] = 1;
                }
            }

            for (int i = 0; i < attempt.Length; i++)
            {
                if (result[i] != 0)
                    continue;

                char c = attempt[i];
                if (counts.ContainsKey(c) && counts[c] > 0)
                {
                    result[i] = 'O';
                    counts[c]--;
                }
                else
                {
                    result[i] = 'X';
                }
            }

            return string.Join("", result);
        }
    }
}
