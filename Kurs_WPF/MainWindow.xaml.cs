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
            Execute();
        }

        private void LoadToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Определяем в какой TextBox вставлять
            TextBox textBoxCurrent = TextBoxDefining();
            // Открываем диалог
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Указываем доступные типы файлов
            openFileDialog.Filter = "Текстовые файлы (*.txt;*.docx)|*.txt;*.docx|Текстовый файл (*.txt)|*.txt|Документ Word (*.docx)|*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                textBoxCurrent.Text = new OpenText().textOpener?.Invoke(openFileDialog.FileName);
            }
                
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

        private void ExportToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            Exporting();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Exporting();
        }
        private void Exporting()
        {
            // Определяем в какой TextBox вставлять
            TextBox textBoxCurrent = TextBoxDefining();
            // Определяем, из какой формы экспортировать в зависимости от текущего выбранной формы или выбранной кнопки
            new SaveText().textSaver?.Invoke(textBoxCurrent);
        }
        private void Execute()
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Execute();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AboutCryptingMethod aboutCryptingMethod = new AboutCryptingMethod();
            aboutCryptingMethod.Owner = this;
            aboutCryptingMethod.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }
        private TextBox TextBoxDefining()
        {
            // Определяем, в какую форму вставлять в зависимости от текущего выбранной формы или выбранной кнопки
            if (EncryptTextBox.IsSelectionActive || DecryptTextBox.IsSelectionActive)
            {
                return EncryptTextBox.IsSelectionActive ? EncryptTextBox : DecryptTextBox;
            }
            else { return (bool)EncryptRadioButton.IsChecked ? EncryptTextBox : DecryptTextBox; }
        }

    }
}
