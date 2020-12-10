// For these subtypes of the Publication class, we can follow Liskov's Substitution Principle.
// We can treat these subtypes as if they were the Parent class. This is an example of Liskov's principle.
namespace SOLID_Library_System
{
    public class Magazine : Publication
    {
        public Magazine(string id, string title, string publisher, string datePublished, string category) : base(id, title, publisher, datePublished, category)
        {
            // As there are no differences between Magazine and Publication, the only thing that is require for this class is a constructor.
            // This constructor passes the information straight to it's parent class (Publication) through 'base' keyword.
            // As the Publication class follows SOLID and this class doesn't differ from that, no principles are broken.
        }
    }
}