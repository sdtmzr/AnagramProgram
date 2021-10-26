using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace AnagramLibrary
{
    public interface IAnagram
    {
        public string CreateAnagram(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }
            if (text.Length <= 1)
            {
                return text;
            }
            char[] textArray = text.ToArray();
            int idx = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    if (i - idx != 0)
                    {
                        CreateWordAnagram(ref textArray, idx, --i);
                    }
                    idx = i + 1;
                }
            }
            if (textArray.Length - idx != 0)
            {
                CreateWordAnagram(ref textArray, idx, (textArray.Length - 1));
            }
            string result = new string(textArray);
            return result;
        }

        internal void CreateWordAnagram(ref char[] textArray, int wordStart, int wordEnd)
        {
            int numberOfLetters = 0;
            for (int i = wordStart; i <= wordEnd; i++)
            {
                if (char.IsLetter(textArray[i]))
                {
                    numberOfLetters++;
                }
            }
            if (numberOfLetters < 2)
            {
                return;
            }
            int counter = 0;
            int idx = wordEnd;
            for (int i = wordStart; counter < numberOfLetters / 2; i++)
            {
                if (char.IsLetter(textArray[i]))
                {
                    for (int j = idx; idx >= wordStart; j--)
                    {
                        if (char.IsLetter(textArray[j]))
                        {
                            char tmp;
                            tmp = textArray[j];
                            textArray[j] = textArray[i];
                            textArray[i] = tmp;
                            --idx;
                            break;
                        }
                        --idx;
                    }
                    counter++;
                }
            }
        }
    }
}
