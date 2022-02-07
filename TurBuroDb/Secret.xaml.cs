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
using System.IO;

namespace TurBuroDb
{
    /// <summary>
    /// Логика взаимодействия для Secret.xaml
    /// </summary>
    public partial class Secret : Page
    {
        List<Base> Search;
        List<Base> Karr = new List<Base>();
        public Secret()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Base.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Arr = sr.ReadLine().Split(';');
                    Karr.Add(new Base() { Фамилия = Arr[0], Имя = Arr[1], Отчество = Arr[2], Пол = Arr[3] });
                }
                table.ItemsSource = Karr;
                Cbf.IsChecked = true;
                Cbi.IsChecked = true;
                Cbo.IsChecked = true;
                Cbg.IsChecked = true;
            }
        }

        private void FamilCheck_Checked(object sender, RoutedEventArgs e)
        {
            Cbf.Visibility = Visibility.Visible;
        }

        private void ImiCheck_Checked(object sender, RoutedEventArgs e)
        {
            Cbi.Visibility = Visibility.Visible;
        }

        private void OtCheck_Checked(object sender, RoutedEventArgs e)
        {
            Cbo.Visibility = Visibility.Visible;
        }

        private void GenderCheck_Checked(object sender, RoutedEventArgs e)
        {
            Cbg.Visibility = Visibility.Visible;
        }

        private void ButNaiti_Click(object sender, RoutedEventArgs e)
        {
            Search = new List<Base>();
            if (Radio_FIo.IsChecked == true)
            {
                for (int i = 0; i < Karr.Count; i++)
                {
                    if (TBPoisk.Text == Karr[i].Имя)
                    {
                        Base search = new Base
                        {
                            Фамилия = Karr[i].Фамилия,
                            Имя = Karr[i].Имя,
                            Отчество = Karr[i].Отчество,
                            Пол = Karr[i].Пол,

                        };
                        Search.Add(search);
                    }
                }
            }
            try
            {
                table.ItemsSource = Search;
            }
            catch
            {
                MessageBox.Show("Повторите вход ввод", "Не найдено!");
            }
            if (Radio_Pol.IsChecked == true)
            {
                for (int i = 0; i < Karr.Count; i++)
                {
                    if (TBPoisk.Text == Karr[i].Пол)
                    {
                        Base search = new Base
                        {
                            Фамилия = Karr[i].Фамилия,
                            Имя = Karr[i].Имя,
                            Отчество = Karr[i].Отчество,
                            Пол = Karr[i].Пол,
                           

                        };
                        Search.Add(search);
                    }
                }
            }
            try
            {
                table.ItemsSource = Search;
            }
            catch
            {
                MessageBox.Show("Повторите ввод", "Не найдено!");
            }
        }
    }
}
