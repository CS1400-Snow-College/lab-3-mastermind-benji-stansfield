// Benji Stansfield-2/10/25-Lab 3 "Mastermind"

Console.Clear();

//Title
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(@"----------
MASTERMIND
----------
");

//Instructions
Console.WriteLine(@"I have a secret code consistinig of 4 letters between 'A' and 'G'.
You must crack the code by putting all of the letters in the correct spot in as little guesses as possible.");

Console.Write(@"
Press any key to begin");
Console.ReadKey(true);
Console.Clear();

//Creating the code
string secretWord = ""; //makes a blank word
Random rand = new Random();
char[] code = new char[4];
for (int i=0; i < 4; i++)
{
    code[i] = (char) rand.Next(97,104);
    secretWord += code[i];
}

Console.WriteLine(secretWord); //remove this after done

//Player guesses the code
int guessNumber = 0;
bool solved = false;

while (!solved)
{
    guessNumber++;

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Please guess a sequence of 4 lowercase letters-");
    Console.Write($"Guess {guessNumber}: ");

    string userGuess = Console.ReadLine().ToLower();

    if (userGuess.Length != 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Guess must be exactly 4 letters.");
        guessNumber--;
    };

    int correctPosition = 0, correctLetter = 0;
    bool[] counted = new bool[4];

    //Letters in the correct positions
    for (int i = 0; i < 4; i++)
    {
        if (userGuess[i] == secretWord[i])
        {
            correctPosition++;
            counted[i] = true;
        }
    }

    //Letters in the wrong positions
    for (int i = 0; i < 4; i++)
    {  
        if (userGuess[i] != secretWord[i])
        {
            for (int j = 0; j < 4; j++)
            {
                if (!counted[j] && userGuess[i] == secretWord[j])
                {
                    correctLetter++;
                    counted[j] = true;
                    break;
                }
            }
        }
    }

    //write lines for correct letters/positions
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Letters in the correct positions: {correctPosition}");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Letters in the wrong position: {correctLetter}");

    //determine the winner
    if (correctPosition == 4)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Congratulations!! You guessed the code in {guessNumber} guesses!");
        solved = true;
    }
};