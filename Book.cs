// For these subtypes of the Publication class, we can follow Liskov's Substitution Principle.
// We can treat these subtypes as if they were the Parent class. This is an example of Liskov's principle.
using System;

namespace SOLID_Library_System
{
    public class Book : Publication
    {
        // Added a Genre property for fiction books. If this is set to null, then the book is non-fiction.
        public string Genre { get; set; }
        // Changed the Author property to a string array so that a book can have multiple authors.
        public string[] Authors { get; set; }
        // These two properties fit with the Open-Closed Principle as we are adding on to what Publication provides rather than changing Publication.

        // This constructor is for Books that do not have a genre (non-fiction).
        public Book(string id, string title, string publisher, string datePublished, string category, string[] authors) : base(id, title, publisher, datePublished, category)
        {
            this.Authors = authors;
            this.Genre = null;
        }
        // This constructor is for Books that do have a genre (fiction).
        public Book(string id, string title, string publisher, string datePublished, string category, string[] authors, string genre) : base(id, title, publisher, datePublished, category)
        {
            this.Authors = authors;
            this.Genre = genre;
        }

        // By overriding this method, we allow for extension but prevent modification of the Parent class (Publication).
        // This is a good example of following the Open-Closed Principle.
        public override void Display()
        {
            Console.Write(ID  + ", " + Title + ", ");
            foreach(string a in Authors)
            {
                Console.Write(a  + ", ");
            }
            Console.Write(Publisher  + ", " + DatePublished  + ", " + Category  + ", ");
            if(Genre == null)
            {
                Console.WriteLine("N/A");
            }
            else
            {
                Console.WriteLine(Genre);
            }
        }
    }
}