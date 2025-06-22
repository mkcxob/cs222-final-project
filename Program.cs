using System;

class OddsAndEvensGame
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Odds and Evens Game!");

        string mode = GetGameMode();
        bool userChoseOdd = GetOddOrEvenChoice();
        int player1Number = GetPlayerNumber("Player 1");

        int player2Number = (mode == "1") ? GetComputerNumber() : GetSecondPlayerNumber();

        ShowChoicesAndSum(mode, player1Number, player2Number);

        DetermineWinner(mode, userChoseOdd, player1Number + player2Number);

        Console.WriteLine("Thanks for playing!");
    }

    static string GetGameMode()
    {
        Console.WriteLine("Choose game mode:");
        Console.WriteLine("1 - Play against computer");
        Console.WriteLine("2 - Play against another user");
        Console.Write("Enter 1 or 2: ");
        string mode = Console.ReadLine().Trim();

        while (mode != "1" && mode != "2")
        {
            Console.Write("Invalid input. Please enter 1 or 2: ");
            mode = Console.ReadLine().Trim();
        }

        return mode;
    }

    static bool GetOddOrEvenChoice()
    {
        Console.Write("Player 1 - Choose Odd or Even (O/E): ");
        string choice = Console.ReadLine().Trim().ToUpper();

        while (choice != "O" && choice != "E")
        {
            Console.Write("Invalid input. Please enter 'O' for Odd or 'E' for Even: ");
            choice = Console.ReadLine().Trim().ToUpper();
        }

        return (choice == "O");
    }

    static int GetPlayerNumber(string playerName)
    {
        Console.Write($"{playerName} - Pick a number between 1 and 5: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 5)
        {
            Console.Write("Invalid number. Pick a number between 1 and 5: ");
        }

        return number;
    }

    static int GetComputerNumber()
    {
        Random rand = new Random();
        int number = rand.Next(1, 6);
        Console.WriteLine($"Computer picked: {number}");
        return number;
    }

    static int GetSecondPlayerNumber()
    {
        Console.Clear();
        Console.WriteLine("Player 2 - It’s your turn now.");
        return GetPlayerNumber("Player 2");
    }

    static void ShowChoicesAndSum(string mode, int player1, int player2)
    {
        Console.WriteLine($"Player 1 chose: {player1}");
        Console.WriteLine(mode == "1" ? $"Computer chose: {player2}" : $"Player 2 chose: {player2}");
        Console.WriteLine($"Sum of numbers: {player1 + player2}");
    }

    static void DetermineWinner(string mode, bool userChoseOdd, int sum)
    {
        bool sumIsOdd = (sum % 2 != 0);
        bool userWins = (userChoseOdd && sumIsOdd) || (!userChoseOdd && !sumIsOdd);

        if (userWins)
        {
            Console.WriteLine("Player 1 wins!");
        }
        else
        {
            Console.WriteLine(mode == "1" ? "Computer wins!" : "Player 2 wins!");
        }
    }
}
