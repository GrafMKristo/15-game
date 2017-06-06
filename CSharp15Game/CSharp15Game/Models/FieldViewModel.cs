using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace CSharp15Game.Models
{
    class FieldViewModel
    {
        private readonly int constFieldWidth;
        private readonly int constFieldHeight;
        private GameArray gameArray;
        private Grid fieldMain;
        private bool isSorted = false;

        public FieldViewModel(int constFieldHeight, int constFieldWidth, Grid fieldMain, GameArray gameArray)
        {
            #region Parameters assign
            this.constFieldHeight = constFieldHeight;
            this.constFieldWidth = constFieldWidth;
            this.fieldMain = fieldMain;
            this.gameArray = gameArray;

            #endregion
            #region Adding col&rows definitions 
            for (int i = 0; i < constFieldWidth; i++)
            {
                fieldMain.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < constFieldHeight; i++)
            {
                fieldMain.RowDefinitions.Add(new RowDefinition());
            }
            #endregion

            ArrangeDibs();
        }

        public void ArrangeDibs()
        {
            fieldMain.Children.Clear();
            bool isStillSorted = true;
            for (int i = 0; i < constFieldHeight; i++)
            {
                for (int j = 0; j < constFieldWidth; j++)
                {
                    if (gameArray[i, j] == 0) continue;     //no need to draw a Zero
                    if (isStillSorted)
                    {
                        int supposedNumber = (j + 1) + constFieldWidth * i;
                        if (gameArray[i,j]!=supposedNumber)
                        {
                            isStillSorted = false;
                        }
                    }
                    Button btn = new Button();
                    Grid.SetColumn(btn, j);
                    Grid.SetRow(btn, i);
                    btn.Content = gameArray[i, j];
                    btn.Height = 50;
                    btn.Width = 50;
                    btn.Margin = new Thickness(2);
                    btn.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");
                    btn.FontSize = 20;
                    if (isStillSorted) btn.Foreground = new SolidColorBrush(Colors.Green);
                    btn.Click += Btn_Click;
                    fieldMain.Children.Add(btn);
                }
            }
            isSorted = isStillSorted;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int selectedDibNumber = Int32.Parse(((Button)sender).Content.ToString());
            int selectedDibColumn = Grid.GetColumn((Button)sender);
            int selectedDibRow = Grid.GetRow((Button)sender);
            gameArray.TryToMoveDib(selectedDibColumn, selectedDibRow);
            ArrangeDibs();
        }
    }
}