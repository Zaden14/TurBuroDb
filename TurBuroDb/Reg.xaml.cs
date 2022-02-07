using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            string passCheck = TBPassword.Password.ToString();

            if (passCheck.Length < 8) { MessageBox.Show("Длина пароля - минимум восемь символов, повторите ввод", "Пароль"); return; }
            Regex LAT = new Regex("(?=[A-Z])");
            bool LATmatch = LAT.IsMatch(passCheck);
            if (LATmatch != true) { MessageBox.Show("В пароле должна быть минимум одна заглавная латинская буква, повторите ввод", "Пароль"); return; }
            Regex lat = new Regex("(?=[a-z])");
            MatchCollection latMC = lat.Matches(passCheck);
            if (latMC.Count < 3) { MessageBox.Show("Количество строчных латинских букв в пароле должно быть не меньше трех, повторите ввод", "Пароль"); return; }
            Regex cif = new Regex("(?=[0-9])");
            MatchCollection cifMC = cif.Matches(passCheck);
            if (cifMC.Count < 2) { MessageBox.Show("Количество цифр в пароле должно быть не меньше двух, повторите ввод", "Пароль"); return; }
            Regex spec = new Regex("(?=[#?!@$%^&*-])");
            bool specMatch = spec.IsMatch(passCheck);
            if (specMatch != true) { MessageBox.Show("В пароле должен быть минимум один специальный символ (#?!@$%^&*-), повторите ввод", "Пароль"); return; }

            string pol = "м";
            if (rbMan.IsChecked == true)
            {
                pol = "м";
            }
            if (rbWoman.IsChecked == true)
            {
                pol = "ж";
            }
            int pasCode = TBPassword.Password.GetHashCode();
            Пользователь UserRg = new Пользователь() { Имя = TBName.Text, Фамилия = TBFam.Text, Логин = TBLogin.Text, Пароль = pasCode, Пол = pol, КодРоли = 1, КодДолжности=1 };
            BaseDB.DB.Пользователь.Add(UserRg);
            BaseDB.DB.SaveChanges();
            MessageBox.Show("Регистрация успешна!", "Регистрация");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new First());
        }
    }
}
