namespace Codingame.Tests.WordleColorizer
{
    public class TestCases
    {
        [TestCase("Polka", new string[] { "XXXXO", "XXOXX", "XOOXX", "#####" })]
        [TestCase("Water", new string[] { "XXXXX", "OOXXO", "OOOXX", "###XX", "#####" })]
        [TestCase("Koala", new string[] { "OOXOX", "OX#XX", "XX###", "OOXXX", "XX#X#", "#####" })]
        [TestCase("Nanny", new string[] { "XOXXO", "#XXXO", "#OXXO", "#X##X", "#O##O", "#####" })]
        public void TestFiles(string filename, string[] expected)
        {
            Console.Init(File.ReadAllLines($"WordleColorizer/TestFiles/{filename}.txt"));
            string[] actual = Codingame.WordleColorizer.Main.GetResult();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i]));
            }
        }

        [TestCase("ABCDE", "ABCDE", "#####")] // Full win
        [TestCase("ABCDE", "FFFFF", "XXXXX")] // Full fail
        [TestCase("ABCDE", "FFCFF", "XX#XX")] // One letter win
        [TestCase("ABCDE", "AFCFE", "#X#X#")] // Multiple letter win
        [TestCase("ABCDE", "FFAFF", "XXOXX")] // One letter misplaced
        [TestCase("ABCDE", "FAFCF", "XOXOX")] // Multiple letter misplaced
        // Bongo (from the forum)
        [TestCase("BONGO", "OOOOO", "X#XX#")]
        [TestCase("BONGO", "ONGBA", "OOOOX")]
        [TestCase("BONGO", "NNOGO", "OXO##")]
        public void SingleCases(string answer, string attempt, string expected)
        {
            Assert.That(Codingame.WordleColorizer.Main.GetResult(answer, attempt), Is.EqualTo(expected));
        }
    }
}