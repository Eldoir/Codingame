namespace Codingame.Tests.SixDegreesOfKevinBacon
{
    public class TestCases
    {
        [TestCase("2 Degrees of Kevin Bacon", 2)]
        [TestCase("One Degree of Kevin Bacon", 1)]
        [TestCase("3 Degrees of Kevin Bacon", 3)]
        [TestCase("Kevin Bacon Himself", 0)]
        [TestCase("Going big", 6)]
        [TestCase("The Biggest", 4)]
        public void TestFiles(string filename, int expected)
        {
            Console.Init(File.ReadAllLines($"SixDegreesOfKevinBacon/TestFiles/{filename}.txt"));
            Assert.That(Codingame.SixDegreesOfKevinBacon.Main.GetResult(), Is.EqualTo(expected));
        }
    }
}