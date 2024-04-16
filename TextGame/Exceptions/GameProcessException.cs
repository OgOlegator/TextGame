using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Exceptions
{
    public class GameProcessException : Exception
    {
        public GameProcessException(string? message) : base(message)
        {
        }
    }
}
