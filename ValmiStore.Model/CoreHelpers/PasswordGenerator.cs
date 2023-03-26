using System;
using System.Security.Cryptography;
using System.Text;

namespace Webmall.Model.CoreHelpers
{
    public class PasswordGenerator
    {
        public PasswordGenerator()
        {
            Minimum = DefaultMinimum;
            Maximum = DefaultMaximum;
            ConsecutiveCharacters = false;
            RepeatCharacters = true;
            ExcludeSymbols = false;
            Exclusions = null;

            _rng = new RNGCryptoServiceProvider();
        }

        protected int GetCryptographicRandomNumber(int lBound, int uBound)
        {
            // Assumes lBound >= 0 && lBound < uBound

            // returns an int >= lBound and < uBound

            uint urndnum;
            byte[] rndnum = new byte[4];
            if (lBound == uBound - 1)
            {
                // test for degenerate case where only lBound can be returned

                return lBound;
            }

            uint xcludeRndBase = (uint.MaxValue -
                (uint.MaxValue % (uint)(uBound - lBound)));

            do
            {
                _rng.GetBytes(rndnum);
                urndnum = BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);

            return (int)(urndnum % (uBound - lBound)) + lBound;
        }

        protected char GetRandomCharacter()
        {
            int upperBound = _pwdCharArray.GetUpperBound(0);

            if (ExcludeSymbols)
            {
                upperBound = UBoundDigit;
            }

            int randomCharPosition = GetCryptographicRandomNumber(
                _pwdCharArray.GetLowerBound(0), upperBound);

            char randomChar = _pwdCharArray[randomCharPosition];

            return randomChar;
        }

        public string Generate()
        {
            // Pick random length between minimum and maximum   

            int pwdLength = GetCryptographicRandomNumber(Minimum,
                Maximum);

            var pwdBuffer = new StringBuilder {Capacity = Maximum};

            // Generate random characters

            // Initial dummy character flag

            var lastCharacter = '\n';

            for (int i = 0; i < pwdLength; i++)
            {
                var nextCharacter = GetRandomCharacter();

                if (false == ConsecutiveCharacters)
                {
                    // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                    while (lastCharacter == nextCharacter)
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                if (false == RepeatCharacters)
                {
                    string temp = pwdBuffer.ToString();
                    int duplicateIndex = temp.IndexOf(nextCharacter);
                    while (-1 != duplicateIndex)
                    {
                        nextCharacter = GetRandomCharacter();
                        duplicateIndex = temp.IndexOf(nextCharacter);
                    }
                }

                if ((null != Exclusions))
                {
                    while (-1 != Exclusions.IndexOf(nextCharacter))
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }

            return pwdBuffer.ToString();
        }

        public string Exclusions { get; set; }

        public int Minimum
        {
            get => _minSize;
            set
            {
                _minSize = value;
                if (DefaultMinimum > _minSize)
                {
                    _minSize = DefaultMinimum;
                }
            }
        }

        public int Maximum
        {
            get => _maxSize;
            set
            {
                _maxSize = value;
                if (_minSize >= _maxSize)
                {
                    _maxSize = DefaultMaximum;
                }
            }
        }

        public bool ExcludeSymbols { get; set; }

        public bool RepeatCharacters { get; set; }

        public bool ConsecutiveCharacters { get; set; }

        private const int DefaultMinimum = 6;
        private const int DefaultMaximum = 10;
        private const int UBoundDigit = 61;

        private readonly RNGCryptoServiceProvider _rng;
        private int _minSize;
        private int _maxSize;
        private readonly char[] _pwdCharArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?".ToCharArray();
    }
}