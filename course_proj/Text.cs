using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursaCH
{
    class Text
    {
        List<string> readingWords; // массив слов, получаемый из readingBox

        int maxLenght, curIndex, countOfCurWords;
        public int CountOfWords { get { return countOfCurWords; } }

        public Text(List<string> rWords, int lenght)
        {
            curIndex = 0;
            countOfCurWords = 0;
            maxLenght = lenght;
            readingWords = new List<string>(rWords);
        }


        public string SetText()
        {
            string newText = "";
            countOfCurWords = 0;
            while (curIndex < readingWords.Count && newText.Length + readingWords[curIndex].Length + 1 < maxLenght)
            {
                newText += readingWords[curIndex] + " ";
                curIndex++;
                countOfCurWords++;
            }
            return newText;
        }
        
        public int GetStartPositionOfWords(int index)
        {
            int startPos = 0;
            for(int i = 0; i < index; i++)
            {
                startPos += readingWords[i].Length + 1;
            }
            return startPos;
        }
        public int GetLenghtOfWord(int index) => readingWords[index].Length;
        public bool Compare(string curWord, int curIndex) => readingWords[curIndex] == curWord;
        public bool IsEmpty() => curIndex >= readingWords.Count - 1;

        public string InsertZero(int num)
        {
            return (num < 10) ? "0" + num.ToString() : num.ToString();
        }
    }
}
