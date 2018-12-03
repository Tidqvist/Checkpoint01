using System;
using System.Text.RegularExpressions;

namespace Checkpoint01
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //Programloop
            {
                string[] triangels;

                do // I loopen inhämtas användarens input, inputen delas upp i en array och valideras. 
                {
                    string input = GetUserInput("Write command: ");
                    triangels = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                } while (ValidateTriangels(triangels) == false); // Om valideringen genererar false upprepas loopen och användaren får ange input på nytt.

                foreach (string triangle in triangels) //för varje triangel i listan anropas funktionen som skriver ut en triagel enligt specifikationen
                {
                    PrintTriangle(triangle);
                }
            }
        }

        private static void PrintTriangle(string triangle)
        {
            bool pointingUp = char.Equals(triangle.ToLower()[0], 'a') ? true : false; //Skapar ett bool utefter första bokstaven i strängen som representerar om triangeln har ett skarpt hörn uppåt.
            int triangleSize = int.Parse(triangle.Substring(1)); // resten av strängen omvandlas till ett heltal

            for (int column = 0; column < triangleSize; column++) //for-loopen skriver ut så många rader som triangeln ska bli lång
            {
                if (pointingUp) //Om triangeln ska peka uppåt
                {
                    for (int row = 0; row <= column; row++) // skrivs lika många stjärnor ut som raden i triangeln vi är på
                    {
                        Console.Write("*");
                    }
                }
                else // Om triangeln inte ska peka uppåt, dvs nedåt 
                {
                    for (int row = 0; row < (triangleSize - column); row++) // skrivs lika många stjärnor ut som raden i triangeln i vi är på minus den bredden det ska bli som bredast. 
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine(); // ny rad varje gång vi skrivit ut en rad med stjärnor 
            }
        }


        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return GetUserInput(message);

            return input;
        }

        private static bool ValidateTriangels(string[] triangels)
        {
            foreach (var triangle in triangels)
            {
                if (!Regex.IsMatch(triangle, "^[abAB]\\d+$")) { 
                    Console.WriteLine("Felaktigt format: " + triangle);
                    return false;
                }
            }
            return true;
        }
    }
}
