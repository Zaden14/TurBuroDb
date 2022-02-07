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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurBuroDb
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private Пользователь _user;
        public Admin(Пользователь пользователь)
        {
           
            InitializeComponent();
            FrameClass.dopFrame = FrmList;
            _user = пользователь;

        }

        private void ProsmotrTyr_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.dopFrame.Navigate(new Prosmotr());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.dopFrame.Navigate(new MainWindow());
        }

        private void ProsmotrUs_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.dopFrame.Navigate(new Tyr());
        }

        private void Redaktor_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.dopFrame.Navigate(new Str());
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.dopFrame.Navigate(new UserPage( _user));
        }
    }
}
