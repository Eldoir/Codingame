using System.Linq;

namespace Codingame
{
    /// <summary>
    /// Fake console to get the same code for easy copy/paste between Codingame (the website) and here (the solution).
    /// </summary>
    public static class Console
    {
        public static void Init(string input)
            => Init(input.Split("\n").Select(l => l.Trim()).ToArray());

        public static void Init(string[] lines)
        {
            _lines = lines;
            _lineIdx = 0;
        }

        public static string ReadLine()
        {
            _lineIdx++;
            return _lines[_lineIdx - 1];
        }

        private static string[] _lines = [];
        private static int _lineIdx = 0;
    }
}
