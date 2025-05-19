using Codingame.CosmicLove;

namespace Codingame.Tests.CosmicLove
{
    [TestFixture]
    internal sealed class ScientificNumberTests
    {
        [TestCase("0e0", 0d, 0)]
        [TestCase("1.09e08", 1.09d, 8)]
        [TestCase("3.18e06", 3.18d, 6)]
        [TestCase("9.00e06", 9d, 6)]
        [TestCase("7.89e28", 7.89d, 28)]
        public void Parses_N_and_P_correctly(string s, double n, int p)
        {
            ScientificNumber sut = new(s);
            Assert.Multiple(() =>
            {
                Assert.That(sut.N.AlmostEqualTo(n, 1e-7), Is.True);
                Assert.That(sut.P, Is.EqualTo(p));
            });
        }

        [TestCase(0d, 0, 1d, 0, 0d, 0)] // 0 / 1 = 0
        [TestCase(1d, 0, 1d, 0, 1d, 0)] // 1 / 1 = 1
        [TestCase(5d, 0, 1d, 0, 5d, 0)] // 5 / 1 = 5
        [TestCase(5d, 0, 5d, 0, 1d, 0)] // 5 / 5 = 1
        [TestCase(1d, 0, 3d, 0, 3.3333333333d, -1)] // 1 / 3 = -0.3333333333
        [TestCase(1d, 1, 5d, 0, 2d, 0)] // 10 / 5 = 2
        [TestCase(8d, 0, 4d, 0, 2d, 0)] // 8 / 4 = 2
        [TestCase(1.2d, 2, 1d, 1, 1.2d, 1)] // 120 / 10 = 12
        [TestCase(1d, 1, 1d, 2, 1d, -1)] // 10 / 100 = 0.1
        [TestCase(1d, 0, 1d, 3, 1d, -3)] // 1 / 1000 = 0.001
        [TestCase(4.9d, 2, 2.5d, 0, 1.96d, 2)] // 490 / 2.5 = 196
        [TestCase(4.9d, 1, 2.14d, 2, 2.2897196261d, -1)] // 49 / 2.14 = 0.22897196261
        public void Divides_correctly(double n1, int p1, double n2, int p2, double expectedN, int expectedP)
        {
            ScientificNumber result = new ScientificNumber(n1, p1) / new ScientificNumber(n2, p2);
            Assert.Multiple(() =>
            {
                Assert.That(result.N.AlmostEqualTo(expectedN), Is.True);
                Assert.That(result.P, Is.EqualTo(expectedP));
            });
        }

        [TestCase(0d, 0, 0d, 0, 0d, 0)] // 0 * 0 = 0
        [TestCase(0d, 0, 1d, 2, 0d, 0)] // 0 * 100 = 0
        [TestCase(1d, 2, 0d, 0, 0d, 0)] // 100 * 0 = 0
        [TestCase(2d, 1, 1d, 0, 2d, 1)] // 2 * 1 = 2
        [TestCase(1d, 0, 3.18d, 2, 3.18d, 2)] // 1 * 318 = 318
        [TestCase(4.9d, 2, 2.4d, 0, 1.176d, 3)] // 490 * 2.4 = 1176
        public void Multiplies_correctly(double n1, int p1, double n2, int p2, double expectedN, int expectedP)
        {
            ScientificNumber result = new ScientificNumber(n1, p1) * new ScientificNumber(n2, p2);
            Assert.Multiple(() =>
            {
                Assert.That(result.N.AlmostEqualTo(expectedN), Is.True);
                Assert.That(result.P, Is.EqualTo(expectedP));
            });
        }

        [TestCase(1d, 0, 1d, 0, false)] // 0  > 1 is false
        [TestCase(1d, 0, 1d, 0, false)] // 1 > 1 is false
        [TestCase(1d, 0, 0d, 0, true)] // 1 > 0 is true
        [TestCase(2.123456d, 0, 2.123455d, 0, true)] // 2.123456 > 2.123455 is true
        [TestCase(2.123456d, 0, 2.123455d, 1, false)] // 2.123456 > 21.23455 is false
        [TestCase(1d, -1, 1d, 0, false)] // 0.1 > 1 is false
        [TestCase(2d, -2, 1d, -1, false)] // 0.02 > 0.1 is false
        public void Greather_than_is_correct(double n1, int p1, double n2, int p2, bool expected)
        {
            Assert.That(new ScientificNumber(n1, p1) > new ScientificNumber(n2, p2), Is.EqualTo(expected));
        }

        [TestCase(0d, 0, 0d)]
        [TestCase(1d, 0, 1d)]
        [TestCase(1d, 1, 10d)]
        [TestCase(1.123456d, 7, 11234560d)]
        [TestCase(7.88d, -3, 0.00788d)]
        public void Double_conversion_is_correct(double n, int p, double expected)
        {
            Assert.That(((double)new ScientificNumber(n, p)).AlmostEqualTo(expected), Is.True);
        }
    }

    public static class DoubleExtensions
    {
        public static bool AlmostEqualTo(this double a, double b, double epsilon = 1e-10)
        {
            double diff = Math.Abs(a - b);
            double largest = Math.Max(Math.Abs(a), Math.Abs(b));

            return diff <= epsilon * largest || diff <= epsilon;
        }
    }
}
