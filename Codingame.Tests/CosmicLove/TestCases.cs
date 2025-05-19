namespace Codingame.Tests.CosmicLove
{
    public class TestCases
    {
        [TestCase("One haven", "G7_24a")]
        [TestCase("Happy Alice", "Millers_Planet")]
        [TestCase("Hungry Alice", "CodinPlanet")]
        [TestCase("So Many Options", "Gh2")]
        [TestCase("The Event Horizon", "Supergiant_H59")]
        public void TestFiles(string filename, string expected)
        {
            Console.Init(File.ReadAllLines($"CosmicLove/TestFiles/{filename}.txt"));
            Assert.That(Codingame.CosmicLove.Main.GetResult(), Is.EqualTo(expected));
        }
    }
}