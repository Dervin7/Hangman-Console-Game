public class ProgramUI
{
    public void Run()
    {
        DisplayBody();
        Game();
    }

    public void Game()
    {
        string[] words = { "compete", "sector", "explain", "passage", "inflate", "patient", "pillow" };

        Random randomNum = new Random();
        int wordNum = randomNum.Next(0, 8);

        string gameWord = words[wordNum];

        string[]? gameArr = null;
        Array.Resize(ref gameArr, gameWord.Length);
        for (int i = 0; i < gameWord.Length; i++)
        {
            gameArr[i] = new string(gameWord[i], 1);
        }

        for (int i = 0; i < gameArr.Length; i++)
        {
            gameArr[i] = "_";
            System.Console.Write($"{gameArr[i]} ");
        }

        System.Console.WriteLine("Guess a letter:");
        string userGuess = Console.ReadLine();

        CheckForLetter(userGuess, gameArr);
    }

    public void DisplayBody()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Red;
    }

    public void DisplayBlank(string[] arrBlank)
    {
        string[]? blankGameArr = null;
        Array.Resize(ref blankGameArr, arrBlank.Length);

        for (int i = 0; i < arrBlank.Length; i++)
        {
            blankGameArr[i] = "_";
            System.Console.WriteLine($"blankGameArr: {blankGameArr[i]}");
        }
    }

    public void CheckForLetter(string guess, string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == guess)
            {
                arr[i] = guess;
                goto DoneWithForLoop;
            }
            else
            {
                System.Console.WriteLine("Sorry not a correct letter, guess again...");
            }
        }
    DoneWithForLoop:
        System.Console.WriteLine("Correct guess!");
    }
}