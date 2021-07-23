using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Shifter
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaring variables
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
            string direction = "forwards";
            string seperatedLetter;
            string seperatedLetterShifted = "";
            int intLetterShifted;
            int posLetter = 0;
            string finalText = "";

            // grabbing variables
            Console.WriteLine("Enter your text here (only letters please)");
            string originalText = Console.ReadLine();
            do
            {
                Console.WriteLine("Would you like to go forwards or backwards? (type forwards or backwards)");
                direction = Console.ReadLine();
            } while (direction != "forwards" && direction != "backwards");

            Console.WriteLine($"How many digits {direction} would you like to go");
            int shiftQuantity = Int32.Parse(Console.ReadLine());

            int originalLength = originalText.Length;

            bool[] capital = new bool[originalLength];
            string[] separatedText = new string[originalLength];

            for (int i = 0; i < originalLength; i++)
            {
                // seperating letter and finding position in the alphabet
                seperatedLetter = originalText.Substring(i, 1);

                if (seperatedLetter != " ")
                {
                    capital[i] = (seperatedLetter.ToUpper() == seperatedLetter);
                    seperatedLetter = seperatedLetter.ToLower();
                }
                separatedText[i] = seperatedLetter;
            }

            foreach (string letter in separatedText)
            {
                int intLetter = Array.IndexOf(alphabet, letter);

                seperatedLetterShifted = " ";

                // shifting number
                if (intLetter != 26)
                {
                    if (direction == "forwards")
                    {
                        intLetterShifted = intLetter + shiftQuantity;
                        if (intLetterShifted > 25)
                        {
                            intLetterShifted = intLetterShifted % 26;
                        }
                    }

                    else
                    {
                        intLetterShifted = intLetter - shiftQuantity;
                        while (intLetterShifted < 0)
                        {
                            intLetterShifted = intLetterShifted + 26;
                        }
                    }

                    seperatedLetterShifted = alphabet[intLetterShifted];
                }
                if (capital[posLetter] == true)
                {
                    seperatedLetterShifted = seperatedLetterShifted.ToUpper();
                }

                posLetter++;

                // compiles list into one string
                finalText = finalText + seperatedLetterShifted;
            }

            Console.WriteLine(finalText);

            Console.ReadKey();
        }
    }
}
