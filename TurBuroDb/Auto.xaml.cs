using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        List<BaseAuto> Users = new List<BaseAuto>();
        public Auto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new First());
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            int passCode = PBAutoPassword.Password.GetHashCode();
            Пользователь User = BaseDB.DB.Пользователь.FirstOrDefault(x => x.Логин == TBAutoLogin.Text && x.Пароль == passCode);
            if (User != null)
            {
                if (User.КодРоли == 1)
                {
                    MessageBox.Show("Вы вошли, как аминистратор " + User.Имя, "Авторизация", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    FrameClass.mainFrame.Navigate(new Admin(User));
                }
                else
                {
                    MessageBox.Show("Здравствуйте, " + User.Имя, "Авторизация", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    FrameClass.mainFrame.Navigate(new UserPage(User));
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден, повторите ввод или зарегистрируйтесь!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
