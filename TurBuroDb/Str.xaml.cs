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
    /// Логика взаимодействия для Str.xaml
    /// </summary>
    public partial class Str : Page
    {
        Тур tyr1 = new Тур();
        int i=0;
        public Str()
        {
            InitializeComponent();
            CBStrana.ItemsSource = BaseDB.DB.Страны.ToList();
            CBStrana.SelectedValuePath = "КодСтраны";
            CBStrana.DisplayMemberPath = "Страна";
            CBVid.ItemsSource = BaseDB.DB.ВидТура.ToList();
            CBVid.SelectedValuePath = "КодВидТура";
            CBVid.DisplayMemberPath = "ВидТура1";
            CBPit.ItemsSource = BaseDB.DB.Питание.ToList();
            CBPit.SelectedValuePath = "КодПитания";
            CBPit.DisplayMemberPath = "ВидПитания";
            CBProj.ItemsSource = BaseDB.DB.Проживание.ToList();
            CBProj.SelectedValuePath = "КодПроживания";
            CBProj.DisplayMemberPath = "ВидПроживания";
            CBKL.ItemsSource = BaseDB.DB.ИнформацияКлиента.ToList();
            CBKL.SelectedValuePath = "КодКлиента";
            CBKL.DisplayMemberPath = "КодКлиента";
        }
        public Str(Тур Tyr)
        {
            InitializeComponent();
            tyr1 = Tyr;
            TBName.Text = Tyr.Название;
            TBCena.Text = Tyr.Цена.ToString();

            CBStrana.ItemsSource = BaseDB.DB.Страны.ToList();
            CBStrana.SelectedValuePath = "КодСтраны";
            CBStrana.DisplayMemberPath = "Страна";
            CBVid.ItemsSource = BaseDB.DB.ВидТура.ToList();
            CBVid.SelectedValuePath = "КодВидТура";
            CBVid.DisplayMemberPath = "ВидТура1";
            CBPit.ItemsSource = BaseDB.DB.Питание.ToList();
            CBPit.SelectedValuePath = "КодПитания";
            CBPit.DisplayMemberPath = "ВидПитания";
            CBProj.ItemsSource = BaseDB.DB.Проживание.ToList();
            CBProj.SelectedValuePath = "КодПроживания";
            CBProj.DisplayMemberPath = "ВидПроживания";
            CBKL.ItemsSource = BaseDB.DB.ИнформацияКлиента.ToList();
            CBKL.SelectedValuePath = "КодКлиента";
            CBKL.DisplayMemberPath = "КодКлиента";
         }

        public void BAdmin_Click(object sender, RoutedEventArgs e)
        {
          //  FrameClass.mainFrame.Navigate(new Admin());
        }

        public void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tyr1.Название = TBName.Text;
                tyr1.Цена = Int32.Parse(TBCena.Text);
                tyr1.КодСтраны = CBStrana.SelectedIndex + 1;
                tyr1.КодВидТура = CBVid.SelectedIndex + 1;
                tyr1.КодПитания = CBPit.SelectedIndex + 1;
                tyr1.КодПроживания = CBProj.SelectedIndex + 1;
                tyr1.КодКлиента = CBKL.SelectedIndex + 1;
                BaseDB.DB.Тур.Add(tyr1);
                BaseDB.DB.SaveChanges();
                MessageBox.Show("Тур добавлен!");
            }
            catch
            {
                MessageBox.Show("Ошибка! Проверти ввод.");
            }
        }
    }
}
