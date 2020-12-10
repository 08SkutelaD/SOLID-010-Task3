// Creating a Publication class allows us to code in terms of Publication and make use of Liskov's Substitution Principle.
using System;

namespace SOLID_Library_System
{
    
    public class Publication : IDisplay
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string DatePublished { get; set; }
        public string Category { get; set; }

        public Publication(string id, string title, string publisher, string datePublished, string category)
        {
            // Using LibraryHelper to dictate IDs and handle categories rather than having each Publication do it itself helps to stick to the Single Responsibility Principle.
            this.ID = id;  
            this.Title = title;
            this.Publisher = publisher;
            this.DatePublished = datePublished;
            this.Category = category;
        }

        // Reusing the Display() code for the Book class here instead allows all library Publications to be displayed.
        // If a subtype needs to display differently, we just override this method. 
        // Use of the 'virtual' keyword here allows the method to be overwritten, but still retain its functionality if it isn't overwritten.
        public virtual void Display()
        {
            Console.WriteLine(ID + ", " + Title + ", " + Publisher + ", " + DatePublished + ", " + Category);
        }
    }
}