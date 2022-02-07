using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private Пользователь _user=new Пользователь();
        private string _path;
        private Фото UP;
        public UserPage(Пользователь пользователи)
        {
            InitializeComponent();
            _user = пользователи;
            TBUserName.Text = _user.Имя;
            TBUserSurname.Text = _user.Фамилия;
            if (пользователи.Фото != null && пользователи.Фото.ФотоБинар != null)
            {
                byte[] BArr = пользователи.Фото.ФотоБинар;  // считываем изображение из базы (считываем байтовый массив двоичных данных)
                BitmapImage BI = new BitmapImage();  // создаем объект для загрузки изображения
                using (MemoryStream MS = new MemoryStream(BArr))  // для считывания байтового потока
                {
                    BI.BeginInit();  // начинаем считывание
                    BI.StreamSource = MS;  // задаем источник потока
                    BI.CacheOption = BitmapCacheOption.OnLoad;  // переводим изображение
                    BI.EndInit();  // заканчиваем считывание
                }
                UserPhotoImage.Source = BI;  // показываем картинку на экране
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow upWin = new UpdateWindow(_user);  // создаем окно для редактирования данных
            upWin.ShowDialog();  // открываем окно
            // далее пишется код, который будет выполнятся после закрытия окна
            FrameClass.dopFrame.Navigate(new UserPage(_user));  // перезагружаем страницу
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Фото U = BaseDB.DB.Фото.FirstOrDefault(x => x.КодПользователя == _user.КодПользователя);
            if (U == null)  // если у пользователя не было изображения (то есть если объект U - пустой)
            {
                UP = new Фото();  // создаем объект для записи в базу
                UP.КодПользователя = _user.КодПользователя;  // заполняем поле с id
                OpenFileDialog OFD = new OpenFileDialog();   // создаем диалоговое окно
                OFD.ShowDialog();  // открываем диалоговое окно
                _path = OFD.FileName;   // считываем путь выбранного изображения
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(_path);  // создаем объект для загрузки изображения в базу
                ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                UP.ФотоБинар = Barray;  // загружаем массив в базу
                BaseDB.DB.Фото.Add(UP);  // добавляем созданный объект в базу
                BaseDB.DB.SaveChanges();
                MessageBox.Show("Картинка добавлена");
            }
            else  // если у пользователя уже было изображение 
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                _path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(_path);
                ImageConverter IC = new ImageConverter();
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                U.ФотоБинар = Barray;
                BaseDB.DB.SaveChanges();
                MessageBox.Show("Картинка изменена");
            }

            FrameClass.dopFrame.Navigate(new UserPage(_user));  // перезагружаем страницу
        }
    }
}
