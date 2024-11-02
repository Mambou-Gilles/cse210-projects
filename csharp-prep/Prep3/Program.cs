using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is the Magic Number Guess game where you guess the number ") ;
        Console.WriteLine();
        Random number = new Random();
        double magic_number = number.Next(1, 100);
        int number_of_guess = 0;

        

        while (true) {
            Console.Write("What is your guess? ");
            double yourNumber = double.Parse(Console.ReadLine());
            number_of_guess++;

            if ( magic_number > yourNumber){
                Console.WriteLine("Higher");
            }
            else if (magic_number < yourNumber){
                Console.WriteLine("Lower");
            }
            else {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {number_of_guess} guesses");
                Console.Write("Do you want to play again? Enter Y or YES to continue, N or NO to end the game: ");
                string play_again = Console.ReadLine().ToUpper();
                if (play_again == "Y" || play_again == "YES")
                {
                    magic_number = number.Next(1, 100);
                    continue;
                }
                else
                {
                    Console.WriteLine("Thanks for playing, see you again when you change your mind!");
                    break;
                }
            }
        }

        
    }
}