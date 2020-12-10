using Microsoft.Win32;
using NPOI.XWPF.UserModel;
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

namespace Kurs_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Func<string, string, bool, bool, string> cryptography = TextCryptor.Crypting;
        Func<string, string> register = TextCryptor.ToSentenceRegister;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            // Если выбрана кнопка Шифровать, передаем текст из верхнего поля, ключ, указание шифровать и состояние Оставить буквы в верхнем регистре
            if ((bool)EncryptRadioButton.IsChecked)
            {
                DecryptTextBox.Text = cryptography?.Invoke(EncryptTextBox.Text, KeyTextBox.Text, true, (bool)UpperInDecryptCheckBox.IsChecked);
            }
            else 
            {
                // Если выбрана кнопка Расшифровать, передаем текст из нижнего поля, ключ, указание шифровать и состояние Оставить буквы в верхнем регистре
                // Если указано Сделать буквы как в предложении, запускаем дополнительный делегат
                if ((bool)AsSentenceCheckBox.IsChecked)
                {
                    EncryptTextBox.Text = register?.Invoke(cryptography?.Invoke(DecryptTextBox.Text, KeyTextBox.Text, false, (bool)UpperInDecryptCheckBox.IsChecked));
                }
                else { EncryptTextBox.Text = cryptography?.Invoke(DecryptTextBox.Text, KeyTextBox.Text, false, (bool)UpperInDecryptCheckBox.IsChecked); }
            }
        }

        private void LoadToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Определяем, в какую форму вставлять в зависимости от выбранной кнопки
            TextBox textBoxCurrent;
            if (EncryptTextBox.IsSelectionActive || DecryptTextBox.IsSelectionActive)
            {
                textBoxCurrent = EncryptTextBox.IsSelectionActive ? EncryptTextBox : DecryptTextBox;
            }
            else { textBoxCurrent = (bool)EncryptRadioButton.IsChecked ? EncryptTextBox : DecryptTextBox; }
            new OpenText().textOpener?.Invoke(textBoxCurrent);
        }

        private void EncryptToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаем текст из верхнего поля, ключ, указание шифровать и состояние Оставить буквы в верхнем регистре
            DecryptTextBox.Text = cryptography?.Invoke(EncryptTextBox.Text, KeyTextBox.Text, true, (bool)UpperInDecryptCheckBox.IsChecked);
        }

        private void DecryptToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаем текст из нижнего поля, ключ, указание шифровать и состояние Оставить буквы в верхнем регистре
            // Если указано Сделать буквы как в предложении, запускаем дополнительный делегат
            if ((bool)AsSentenceCheckBox.IsChecked)
            {
                EncryptTextBox.Text = register?.Invoke(cryptography?.Invoke(DecryptTextBox.Text, KeyTextBox.Text, false, (bool)UpperInDecryptCheckBox.IsChecked));
            }
            else { EncryptTextBox.Text = cryptography?.Invoke(DecryptTextBox.Text, KeyTextBox.Text, false, (bool)UpperInDecryptCheckBox.IsChecked); }
        }
    }
}
