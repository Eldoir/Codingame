using System.Collections.Generic;
using System.Linq;

namespace Codingame.SixDegreesOfKevinBacon
{
    public class Main
    {
        public static int GetResult()
        {
            // Parsing
            string name = Console.ReadLine();
            if (name == "Kevin Bacon")
                return 0;

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, HashSet<string>> nodes = [];
            for (int i = 0; i < n; i++)
            {
                string[] actors = Console.ReadLine().Split(':')[1].Split(",").Select(s => s.Trim()).ToArray();
                for (int j = 0; j < actors.Length; j++)
                {
                    for (int k = j + 1; k < actors.Length; k++)
                    {
                        if (!nodes.ContainsKey(actors[j]))
                            nodes[actors[j]] = [];

                        if (!nodes.ContainsKey(actors[k]))
                            nodes[actors[k]] = [];

                        nodes[actors[j]].Add(actors[k]);
                        nodes[actors[k]].Add(actors[j]);
                    }
                }
            }

            // Searching
            Queue<(string Actor, int Level)> queue = [];
            queue.Enqueue(("Kevin Bacon", 1));
            HashSet<string> visited = [];
            int count = 0;

            while (queue.Count > 0)
            {
                var (Actor, Level) = queue.Dequeue();
                
                if (nodes[Actor].Contains(name))
                    return Level;

                if (visited.Contains(Actor))
                    continue;

                foreach (string neighbour in nodes[Actor])
                {
                    queue.Enqueue((neighbour, Level + 1));
                }

                visited.Add(Actor);
                count++;
            }

            return -1; // Should never happen (the answer is necessarily within the graph)
        }
    }
}
