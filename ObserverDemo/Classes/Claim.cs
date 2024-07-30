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
{   // Define a delegate type for the claim completed event
    public delegate void ClaimCompletedHandler(object sender, EventArgs e);
    // Notification Class for Policy
    public class Claim
    {
        //Notifies the Observers of changes  
        public int claimNo { get; }
        public bool IsCompleted { get; private set; }

        // Define a delegate type for the claim completed event
       // public delegate void ClaimCompletedHandler(object sender, EventArgs e);

        // Event to notify observers when the claim is completed
        public event ClaimCompletedHandler ClaimCompleted;

        public Claim(int id)
        {
            claimNo = id;
        }

        // Method to mark the claim as completed
        public void MarkAsIncomplete()
        {
            IsCompleted = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"  Claim (Subject) state changes:  Claim {claimNo} marked as incomplete.");
            UpdateObservers();
        }
        public void MarkAsCompleted()
        {
            IsCompleted = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"  Claim (Subject) state changes:  Claim {claimNo} marked as complete.");
            UpdateObservers();
        }

        // Method to invoke the ClaimCompleted event
        protected virtual void UpdateObservers()
        {
            //passing the sender and the event arguments
            Console.WriteLine($"   Claim (Subject) notifying observers of state change...");
            Console.ResetColor();
            ClaimCompleted?.Invoke(this, new ClaimCompletedEventArgs(this));
        }
    }

}