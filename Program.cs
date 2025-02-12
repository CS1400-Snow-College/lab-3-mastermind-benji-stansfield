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
You must crack the code by putting all of the letters in the correct spot within 10 guesses.");

Console.Write(@"
Press any key to begin");
Console.ReadKey(true);
Console.Clear();

//Creating the code
string secretWord = ""; //makes a blank word
Random rand = new Random();
char code;
for (int i=0; i<5; i++)
{
    code = (char) rand.Next(97,104);
    if (!secretWord.Contains(code))
    {
        secretWord += code;
    }
}

Console.WriteLine(secretWord); //remove this after done

//Player guesses the code
int guessNumber = 0;

do
{
    guessNumber++;

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Please guess a sequence of 4 lowercase letters with no repeats-");
    Console.Write($"Guess {guessNumber}/10: ");

    string userGuess = Console.ReadLine().ToLower();
    if (userGuess.Length != 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Guess must be exactly 4 letters.");
    };
}
while (guessNumber<=9);