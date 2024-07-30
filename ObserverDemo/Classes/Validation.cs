using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
/* Ice Task 2( activity 2.1.2)
 * Group 2
 * ST10158643
 * Hannah Michaelson */
namespace ObserverDemo.Classes
{
    public class Validation
    {
        public int number = 0;
        public bool valid = false;
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in menu string Input and ensure is a valid number 
        /// </summary>
        public int OptionInt(string input)
        {
            valid = false;
            try
            {
                if (!int.TryParse(input, out int num))
                {
                   
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a digit", " "));
                }else if (num <= 0 || num >= 7)
                {
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a num that is an option", " "));
               
                }
                else { valid = true; }
                return this.number = num;
            }
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Out of memory. Please reduce the number of ingredients or increase available memory.");
                Console.ResetColor();
            }
            
            return this.number;
        }
        /// <summary>
        /// Method to take in string input and ensure it is a valid number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
    public int ReceiveInt(string input)
    {
            valid = false;
        try
        {
            if (!int.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out int num))
            {
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a digit", " "));
                }
            else if (num <= 0)
            {
                throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a number greater than 0!!", " "));
            }
            else{  valid = true;}
            return this.number = num;
        }
        catch (UserException e)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();

        }
        catch (OutOfMemoryException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Out of memory. Please reduce the number of ingredients or increase available memory.");
            Console.ResetColor();
        }
        return this.number;
    }
}//end validation class

    /// <summary>
    /// Class to handle user exceptions
    /// </summary>
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }

    }//end user exception class
}//end namespace
