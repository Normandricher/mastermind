using MastermindLibrary;

Mastermind masterMind = new Mastermind();
string? input = String.Empty;
int currentAttempt = 1;

//Debug
Console.WriteLine(String.Format("Current Answer: {0}", masterMind.Answer));
//Debug

Console.WriteLine("The Mastermind has setup a code you must attempt to guess.  Please enter 4 numbers from 1 to 6, you can also enter exit to quit");
Console.WriteLine(String.Format("You have {0} total guesses", masterMind.MaxAttempt));
Console.Write("Guess : ");
input = Console.ReadLine();
while (currentAttempt < masterMind.MaxAttempt && input.ToUpper() != "EXIT")
{
    if (!String.IsNullOrEmpty(input) && (Int32.TryParse(input, out int value) && input.Length == masterMind.Length))
    {
        int[] guess = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            guess[i] = Int32.Parse(input[i].ToString());
        }
        char[] results = masterMind.CheckAnswer(guess);
        Console.WriteLine("Result: " + String.Join("", results));
        if (!results.Contains(' ') && !results.Contains('-'))
        {
            Console.WriteLine("Congratulations, you guessed the correct code!");
            Console.WriteLine(String.Format("Answer: {0}", masterMind.Answer));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            return;
        }
        else
        {
            if (currentAttempt + 1 != masterMind.MaxAttempt)
            {
                Console.WriteLine(String.Format("Looks like your guess wasn't correct.  You have {0} guesses left, please try again", masterMind.MaxAttempt - currentAttempt));
            }
            else
            {
                Console.WriteLine("This is your last attempt!");
            }
            currentAttempt++;
        }
    }
    else
    {
        Console.WriteLine("The guess you entered was not a number or the right length, please enter a 4 digit number, each number being from 1 to 6");
    }
    Console.Write("Guess : ");
    input = Console.ReadLine();
}
if (input.ToUpper() != "EXIT")
{
    Console.WriteLine("You weren't able to guess the code in time, sorry you lose.");
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();
}
return;