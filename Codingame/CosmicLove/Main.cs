using System.Linq;

namespace Codingame.CosmicLove
{
    public class Main
    {
        public static string GetResult()
        {
            int N = int.Parse(Console.ReadLine());
            var _planets = new Planet[N];
            var _alice = new Planet("Alice");
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string name = inputs[0];
                string r = inputs[1];
                string m = inputs[2];
                string c = inputs[3];
                if (c == "0") c = "0e0";

                var planet = new Planet(name, r, m, c);
                _planets[i] = planet;

                if (name == _alice.Name)
                    _alice = planet;
            }

            return _planets
                .Where(p => p != _alice && !_alice.WillDisintegrate(p))
                .OrderBy(p => p.C)
                .First()
                .Name;
        }
    }
}
