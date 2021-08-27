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
            string alphabetString = "abcdefghijklmnopqrstuvwxyz ";
            char[] alphabet = alphabetString.ToCharArray();
            string direction = "forwards";
            char seperatedLetter;
            char seperatedLetterShifted;
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
            char[] separatedText = new char[originalLength];

            for (int i = 0; i < originalLength; i++)
            {
                // seperating letter and finding position in the alphabet
                seperatedLetter = originalText[i];

                if (seperatedLetter != ' ')
                {
                    capital[i] = (Char.ToUpper(seperatedLetter) == seperatedLetter);
                    seperatedLetter = Char.ToLower(seperatedLetter);
                }
                separatedText[i] = seperatedLetter;
            }

            foreach (char letter in separatedText)
            {
                int intLetter = Array.IndexOf(alphabet, letter);

                seperatedLetterShifted = ' ';

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
                    seperatedLetterShifted = Char.ToUpper(seperatedLetterShifted);
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
