using System;
using System.Text.RegularExpressions;

namespace Webmall.UI.Core.Helpers
{
    public class PinGenerator
    {
        private static readonly Random RandGen = new Random();
        public static string Generate(int iLength = 6)
        {
            //Valid characters for the PIN.
            char[] cValidChars = "ABCDFGHJKLMNPQRSTVWXYZ0123456789".ToCharArray();
            string sGeneratedPin = "";
            Regex letterMatch = new Regex(@"^[a-zA-Z]+$");
            Regex numberMatch = new Regex(@"^[0-9]+$");

            for (int i = 0; i < iLength; i++)
            {
                sGeneratedPin += cValidChars[RandGen.Next(0, cValidChars.Length - 1)];
                if (letterMatch.IsMatch(sGeneratedPin) || numberMatch.IsMatch(sGeneratedPin))
                {
                    if (i == iLength - 1)
                    {
                        //Invalid PIN, reset
                        //Console.WriteLine(sGeneratedPIN);
                        sGeneratedPin = "";
                        i = 0;
                        //Console.WriteLine("Bad PIN");
                    }
                }
            }

            return sGeneratedPin;
        }

    }
}