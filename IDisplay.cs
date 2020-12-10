// In order to adhere to the Interface Segregation principle, the IUserInterfaceElement has been split into it's own separate interfaces.
// This is so that classes that use said interface do not need to rely on methods that they don't use; e.g. Book and Update();
namespace SOLID_Library_System
{
    public interface IDisplay
    {
        void Display();
    }
}