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
using Tyr.Classes;

namespace TurBuroDb
{
    /// <summary>
    /// Логика взаимодействия для Tyr.xaml
    /// </summary>
    public partial class Tyr : Page
    {
        Service ServiceAcc = new Service();
        List<ClientService> CS = BaseDB.DB.ClientService.ToList();
        public Tyr()
        {
            InitializeComponent();
            lvLess.ItemsSource = BaseDB.DB.Тур.ToList();

        }

        public void Del_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int KodTyr = Convert.ToInt32(button.Uid);
            Тур Delete = BaseDB.DB.Тур.FirstOrDefault(x => x.КодТура == KodTyr);
            BaseDB.DB.Тур.Remove(Delete);
            BaseDB.DB.SaveChanges();
            FrameClass.mainFrame.Navigate(new Tyr());
            MessageBox.Show("Тур удалён", "Удаление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }


        public void Redaktor_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            int KodTyr = Convert.ToInt32(button.Uid);
            Тур tyr1 = BaseDB.DB.Тур.FirstOrDefault(y => y.КодТура == KodTyr);
            FrameClass.mainFrame.Navigate(new Str());
        }

        private void Zapis_Click(object sender, RoutedEventArgs e)
        {
            List<ClientService> clientServiceOld = CS.Where(x => x.ID == ServiceAcc.ID).ToList();
            if (clientServiceOld.Count != 0)
            {
                foreach (ClientService cs in clientServiceOld)
                {
                    DataBase.db.ClientService.Remove(cs);
                }
            }
            ClientService ms = new ClientService();
            ms.ServiceID = ServiceAcc.ID;
            ms.ClientID = CbUsers.SelectedIndex;
            DataBase.db.ClientService.Add(ms);

        }
    }
}
