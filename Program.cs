using System;

namespace PRG521_FA4
{
    class PasswordGenerator
    {
        static void Main(string[] args)
        {
            // Ask the user for the number of passwords they want to generate.
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");
            Console.Write("How many passwords would you like to generate? ");

            // Validate the input to ensure it contains only numbers
            int numPasswords;
            while (!int.TryParse(Console.ReadLine(), out numPasswords))
            {
                Console.WriteLine(" ");
                Console.WriteLine("Your input is invalid. Please enter a number.");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
                Console.Write("How many passwords would you like to generate? ");
                Console.WriteLine(" ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
            }

            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");

            for (int i = 0; i < numPasswords; i++)
            {
                // Ask the user for the first name.
                Console.Write($"Enter first name #{i + 1}: ");
                string firstName = ReadName();

                Console.WriteLine(" ");

                // Ask the user for the last name.
                Console.Write($"Enter last name #{i + 1}: ");
                string lastName = ReadName();

                // Concatenate the first and last names with a space in between.
                string fullName = $"{firstName} {lastName}";

                // Generate the password from the full name.
                string password = GeneratePassword(fullName);

                // Display the password to the user.
                Console.WriteLine(" ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine($"Password for {fullName}: {password}");
                Console.WriteLine(" ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
            }
        }

        // Validate the input to ensure it contains only letters
        static string ReadName()
        {
            string name = Console.ReadLine();

            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your input is invalid. Please enter letters only.");
                    Console.WriteLine(" ");
                    Console.Write("Enter a valid name: "); 
                    return ReadName();
                }
            }

            return name;
        }

        static string GeneratePassword(string fullName)
        {
            // Convert the full name to lower case
            fullName = fullName.ToLower();

            // Initialize variables to keep track of the letters eliminated and the password
            int numLettersEliminated = 0;
            string password = "";

            // Loop through each character in the full name
            foreach (char c in fullName)
            {
                // Skip over 'a', 'e', and 't' characters
                if (c == 'a' || c == 'e' || c == 't')
                {
                    numLettersEliminated++;
                }

                // Replace spaces with "S&?"
                else if (c == ' ')
                {
                    password += "S&?";
                }

                // Double all vowels except 'a' and 'e'
                else if ("aeiou".Contains(c))
                {
                    password += c.ToString() + c.ToString();
                }

                // Copy over all other characters
                else
                {
                    password += c;
                }
            }

            // Add the number of letters eliminated to the end of the password
            password += numLettersEliminated.ToString();

            // Return the password
            return password;
        }
    }
}
