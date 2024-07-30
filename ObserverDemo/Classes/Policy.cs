using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Ice Task 2( activity 2.1.2)
 * Group 2
 * ST10158643
 * Hannah Michaelson */
namespace ObserverDemo.Classes
{
    // Define an EventArgs class for events related to claim completion
    public class ClaimCompletedEventArgs : EventArgs
    {
        public ClaimCompletedEventArgs(Claim claim)
        {
            CompletedClaim = claim;
        }

        public Claim CompletedClaim { get; }
    }
    // Notifier Class for Policy
    public class Policy
    {
        public List<Claim> Claims { get; } = new List<Claim>();

        // Define a delegate type for the claim completed event
        public delegate void ClaimCompletedHandler(object sender, ClaimCompletedEventArgs args);

        // Event to notify observers when a claim is completed
        public event ClaimCompletedHandler ClaimCompleted;

        // Method to add a claim to the policy
        public void AddClaim(Claim claim)
        {
            Claims.Add(claim);
            claim.ClaimCompleted += OnClaimCompleted;
        }

        // Event handler for when a claim is completed
        private void OnClaimCompleted(object sender, EventArgs e)
        {
            if (e is ClaimCompletedEventArgs args)
            {
                Console.ForegroundColor = ConsoleColor.Blue;                
                Console.WriteLine($"    Policy (ConcreteObserver) reacts to event...\n\n    Claim {args.CompletedClaim.claimNo} completed");
                Console.ResetColor();
            }
        }
    }// end Policy class

}//end namespace
