string[] words = ["apple", "pear", "orange", "summer", "fall"];

// Generate random word from array
Random randomWord = new Random();
int index = randomWord.Next(words.Length);

// Create new game
Hangman hangman = new Hangman(words[index]);
bool running = true;

while (running)
{
   string? guess = Console.ReadLine();

   if (string.IsNullOrWhiteSpace(guess))
   {
      Console.WriteLine($"Invalid. Make a guess with a letter or word");
      continue;
   }
   bool continueGame = hangman.CheckGuess(guess);
   if (!continueGame)
   {
      running = false;
   }
   hangman.DisplayCurrentState();
}