using System.Linq;


namespace UrlMiniAcceptanceTests.CodecApiTests.TestFramework.Models
{
    public static class UrlMinimizer
    {
        
        //user can specify any alphabet they wish for the URL Minimizer, and lenght with adjust accordingly
        private static readonly string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyz";
        private static readonly int Base = Alphabet.Length;

        //I didn't want the URL generator to start at 1, so I created an offset to force a large number
        //Note, the cureent value limits the number of entries to (int32 limit - Offset): 2,147,392,738
        private static readonly int Offset = 90909;

        public static string Encode(int i)
        {
            if (i <= 0)
            {
                return "Invalid";
            }
            else
            {
                i = i + Offset;
            }

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[(int)i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int Decode(string codeString)
        {
            int i = 0;

            foreach (var curCharacter in codeString)
            {
                i = (i * Base) + Alphabet.IndexOf(curCharacter);
            }

            return i - Offset;
        }

    }
}
