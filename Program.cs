using System;
using System.Collections.Generic;

namespace SOLID_Library_System
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrentTime currentTime = new CurrentTime();
            FileHandler fileHandler = new FileHandler("JSON");
            List<String> categories = new List<string>{ "Programming", "Systems Analysis", "E - Commerce", "Interaction Design", "Web Design" };
            LibraryHelper libraryHelper = new LibraryHelper(categories);
            App app = new App(currentTime, fileHandler, libraryHelper);
            app.Run();
        }
    }
}