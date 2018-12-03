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

            for (int column = 1; column < triangleSize; column++) //for-loopen skriver ut så många rader som triangeln ska bli lång
            {
                if (pointingUp)
                    Console.WriteLine(new string('*', column+2));
                else
                    Console.WriteLine(new string('*', triangleSize-column));

                //if (pointingUp) //Om triangeln ska peka uppåt
                //{
                //    for (int row = 0; row <= column; row++) // skrivs lika många stjärnor ut som raden i triangeln vi är på
                //    {
                //        Console.Write("*");
                //    }
                //}
                //else // Om triangeln inte ska peka uppåt, dvs nedåt 
                //{
                //    for (int row = 0; row < (triangleSize - column); row++) // skrivs lika många stjärnor ut som raden i triangeln i vi är på minus den bredden det ska bli som bredast. 
                //    {
                //        Console.Write("*");
                //    }
                //}
                //Console.WriteLine(); // ny rad varje gång vi skrivit ut en rad med stjärnor 
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

        private static bool ValidateTriangels(string[] triangels) //Validering
        {
            foreach (var triangle in triangels)
            {
                if (!Regex.IsMatch(triangle, "^[abAB]\\d+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;     //Errormessage in red
                    Console.WriteLine("Felaktigt format: " + triangle);     //TODO: errormessage i rött och 'triangle' i "vanlig" färg istället? Spexigt!
                    Console.ResetColor();
                    return false;
                }
            }
            return true;
        }
    }
}
