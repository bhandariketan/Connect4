using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Connect4Master.ConnectLogic
{
    class GameManager
    {

       
        readonly List<string> buttonsNum;

        public GameManager()
        {
            string[] input = { "Bu1", "Bu2", "Bu3", "Bu4", "Bu5", "Bu6", "Bu7" };
            buttonsNum = new List<string>(input);
        }

        
        public Tuple<bool, int, int[,] ,  bool, bool> PlayerTurn(bool Player1turn, int playerMove, bool placed,  int moves, int touch, int[,] board, bool p1win, bool p2win)
        {
           
            int turn = 0;

            if ( moves < 49 && touch != -1)
            {
                
                turn = Player1turn != true ? 2 : 1;

                Player1turn = !Player1turn;
                playerMove = touch;
                playerMove = playerMove - 1;

                placed = false;
                for (int i = 6; placed == false && i >= 0; i--)
                {
                    if (board[i, playerMove] == 0)
                    {
                        board[i, playerMove] = turn;
                        placed = true;
                        moves++;

                        if (turn == 1)
                        {
                            p1win = WinCheck(board, playerMove, i, turn);
                        }
                        else
                        {
                            p2win = WinCheck(board, playerMove, i, turn);
                        }                       
                    }
                }
            }

            return Tuple.Create(Player1turn, moves, board, p1win, p2win);
        }
        

        
        public int CheckButton (Border gametile)
        {
            int i = 1;
            foreach (var button in buttonsNum)
            {
                if (gametile.Name == button)
                {
                   
                    return i;
                }
                i++;
                
            }
            return -1;
          
        }

       
        public bool WinCheck(int[,] theBoard, int column, int row, int x)
        {
            bool win = false;
            if (row < 4)
            {
                if (theBoard[row + 3, column] == x && theBoard[row + 2, column] == x && theBoard[row + 1, column] == x && theBoard[row, column] == x)
                {
                    win = true;
                }
                if (row > 0)
                {
                    if (theBoard[row + 2, column] == x && theBoard[row + 1, column] == x && theBoard[row + 0, column] == x && theBoard[row - 1, column] == x)
                    {
                        win = true;
                    }
                }
                if (row > 1)
                {
                    if (theBoard[row + 1, column] == x && theBoard[row + 0, column] == x && theBoard[row - 1, column] == x && theBoard[row - 2, column] == x)
                    {
                        win = true;
                    }
                }
                if (row > 2)
                {
                    if (theBoard[row, column] == x && theBoard[row - 1, column] == x && theBoard[row - 2, column] == x && theBoard[row - 3, column] == x)
                    {
                        win = true;
                    }
                }
            }
            if (column < 4)
            {
                if (theBoard[row, column + 1] == x && theBoard[row, column + 2] == x && theBoard[row, column + 3] == x)
                {
                    win = true;
                }
            }
            if (column < 5 && column > 0)
            {
                if (theBoard[row, column - 1] == x && theBoard[row, column + 1] == x && theBoard[row, column + 2] == x)
                {
                    win = true;
                }
            }
            if (column > 1 && column < 6)
            {
                if (theBoard[row, column - 2] == x && theBoard[row, column - 1] == x && theBoard[row, column + 1] == x)
                {
                    win = true;
                }
            }
            if (column > 2)
            {
                if (theBoard[row, column - 3] == x && theBoard[row, column - 2] == x && theBoard[row, column - 1] == x)
                {
                    win = true;
                }
            }
            if (column > 2 && row < 4)
            {
                if (theBoard[row + 1, column - 1] == x && theBoard[row + 2, column - 2] == x && theBoard[row + 3, column - 3] == x)
                {
                    win = true;
                }
            }
            if (column < 4 && row > 2)
            {
                if (theBoard[row - 1, column + 1] == x && theBoard[row - 2, column + 2] == x && theBoard[row - 3, column + 3] == x)
                {
                    win = true;
                }
            }
            if (column < 6 && row > 0 && row < 5 && column > 1)
            {
                if (theBoard[row - 1, column + 1] == x && theBoard[row + 1, column - 1] == x && theBoard[row + 2, column - 2] == x)
                {
                    win = true;
                }
            }
            if (row < 6 && column > 0 && row > 1 && column < 5)
            {
                if (theBoard[row + 1, column - 1] == x && theBoard[row - 1, column + 1] == x && theBoard[row - 2, column + 2] == x)
                {
                    win = true;
                }
            }
            if (column < 4 && row < 4)
            {
                if (theBoard[row + 1, column + 1] == x && theBoard[row + 2, column + 2] == x && theBoard[row + 3, column + 3] == x)
                {
                    win = true;
                }
            }
            if (column > 2 && row > 2)
            {
                if (theBoard[row - 1, column - 1] == x && theBoard[row - 2, column - 2] == x && theBoard[row - 3, column - 3] == x)
                {
                    win = true;
                }
            }
            if (column > 0 && row > 0 && column < 5 && row < 5)
            {
                if (theBoard[row - 1, column - 1] == x && theBoard[row + 1, column + 1] == x && theBoard[row + 2, column + 2] == x)
                {
                    win = true;
                }
            }
            if (column > 1 && row > 1 && column < 6 && row < 6)
            {
                if (theBoard[row + 1, column + 1] == x && theBoard[row - 1, column - 1] == x && theBoard[row - 2, column - 2] == x)
                {
                    win = true;
                }
            }
            return win;
        }
    }
}
