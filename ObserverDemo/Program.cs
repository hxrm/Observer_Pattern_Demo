using ObserverDemo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Ice Task 2( activity 2.1.2)
 * Group 2
 * ST10158643
 * Hannah Michaelson */
namespace ObserverDemo
{
    public class Program
    {

        // Create a new policy
        public static Policy policy = new Policy();
        public static Validation v = new Validation();
        static void Main(string[] args)      
        {

           GatherData();
           SetState();
           policy.ClaimCompleted += Policy_ClaimCompleted;
           Console.WriteLine("The end :)");
           Console.ReadLine();
        }
        public static void GatherData()
        {
            do
            {
                Console.WriteLine("Enter the number of claims:");
                int numOfClaims = v.ReceiveInt(Console.ReadLine());
                for (int i = 1; i <= numOfClaims; i++)
                {
                    policy.AddClaim(new Claim(i));
                }
            } while (!v.valid);
          
        }
        public static void SetState()
        {
            foreach (Claim claim in policy.Claims)
            {
                do
                {
                    Console.WriteLine($"Enter status for Claim {claim.claimNo}\n 1. Completed \n 2. Incomplete");
                    int ans = v.OptionInt(Console.ReadLine());

                    if (ans == 1)
                    {
                        claim.MarkAsCompleted();
                    }
                    if (ans == 2)
                    {
                        claim.MarkAsIncomplete();
                    }
                } while (!v.valid);
            }
        }
        // Event handler for the Policy's ClaimCompleted event
        private static void Policy_ClaimCompleted(object sender, ClaimCompletedEventArgs args)
        {
            Console.WriteLine($"Policy reacted to claim {args.CompletedClaim.claimNo} completion.");
        }
    }//end class
}// end namespace
