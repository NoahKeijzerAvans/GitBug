using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Position
    {
        public int Left;
        public int Top;

        public Position()
        {
        }

        public Position(int cursorLeft, int cursorTop)
        {
            Left = cursorLeft;
            Top = cursorTop;
        }
    }
}
