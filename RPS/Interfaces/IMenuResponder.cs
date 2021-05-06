using System;
using RPS.Enums;

namespace RPS.Interfaces
{
    public interface IMenuResponder
    {
        MenuChoices GetMenuChoice();
    }
}
