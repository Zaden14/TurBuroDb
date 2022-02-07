using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace TurBuroDb
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BaseDB.DB = new Entities3();
            FrameClass.mainFrame = FrmMain;  // инициализация Frame из разметки
            FrameClass.mainFrame.Navigate(new First());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new Reg());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new Auto());
        }

        private void Time_Click(object sender, RoutedEventArgs e)
        {
            //FrameClass.mainFrame.Navigate(new Admin());
        }

        private void rekl_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new Reklama());
        }
    }
}
