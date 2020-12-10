using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Kurs_WPF
{
    /// <summary>
    /// Логика взаимодействия для AboutCryptingMethod.xaml
    /// </summary>
    public partial class AboutCryptingMethod : Window
    {
        public AboutCryptingMethod()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ru.wikipedia.org/wiki/Шифр_Виженера");
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ru.wikipedia.org/wiki/Шифр_Цезаря");
        }
    }
}
