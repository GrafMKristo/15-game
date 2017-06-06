using System.Windows;
using CSharp15Game.Models;

namespace CSharp15Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int constFieldWidth = 3;
        private static readonly int constFieldHeight = 3;

        GameArray fieldArray;
        FieldViewModel fieldArrayViewModel;

        public MainWindow()
        {
            InitializeComponent();
            fieldArray = new GameArray(constFieldHeight, constFieldWidth);
            fieldArrayViewModel = new FieldViewModel(constFieldHeight, constFieldWidth, fieldMain, fieldArray);
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            fieldArray.Randomize();
            fieldArrayViewModel.ArrangeDibs();
        }
    }
}
