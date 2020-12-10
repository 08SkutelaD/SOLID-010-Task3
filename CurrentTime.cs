// With our changes to the interfaces, we now need to pull from two individual interfaces for this class.
// Aside from this, this class does not break any of the SOLID principles.
using System;

namespace SOLID_Library_System
{
    public class CurrentTime : IDisplay, IUpdate
    {
        private DateTime time;

        public CurrentTime()
        {
            time = System.DateTime.Now;
        }
        public void Display()
        {
            Console.WriteLine($"[ Time: {time.ToString("HH:mm:ss")} ]");
        }
        public void Update()
        {
            time = System.DateTime.Now;
        }
    }
}