using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz5
{
    class Player
    {
        public string SignName { get; set; }
        public char Sign { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int SpecialX { get; set; }
        public int SpecialY { get; set; }
        private ConsoleColor color;
        
        public Player(string signName, char sign)
        {
            SignName = signName;
            Sign = sign;
            X = 3;
            Y = 3;
            SpecialX = 1;
            SpecialY = 1;
            color = ConsoleColor.Red;
        }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = color;
            Console.Write(Sign);
            Console.ResetColor();
        }
    }
}
