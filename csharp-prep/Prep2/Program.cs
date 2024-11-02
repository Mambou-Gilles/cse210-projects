using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);

        string letter;

        string plus = "+";
        string minus = "-";

        if (grade >= 90) {
            letter = "A";
        }
        else if  (grade >= 80) {
            letter = "B";
        }
        else if  (grade >= 70) {
            letter = "C";
        }
        else if  (grade >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }

        //determine the sign of the grade
        if(grade % 10 >= 7 && grade < 97 && grade > 60){
            Console.WriteLine($"Your letter grade is {letter}{plus}.");
        }else if(grade % 10 <= 3 && grade <97 && grade >60){
            Console.WriteLine($"Your letter grade is {letter}{minus}.");
        }else{
            Console.WriteLine($"Your letter grade is {letter}.");
        }


        //Check is the user passed or failed the class
        if (grade >= 70) {
            Console.WriteLine($"Congratulation! You passed the course.");
        }
        else {
            Console.WriteLine($"You failed the course, the passing grade is 70% or C-.");
        }
    }
}