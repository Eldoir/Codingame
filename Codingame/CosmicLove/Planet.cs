using System;

namespace Codingame.CosmicLove
{
    public class Planet
    {
        public Planet(string name)
            : this(name, ScientificNumber.One, ScientificNumber.One, ScientificNumber.One) { }

        public Planet(string name, string r, string m, string c)
            : this(name, new ScientificNumber(r), new ScientificNumber(m), new ScientificNumber(c)) { }

        public Planet(string name, ScientificNumber r, ScientificNumber m, ScientificNumber c)
        {
            Name = name;
            R = r;
            Volume = (4 * Math.PI / 3) * R * R * R;
            M = m;
            Density = M / Volume;
            C = c;
        }

        public string Name { get; }

        public ScientificNumber R { get; }
        public ScientificNumber M { get; }
        public ScientificNumber C { get; }

        public ScientificNumber Volume { get; }
        public ScientificNumber Density { get; }

        public ScientificNumber RocheLimit(Planet other)
        {
            return R * Math.Cbrt(2d * (Density / other.Density));
        }

        public bool WillDisintegrate(Planet other)
        {
            return RocheLimit(other) > other.C;
        }
    }
}
