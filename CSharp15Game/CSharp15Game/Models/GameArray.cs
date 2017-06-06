using System;
using System.Collections;

namespace CSharp15Game.Models
{
    class GameArray
    {
        private readonly int constFieldWidth;
        private readonly int constFieldHeight;
        private int[,] theArray;

        //empty space position
        private int zeroCol;
        private int zeroRow;

        public int this[int x, int y]
        {
            get
            {
                return theArray[x, y];
            }
        }

        public GameArray(int constFieldHeight, int constFieldWidth)
        {
            this.constFieldHeight = constFieldHeight;
            this.constFieldWidth = constFieldWidth;
            theArray = new int[constFieldHeight, constFieldWidth];
            Randomize();
        }

        public void Randomize()
        {
            #region Filling a stack with randoms
            Stack stack = new Stack();
            Random rnd = new Random();
            int possibleValues = constFieldHeight * constFieldWidth;
            while (stack.Count < possibleValues)
            {
                int someRandom = rnd.Next(0, possibleValues);
                if (stack.Contains(someRandom))
                {
                    continue;
                }
                else
                {
                    stack.Push(someRandom);
                }
            };
            #endregion

            #region Transferring values to 2D array
            for (int i = 0; i < constFieldHeight; i++)
            {
                for (int j = 0; j < constFieldWidth; j++)
                {
                    theArray[i, j] = (int)stack.Pop();
                    if (theArray[i, j] == 0)
                    {
                        zeroRow = i;
                        zeroCol = j;
                    }
                }
            } 
            #endregion
        }

        public void TryToMoveDib(int selectedDibColumn, int selectedDibRow)
        {
            // must not be farther than 1 cell from Zero
            int deltax = Math.Abs(selectedDibColumn - zeroCol);
            int deltay = Math.Abs(selectedDibRow - zeroRow);
            if (deltax + deltay > 1) return;

            theArray[zeroRow, zeroCol] = theArray[selectedDibRow, selectedDibColumn];
            theArray[selectedDibRow, selectedDibColumn] = 0;
            zeroCol = selectedDibColumn;
            zeroRow = selectedDibRow;
        }
    }
}
