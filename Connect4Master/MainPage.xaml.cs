using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Connect4Master.ConnectLogic;




namespace Connect4Master
{

    public sealed partial class MainPage : Page
    {

        public static int[,] board = new int[7, 7];

        public static Border[,] boarders = new Border[7, 7];

        public static int moves = 0;

        public static bool p1win = false;
        public static bool p2win = false;


        public static int playerMove;


        public static bool placed = false;


        public static bool Player1turn = true;


        public int p1Score = 0;
        public int p2Score = 0;


        GameManager newRound = new GameManager();


        SolidColorBrush colourGray = new SolidColorBrush(Windows.UI.Colors.LightGray);
        SolidColorBrush colourBlue = new SolidColorBrush(Windows.UI.Colors.CornflowerBlue);
        SolidColorBrush colourRed = new SolidColorBrush(Windows.UI.Colors.IndianRed);

        public MainPage()
        {
            this.InitializeComponent();


            for (int x = 0; x < 7; x++)
            {
                ColumnDefinition col1 = new ColumnDefinition();
                RowDefinition row = new RowDefinition();

                myGrid.ColumnDefinitions.Add(col1);
                myGrid.RowDefinitions.Add(row);
            }


            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    board[x, y] = 0;
                }
            }


            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {



                    Border border = new Border();
                    double thickness = 1;
                    border.BorderThickness = new Thickness(thickness);
                    border.HorizontalAlignment = HorizontalAlignment.Stretch;
                    border.VerticalAlignment = VerticalAlignment.Stretch;
                    border.Background = colourGray;
                    boarders[x, y] = border;


                    myGrid.Children.Add(boarders[x, y]);
                }
            }


            playerTurn.Background = colourBlue;


            PrintBoard(board);
        }


        private void Play_Tapped(object sender, TappedRoutedEventArgs e)
        {

            Border data = sender as Border;


            playerTurn.Background = Player1turn != true ? colourBlue : colourRed;


            int touch = newRound.CheckButton(data);


            var gameData = newRound.PlayerTurn(Player1turn, playerMove, placed, moves, touch, board, p1win, p2win);


            Player1turn = gameData.Item1;
            moves = gameData.Item2;
            board = gameData.Item3;


            PrintBoard(board);


            p1win = gameData.Item4;
            p2win = gameData.Item5;


            if (p1win == true)
            {
                PrintSpecific("Player 1 wins a point");
                p1Score++;
            }
            else if (p2win == true)
            {
                PrintSpecific("Player 2 wins point");
                p2Score++;
            }
            else if (p1win == false && p2win == false && moves == 49)
            {
                PrintSpecific("Match complete \nPlayer 1 has: " + p1Score.ToString() + " points. \nPlayer 2 has: " + p2Score.ToString() + " points.");
            }


            p1win = false;
            p2win = false;
        }



        public void PrintBoard(int[,] theBoard)
        {

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (theBoard[x, y] == 0)
                    {
                        ColourGrid(x, y, colourGray);
                    }
                    else if (theBoard[x, y] == 1)
                    {
                        ColourGrid(x, y, colourBlue);
                    }
                    else if (theBoard[x, y] == 2)
                    {
                        ColourGrid(x, y, colourRed);
                    }
                }
            }
        }


        public void ColourGrid(int x, int y, SolidColorBrush colour)
        {
            boarders[x, y].Background = colour;
            Grid.SetRow(boarders[x, y], x);
            Grid.SetColumn(boarders[x, y], y);
        }


        private async void PrintSpecific(string x)
        {
            ContentDialog printSpecific = new ContentDialog()
            {
                Content = x,
                CloseButtonText = "Ok"
            };
            await printSpecific.ShowAsync();
        }


        private void CheckScore_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border data = sender as Border;
            switch (data.Name)
            {
                case "player1":
                    PrintSpecific("Player 1 has: " + p1Score.ToString() + " points.");
                    break;

                case "player2":
                    PrintSpecific("Player 2 has: " + p2Score.ToString() + " points.");
                    break;

                default: break;
            }
        }
    }


}
    


