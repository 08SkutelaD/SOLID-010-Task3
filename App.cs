using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace SOLID_Library_System
{
    public class App
    {
        private CurrentTime currentTime;
        private FileHandler fileHandler;
        private LibraryHelper libraryHelper;
        private List<Publication> publications;

        // Following the Dependency Inversion Principle, the App class gets handed the other classes it relies on in it's constructor.
        public App(CurrentTime currentTime, FileHandler fileHandler, LibraryHelper libraryHelper)
        {
            this.currentTime = currentTime;
            this.fileHandler = fileHandler;
            this.libraryHelper = libraryHelper;
        }

        public void Run()
        {
            LoadData();
            AddPublications();
            DisplayPublications();
            ExportData();
        }

        private void LoadData()
        {
            Console.Clear();
            currentTime.Update();
            currentTime.Display();
            string userInput = Input("Load data from file? (Y/N)");
            switch(userInput)
            {
                case "Y":
                    publications = fileHandler.ReadFromFile();
                    break;
                case "N":
                    publications = new List<Publication>{};
                    break;
                default:
                    publications = new List<Publication>{};
                    break;
            }
        }

        private void ExportData()
        {
            Console.Clear();
            currentTime.Update();
            currentTime.Display();
            string userInput = Input("Export data to file? (Y/N)");
            if(userInput == "Y")
            {
                fileHandler.WriteToFile(publications);
            }
        }

        private void AddPublications()
        {
            bool done = false;

            string another = Input("Add a book? (Y/N)");
            if (another == "N")
            {
                done = true;
            }

            while (!done)
            {
                string newCategory = libraryHelper.SelectCategory();
                Console.Clear();
                Console.WriteLine("You have sected {0}", newCategory);

                string newID = libraryHelper.GenerateID(newCategory);
                string newTitle = Input("Title");
                string authorsString = Input("Author (leave blank for no author, separate multiple authors with commas)");
                string newPublisher = Input("Publisher");
                string newDatePublished = Input("Date of publication");
                string newGenre = Input("Genre (leave blank for non-fiction)");
                string[] newAuthors;

                if(authorsString == "")
                {
                    authorsString = null;
                }
                if(newGenre == "")
                {
                    newGenre = null;
                }

                if(authorsString != null)
                {
                    newAuthors = authorsString.Split(',').ToArray();
                }
                else
                {
                    newAuthors = null;
                }
                

                if(newAuthors != null && newGenre == null)
                {
                    publications.Add(new Book(newID, newTitle, newPublisher, newDatePublished, newCategory, newAuthors));
                }
                else if(newAuthors != null && newGenre != null)
                {
                    publications.Add(new Book(newID, newTitle, newPublisher, newDatePublished, newCategory, newAuthors, newGenre));
                }
                else
                {
                    publications.Add(new Magazine(newID, newTitle, newPublisher, newDatePublished, newCategory));
                }

                another = Input("Add another? (Y/N)");
                if (another == "N")
                {
                    done = true;
                }

            };
        }

        private void DisplayPublications()
        {
            Console.Clear();
            currentTime.Update();
            currentTime.Display();
            Console.WriteLine("All publications in library\n");
            foreach (var book in publications)
            {
                book.Display();
            }
            Console.WriteLine("Press any button to continue.");
            Console.ReadKey(true);
        }

        private string Input(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }
    }
}