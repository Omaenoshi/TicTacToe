using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz5
{
    class Game
    {
        
        private Field field;
        private Player currentPlayer;
        private readonly Player[] players;


        public Game()
        {
            field = new Field();
            players = new Player[] { new Player("Нолик", 'O'), new Player("Крестик", 'X')};
            currentPlayer = players[0];
        }

        public void RunGame()
        {
            while(true)
            {
                if (IsWin())
                {
                    Console.WriteLine($"Победитель - {currentPlayer.SignName}");
                    Console.ReadKey();
                    break;
                }
                field.DrawFrame();
                currentPlayer.DrawPlayer();
                
                Move();
                Console.Clear();
                
                if (field.CountMove <= 0)
                {
                    Console.WriteLine("Ничья");
                    Console.ReadKey();
                    break;
                }
            }

        }

        private void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch(key)
            {
                case ConsoleKey.Enter:
                    if (field.CanAddMove(currentPlayer))
                    {
                        field.AddMove(currentPlayer);
                        
                        if (!IsWin())
                            ChangeCurrentPlayer();
                    } 
                    break;
                case ConsoleKey.UpArrow:
                    if (field.IsPositionWalkable(currentPlayer.X, currentPlayer.Y - 2))
                    {
                        currentPlayer.Y -= 2;
                        currentPlayer.SpecialY -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (field.IsPositionWalkable(currentPlayer.X, currentPlayer.Y + 2))
                    {
                        currentPlayer.Y += 2;
                        currentPlayer.SpecialY += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (field.IsPositionWalkable(currentPlayer.X - 2, currentPlayer.Y))
                    {
                        currentPlayer.X -= 2;
                        currentPlayer.SpecialX -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (field.IsPositionWalkable(currentPlayer.X + 2, currentPlayer.Y))
                    {
                        currentPlayer.X += 2;
                        currentPlayer.SpecialX += 1;
                    }
                    break;
            }
        }

        private void ChangeCurrentPlayer()
        {
            if (currentPlayer == players[0])
                currentPlayer = players[1];
            else
                currentPlayer = players[0];
                  
        }

        private bool IsWin()
        {
            return field.CheckLanes(currentPlayer) || field.CheckDiagonals(currentPlayer);
        }
    }
}
