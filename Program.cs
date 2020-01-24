using System;

namespace Lab4
{
    class Program
    {
        class Program_Counter
        {
            public int counter = 0;
        }
        static void Main(string[] args)
        {   //bool to confirm success of parse method for user input
            bool optionV;
            int quitValidation;
            //to loop or not to loop.  This is the question that defines our very existence (I must be tired today. I get really weird)
            int option = 1;
            //storage for value entered by user
            int value_stop = 0;
            Console.WriteLine("Learn your squares and cubes!\n");
            //prompt user for info
            while (option != 0)
            {
                Console.WriteLine("Enter in a number for a table with the square and cube of all the numbers from 1 to the number you entered:\n\n");
                //store the value entered by the user
                value_stop = ValidationCheck();

                //method to display the table
                PrintSquare_Cube(value_stop);
                Console.WriteLine("The table has been produced as we promised! Can I go now? Enter 0 to end and 1 to continue");
                option = ExitCheck();
            }
        }
        //checks if users input for number range is parsed as an int
        public static int ValidationCheck()
        {   //counter to store invalid inputs
            int counter = 4;
            //storage for valid user input 
            int userValue = -1;
            //while loops gives user 4 chances to correct input issues
            while (counter > 0)
            {
                //try block to try and parse input as an int
                try
                {
                    userValue = int.Parse(Console.ReadLine());
                    return userValue;
                }
                //corresponding catch block to catch errors and prompt the user to try entering a number again
                catch (Exception e)
                { 
                    Console.WriteLine("Could not parse entry to type int");
                    Console.WriteLine("Why are you doing this to me? I need a number.");
                    //decriments variable counter each time they enter in an invalid value
                    counter--;
                    //lets user know how many input attemepts they have left
                    Console.WriteLine($"You have {counter} tries left to enter a valid number");
                }
            }
            //exit the program after input attemepts exhausted
            Environment.Exit(0);
            //Function needs a return here even though this line is never reached
            return ValidationCheck();
        }
        //method to check input for continue/exit values
        public static int ExitCheck()
        {
            //storage for count of bad inputs
            int count = 0;
            //storage for continue
            int quitValidation;
            //holds boolean if parse succeeded or not
            bool optionV;
            //Trys to parse input to int and stores if process succeeded
            optionV = int.TryParse(Console.ReadLine(), out quitValidation);
            //checks if parse of user input was successful and if input is a 1 or a zero
            while((count < 3 && optionV == false) || (quitValidation != 0 && quitValidation != 1))
            {
                Console.WriteLine("Invalid entry! Please enter 1 to continue or 0 to exit");
                optionV = int.TryParse(Console.ReadLine(), out quitValidation);
                count++;
            }
            //if too many bad inputs exits the program
            if(count == 3 && optionV == false)
            {
                Console.WriteLine("To many bad inputs.  Exiting thee program.");
                Environment.Exit(0);
                return quitValidation;
            }
            else
            {
                return quitValidation;
            }
        }
        //method to print the table
        public static void PrintSquare_Cube(int max)
        {
            //holds the value entered by the user in the method
            int number = max;
            //hold the square for all numbers calculated
            int square;
            //hold the cube for all the numbers calculated
            int cube;
            //formatting for the table
            Console.WriteLine("==============================================");
            Console.WriteLine(String.Format($"{"THE POWER TABLE",-10}"));
            Console.WriteLine("==============================================");
            Console.WriteLine("Number           It's Square         It's Cube ");
            Console.WriteLine("=======          ===========         =========");
            //loop through numbers starting at 1 and ending at number entered by user
            for (int i = 1; i <= max; i++)
            {
                number = i;
                //calculate the square of iteration i
                square = i * i;
                //calculate the cube of iteration i
                cube = i * i * i;
                //print out the calculated values in using formatting so that the numbers line up and everything is uniformed
                Console.WriteLine(String.Format($"{number,-10}     |       {square,-10}|       {cube,5}"));
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine("==============================================");
        }

    }
}
