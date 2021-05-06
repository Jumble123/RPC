using System;
using System.Collections.Generic;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class MenuResponder : IMenuResponder
    {
        protected Dictionary<string, MenuChoices> _validInputs = new Dictionary<string, MenuChoices>()
        {
            { "Q", MenuChoices.Quit },
            { "1", MenuChoices.Toggle1 },
            { "2", MenuChoices.Toggle2 },
            { "G", MenuChoices.StartGame },
        };

        public MenuResponder()
        {
        }

        public MenuChoices GetMenuChoice()
        {
            do
            {
                var key = Console.ReadKey(true);
                if (_validInputs.TryGetValue(key.KeyChar.ToString().ToUpper(), out MenuChoices value))
                {
                    return value;
                }
            } while (true);
        }        
    }
}
