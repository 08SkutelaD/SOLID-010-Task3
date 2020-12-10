// Moving this to an interface not only helps the Single-Responsibilty principle but also allows for other classes to implement input features too.
using System;

namespace SOLID_Library_System
{
    public interface IInput
    {
        string Input();
    }
}