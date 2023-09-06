using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Birthday Guesser!");
        Console.WriteLine("Please think of your birthday season and tell me.");

        Console.Write("Enter the season (Spring/Summer/Fall/Winter): ");
        string season = Console.ReadLine();

        season = season.ToUpper(); // Convert to uppercase for consistency

        int targetMonth;

        switch (season)
        {
            case "SPRING":
                targetMonth = 3;
                break;
            case "SUMMER":
                targetMonth = 6;
                break;
            case "FALL":
                targetMonth = 9;
                break;
            case "WINTER":
                targetMonth = 12;
                break;
            default:
                Console.WriteLine("Invalid season input. Please choose from Spring, Summer, Fall, or Winter.");
                return;
        }

        Console.WriteLine($"Your birthday is in the {season} season, which starts with the month of {GetMonthName(targetMonth)}.");

        string monthResponse = "no"; // Initialize to "no" to enter the while loop
        int counterMonthGuess = 0;

        while (monthResponse == "no") // Corrected the condition
        {
            if (counterMonthGuess > 2)
            {
                Console.WriteLine("Sorry, we couldn't guess your birthday. Try again later.");
                return; // Exit the program
            }

            Console.WriteLine($"Is your birthday in {GetMonthName(targetMonth)}? (yes/no)");
            monthResponse = Console.ReadLine().ToLower();

            if (targetMonth == 12)
            {
                targetMonth = 1;
            }
            else
            {
                targetMonth++; // Increment the month
            }

            counterMonthGuess++;
        }

        int lowerBound = 1;
        int upperBound = DateTime.DaysInMonth(DateTime.Now.Year, targetMonth);
        int dayCounter = 0;
        int dayGuess = 0;

        for (int i = 0; i < 3; i++)
        {
            dayGuess = (lowerBound + upperBound) / 2;
            dayCounter++;

            Console.WriteLine($"Is your birthday in the {GetMonthName(targetMonth)} {dayGuess}?");
            Console.Write("Enter 'higher', 'lower', or 'yes': ");
            string response = Console.ReadLine().ToLower();

            if (response == "higher")
            {
                lowerBound = dayGuess + 1;
            }
            else if (response == "lower")
            {
                upperBound = dayGuess - 1;
            }
            else if (response == "yes")
            {
                Console.WriteLine($"Awesome! Happy birthday! Your birthday is on {GetMonthName(targetMonth)} {dayGuess}!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'higher', 'lower', or 'yes'.");
                i--;
            }
        }

        Console.WriteLine("I'm sorry, I couldn't guess your birthday month.");
    }

    static string GetMonthName(int month)
    {
        return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
    }
}
