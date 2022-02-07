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
using System.Windows.Media.Animation;

namespace TurBuroDb
{
    /// <summary>
    /// Логика взаимодействия для Reklama.xaml
    /// </summary>
    public partial class Reklama : Page
    {
        public Reklama()
        {
            InitializeComponent();
        }

        private void BRekl_Click(object sender, RoutedEventArgs e)
        {

            DoubleAnimation WA = new DoubleAnimation(); // создание объекта для настройки анимации
            WA.From = 100; // начальное значение свойства
            WA.To = 300; // конечное значение свойства
            WA.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            BRekl.BeginAnimation(WidthProperty, WA); // «навешивание» анимации на свойство ширины кнопки

            DoubleAnimation FSA = new DoubleAnimation();
            FSA.From = 10;
            FSA.To = 100;
            FSA.Duration = TimeSpan.FromSeconds(2);
            FSA.RepeatBehavior = RepeatBehavior.Forever;
            FSA.AutoReverse = true;
            TBRekl.BeginAnimation(FontSizeProperty, FSA);

            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ
            MA.From = new Thickness(100, 100, 100, 100);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(2);
            MA.AutoReverse = true;
            TBRekl.BeginAnimation(MarginProperty, MA);

            BRekl.Background = new SolidColorBrush();
            ColorAnimation BA = new ColorAnimation();
            Color Cstart = Color.FromRgb(255, 0, 0); // присваивание начального цвета эл-ту
            TBRekl.Background = new SolidColorBrush(Cstart);
            BA.From = Cstart;
            BA.To = Color.FromRgb(0, 255, 0);
            BA.Duration = TimeSpan.FromSeconds(5);
            BA.RepeatBehavior = RepeatBehavior.Forever;
            BA.AutoReverse = true;
            BRekl.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);

        }
    }
}
