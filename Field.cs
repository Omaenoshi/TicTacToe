using System;

namespace Dz5
{
    class Field
    {
        public int CountMove { get; set; }
        public char[,] rememberedMove { get; set; }
        private readonly char[,] frame;

        public Field()
        {
            CountMove = 9;
            frame = new char[,]
            {
                {'┌','─','┬','─','┬','─','┐' },
                {'│',' ','│',' ','│',' ','│' },
                {'├','─','┼','─','┼','─','┤' },
                {'│',' ','│',' ','│',' ','│' },
                {'├','─','┼','─','┼','─','┤' },
                {'│',' ','│',' ','│',' ','│' },
                {'└','─','┴','─','┴','─','┘' }
            };
            rememberedMove = new char[,]
            {
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
            };
        }

        public void DrawFrame()
        {
            for (int y = 0; y < frame.GetLength(0); y++)
            {
                for (int x = 0; x < frame.GetLength(1); x++)
                {
                    char element = frame[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.Write(element);
                }
            }
        }

        public void AddMove(Player currentPlayer)
        {
            frame[currentPlayer.Y, currentPlayer.X] = currentPlayer.Sign;
            rememberedMove[currentPlayer.SpecialY, currentPlayer.SpecialX] = currentPlayer.Sign;
            CountMove--;
        }

        public bool CanAddMove(Player currentPlayer)
        {
            return frame[currentPlayer.Y, currentPlayer.X] == ' ';
        }

        public bool IsPositionWalkable(int X, int Y)
        {
            return X > 0 && X < 6 && Y > 0 && Y < 6;
        }

        public bool CheckLanes(Player currentPlayer)
        {
            bool cols;
            bool rows;
            for ( var x = 0; x < rememberedMove.GetLength(0); x++)
            {
                cols = true;
                rows = true;
                for (var y = 0; y < rememberedMove.GetLength(1); y++)
                {
                    cols = cols && rememberedMove[x, y] == currentPlayer.Sign;
                    rows = rows && rememberedMove[y, x] == currentPlayer.Sign;
                }

                if (cols || rows)
                    return true;
            }

            return false;
        }

        public bool CheckDiagonals(Player currentPlayer)
        {
            bool toright = true;
            bool toleft = true;

            for (var x = 0; x < rememberedMove.GetLength(0); x++)
            {
                toright = toright && rememberedMove[x, x] == currentPlayer.Sign;
                toleft = toleft && rememberedMove[3 - x - 1, x] == currentPlayer.Sign;
            }

            if (toleft || toright)
                return true;

            return false;
        }
    }
}
