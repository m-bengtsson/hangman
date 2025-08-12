// error handling for when guess is not length of secret word


using System.Reflection;

public class Hangman
{
   private string SecretWord { get; set; }
   private List<Char> CorrectGuesses { get; set; }
   private List<Char> WrongGuesses = new List<char>();

   private int MaxWrongGuesses { get; set; }

   public Hangman(string secretWord)
   {
      SecretWord = secretWord.ToLower();
      CorrectGuesses = Enumerable.Repeat('_', secretWord.Length).ToList();
      MaxWrongGuesses = 10;
   }
   public void DisplayCurrentState()
   {
      Console.WriteLine($"* STATUS * ");

      Console.Write($"Word: ");
      foreach (var guess in CorrectGuesses)
      {
         Console.Write($"{guess} ");
      }

      Console.Write($"\nWrong guesses: ");
      foreach (char guess in WrongGuesses)
      {
         Console.Write($"{guess} ");
      }
      Console.WriteLine($"\nGuesses left: {MaxWrongGuesses}");
   }

   public bool CheckGuess(string guess)
   {
      guess = guess.ToLower().Trim();

      // Whole word guess
      if (guess.Length > 1)
      {
         if (guess == SecretWord)
         {
            // Fill in all letters from secret word
            for (int i = 0; i < SecretWord.Length; i++)
            {
               CorrectGuesses[i] = SecretWord[i];
            }
            Console.WriteLine($"You won! You guessed the whole word.");
            return false;
         }
         else
         {
            Console.WriteLine($"Wrong word, try again");
            WrongGuesses.Add('*');
            MaxWrongGuesses--;
         }
      }
      // Single letter guess
      if (guess.Length == 1)
      {
         char letter = Convert.ToChar(guess);

         // Check if letter is already guessed
         if (CorrectGuesses.Contains(letter))
         {
            Console.WriteLine($"You already guessed this letter correctly");
            return true;
         }
         if (WrongGuesses.Contains(letter))
         {
            Console.WriteLine($"You already guessed this letter wrong");
            return true;
         }
         // If letter is correct
         if (SecretWord.Contains(letter))
         {
            for (int i = 0; i < SecretWord.Length; i++)
            {
               if (SecretWord[i] == Convert.ToChar(guess))
               {
                  CorrectGuesses[i] = Convert.ToChar(guess);
               }
            }
            Console.WriteLine($"You guessed a correct letter!");

            // Compare lists
            if (CorrectGuesses.SequenceEqual(SecretWord))
            {
               Console.WriteLine($"You guessed all letters and won the game!");
               return false;
            }
         }
         // If letter is wrong
         else
         {
            WrongGuesses.Add(letter);
            MaxWrongGuesses--;

            Console.WriteLine($"Wrong letter, try again");
            if (MaxWrongGuesses == 0)
            {
               Console.WriteLine($"You lost! You've used up all your guesses.");
               return false;
            }
         }
      }
      Console.WriteLine($"- END - \n");
      return true;
   }
}