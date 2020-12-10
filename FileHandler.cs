// In order to follow the Single Responsibility Principle we move this code into it's own class.
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
    public class FileHandler
    {
        private string filetype;

        // In order to follow the Dependency Inversion Principle, we hand the FileHandler it's file type when we create an instance of it.
        public FileHandler(string filetype)
        {
            this.filetype = filetype;
        }

        public List<Publication> ReadFromFile()
        {
            List<Publication> publications;
            switch (this.filetype)
            {
                case "JSON":
                    if (File.Exists(@"library.json"))
                    {
                        string exisitingData;
                        using (StreamReader reader = new StreamReader(@"library.json", Encoding.Default))
                        {
                            exisitingData = reader.ReadToEnd();
                        }
                        publications = JsonConvert.DeserializeObject<List<Publication>>(exisitingData);
                    }
                    else
                    {
                        publications = new List<Publication>();
                    }
                    return publications;
                case "XML":
                    if (File.Exists(@"library.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(List<Publication>));
                        using (var reader = new StreamReader(@"library.xml"))
                        {
                            try
                            {
                                publications = (List<Publication>)serializer.Deserialize(reader);
                            }
                            catch
                            {
                                // Could not be deserialized to this type.
                                Console.WriteLine("Could not load file");
                                publications = new List<Publication>{}; // Added for error correction.
                            } 
                        }
                    }
                    else
                    {
                        publications = new List<Publication>();
                    }
                    return publications;
                default:
                    publications = new List<Publication>{};
                    return publications;
            }
        }

        public void WriteToFile(List<Publication> publications)
        {
            switch(this.filetype)
            {
                case "JSON":
                    using (StreamWriter file = File.CreateText(@"library.json"))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        jsonSerializer.Formatting = Formatting.Indented;
                        jsonSerializer.Serialize(file, publications);
                    }
                    break;
                case "XML":
                    var serializer = new XmlSerializer(typeof(List<Book>));
                    using (var writer = new StreamWriter(@"library.xml"))
                    {
                        serializer.Serialize(writer, publications);
                    }
                    break;
            }      
        }
    }
}