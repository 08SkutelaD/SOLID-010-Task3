// In order to stick to the Single Responsibility Principle LibraryHandler now handles categorizations in its entirety rather than just containing a list of possible categories.
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Library_System
{
    public class LibraryHelper
    {
        // To follow the Dependency Inversion Principle, the Library helper class has its categories handed to it through the constructor rather than being hard-coded.
        public List<String> Categories;
        
        public LibraryHelper(List<String> categories)
        {
            this.Categories = categories;
        }

        public string SelectCategory()
        {
            Console.Clear();
            Console.WriteLine("Select a category:");
            for (int i = 0; i < Categories.Count; i++)
            {
                Console.WriteLine(i + ": " + Categories[i]);
            }

            int selectedCategoryID = 0;
            bool validID = false;
            do
            {
                try
                {
                    selectedCategoryID = Convert.ToInt32(Console.ReadLine());
                    if (selectedCategoryID >= 0 && selectedCategoryID < Categories.Count)
                    {
                        validID = true;
                    }
                    else
                    {
                        Console.WriteLine("Option not available. Please try again");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Please try again");
                }
            } while (!validID);

            return Categories[selectedCategoryID];
        }

        public string GenerateID(string category)
        {
            Categories.Add(category); //Add to categories list so we can easily count how many we have
            int count = Categories.Where(x => x.Equals(category)).Count(); //Using LINQ Count the number of existing books of this category
            string ID = category.Substring(0, 4) + count.ToString("00");
            return ID;
        }
    }
}