public class ProgramUI
{
    string[]? blankGameArr = null;
    string[]? gameArr = null;
    bool gameRunning = true;
    int numInWord = 0;
    int hangmanBodyCount = 0;
    public void Run()
    {
        Game();
    }

    public void Game()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        string[] words = { "compete", "sector", "explain", "passage", "inflate", "patient", "pillow" };

        Random randomNum = new Random();
        int wordNum = randomNum.Next(0, 7);

        string gameWord = words[wordNum];

        Array.Resize(ref gameArr, gameWord.Length);
        for (int i = 0; i < gameWord.Length; i++)
        {
            gameArr[i] = new string(gameWord[i], 1);
        }

        Array.Resize(ref blankGameArr, gameArr.Length);
        for (int i = 0; i < gameArr.Length; i++)
        {
            blankGameArr[i] = "_";
            System.Console.Write($"{blankGameArr[i]} ");
        }

        while (gameRunning)
        {
            System.Console.WriteLine("Guess a letter:");
            string userGuess = Console.ReadLine();

            CheckForLetter(userGuess, gameArr);
        }
    }

    public void DisplayBody(int hangmanBody)
    {
        switch (hangmanBody)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Head added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Torso added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Left arm added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Right arm added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Left leg added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Right leg added");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 7:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Game Over...");
                Console.ForegroundColor = ConsoleColor.White;
                gameRunning = false;
                break;
            default:
                break;
        }
    }
    public void DisplayBlank()
    {
        for (int i = 0; i < gameArr.Length; i++)
        {
            System.Console.Write($"{blankGameArr[i]} ");
        }
    }

    public void DisplayBlankUpdate(int letter, string letterAnswer)
    {
        blankGameArr[letter] = letterAnswer;
    }

    public void CheckForLetter(string guess, string[] arr)
    {
        int wrongGuess = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == guess && blankGameArr[i] == "_")
            {
                Console.Clear();

                DisplayBlankUpdate(i, guess);
                CorrectAnswer();
                numInWord++;
            }
            else
            {
                wrongGuess++;
            }
        }

        if (wrongGuess == arr.Length)
        {
            Console.Clear();

            wrongAnswer();
        }

        if (numInWord == arr.Length)
        {
            Console.Clear();

            DisplayBlank();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\nCongrats! You got guessed the word!");
            Console.ForegroundColor = ConsoleColor.White;
            gameRunning = false;
        }
        else
        {
            DisplayBlank();
        }
    }

    public void CorrectAnswer()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Correct guess!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void wrongAnswer()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Sorry, wrong guess... guess again");
        Console.ForegroundColor = ConsoleColor.White;
        hangmanBodyCount++;
        DisplayBody(hangmanBodyCount);
    }
}