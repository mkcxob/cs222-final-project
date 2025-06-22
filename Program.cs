using System;

class OddsAndEvensGame
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Odds and Evens Game!\n");

        int mode = GetGameMode();
        bool userChoseOdd = GetOddOrEvenChoice();

        string player1 = "Player 1";
        string player2 = mode == 1 ? "Computer" : "Player 2";

        int player1Num = GetPlayerNumber(player1);

        int player2Num = mode == 1 ? GetComputerNumber() : GetSecondPlayerNumber();

        ShowChoicesAndSum(mode, player1Num, player2Num);

        int sum = player1Num + player2Num;
        DetermineWinner(mode, userChoseOdd, sum);
    }

    static int GetGameMode()
    {
        while (true)
        {
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1 - Play against Computer");
            Console.WriteLine("2 - Play against another Player");
            Console.Write("Enter 1 or 2: ");
            string input = Console.ReadLine();

            if (input == "1" || input == "2")
                return int.Parse(input);

            Console.WriteLine("Invalid input. Please enter 1 or 2.\n");
        }
    }

    static bool GetOddOrEvenChoice()
    {
        while (true)
        {
            Console.Write("Player 1, do you choose Odd or Even? (O/E): ");
            string choice = Console.ReadLine().Trim().ToUpper();

            if (choice == "O")
                return true;
            if (choice == "E")
                return false;

            Console.WriteLine("Invalid input. Please enter O for Odd or E for Even.\n");
        }
    }

    static int GetPlayerNumber(string playerName)
    {
        while (true)
        {
            Console.Write($"{playerName}, enter a number between 1 and 5: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 5)
                return num;

            Console.WriteLine("Invalid number. Please try again.\n");
        }
    }

    static int GetSecondPlayerNumber()
    {
        Console.Clear();
        return GetPlayerNumber("Player 2");
    }

    static int GetComputerNumber()
    {
        Random rnd = new Random();
        int number = rnd.Next(1, 6);
        Console.WriteLine("Computer has chosen its number.");
        return number;
    }

    static void ShowChoicesAndSum(int mode, int player1, int player2)
    {
        Console.WriteLine("\nRevealing numbers...");
        Console.WriteLine($"Player 1 chose: {player1}");
        Console.WriteLine((mode == 1 ? "Computer" : "Player 2") + $" chose: {player2}");

        int sum = player1 + player2;
        Console.WriteLine($"Sum of numbers: {sum} ({(sum % 2 == 0 ? "Even" : "Odd")})\n");
    }

    static void DetermineWinner(int mode, bool userChoseOdd, int sum)
    {
        bool sumIsOdd = sum % 2 != 0;
        string winner;

        if (sumIsOdd == userChoseOdd)
            winner = "Player 1 wins!";
        else
            winner = mode == 1 ? "Computer wins!" : "Player 2 wins!";

        Console.WriteLine(winner);
    }
}
