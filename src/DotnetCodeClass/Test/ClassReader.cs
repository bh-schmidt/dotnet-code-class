using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotnetCodeClass.Test
{
    public class ClassReader
    {
        private readonly string file;
        private static readonly string[] stringSymbols = new[] { "\"", "@\"", "$\"", "@$\"", "$@\"" };
        private static readonly HashSet<char> languageSymbols = new HashSet<char> { '{', '}', '[', ']', '"', '\'', };
        private static readonly HashSet<string> blockSymbols = new HashSet<string> { "{", "}", "[", "]", "'", "\"", };
        private static readonly HashSet<string> comparisonSymbols = new HashSet<string> { "==", "<=", ">=", "!=", "|", "||" };
        private static readonly HashSet<string> mathSymbols = new HashSet<string> { "=", "*", "*=", "+", "+=", "-", "-=", "/", "/=", "%", "%=", "??=" };

        public ClassReader(string file)
        {
            this.file = file;
        }

        public int CurrentIndex { get; set; } = -1;
        public bool CanRead => CurrentIndex + 1 < file.Length;
        public bool CanIncrease => CurrentIndex + 1 < file.Length;
        public bool CanDecrease => CurrentIndex > 0;

        private bool IncreaseIndex()
        {
            if (!CanIncrease)
                return false;

            CurrentIndex++;
            return true;
        }

        private bool IncreaseDecrease()
        {
            if (!CanDecrease)
                return false;

            CurrentIndex--;
            return true;
        }

        public string ReadNext()
        {
            while (IncreaseIndex())
            {
                var character = ReadCurrent();

                if (char.IsWhiteSpace(character) || character == '\r' || character == '\n')
                    continue;

                if (char.IsLetter(character) || character == '_')
                    return ReadWord();

                return character.ToString();
            }

            return null;
        }

        public char ReadCurrent()
        {
            return file[CurrentIndex];
        }

        public string ReadWord()
        {
            var firstIndex = CurrentIndex;
            var value = ReadCurrent();
            if (!char.IsLetter(value) && value != '_')
                return null;

            while (IncreaseIndex())
            {
                value = ReadCurrent();
                if (!char.IsLetterOrDigit(value) && value != '_')
                    break;
            }

            return file[firstIndex..CurrentIndex];
        }

        public string ReadUntilSemiColumn()
        {
            var firstIndex = CurrentIndex;
            while (IncreaseIndex())
            {
                var value = ReadCurrent();
                if (value == ';')
                    break;

            }

            if (firstIndex == CurrentIndex)
                return null;

            var lastPosition = CurrentIndex + 1;
            return file[firstIndex..lastPosition];
        }

        public string ReadVerbatimString()
        {
            var firstIndex = CurrentIndex;
            var foundQuote = false;

            while (CurrentIndex < file.Length)
            {
                var value = file[CurrentIndex];
                CurrentIndex++;
                if (value == '"' && !foundQuote)
                {
                    foundQuote = true;
                    continue;
                }

                if (value == '"' && foundQuote)
                {
                    foundQuote = false;
                    continue;
                }

                if (foundQuote)
                {
                    CurrentIndex--;
                    break;
                }
            }

            if (firstIndex == CurrentIndex)
                return null;

            return file[firstIndex..CurrentIndex];
        }

        public string ReadInterpolatedString()
        {
            return null;
        }

        public string ReadSimpleString()
        {
            var firstIndex = CurrentIndex;
            while (CanRead)
            {
                var value = file[CurrentIndex];
                if (value == '"' && file[CurrentIndex - 1] != '\\')
                    break;
                CurrentIndex++;
            }

            if (firstIndex == CurrentIndex)
                return null;

            return file[firstIndex..CurrentIndex];
        }

        public bool IsString()
        {
            var value = file[CurrentIndex..];
            return stringSymbols.Any(item => value.StartsWith(item));
        }
    }
}
