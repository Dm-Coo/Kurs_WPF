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
        readonly Func<string, string, bool, bool, string> cryptography = TextCryptor.Crypting;
        readonly Func<string, string> register = TextCryptor.ToSentenceRegister;
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
            Open();
        }

        private void EncryptToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Передаем текст из верхнего поля, ключ, указание шифровать и состояние Оставить буквы в верхнем регистре
                DecryptTextBox.Text = cryptography?.Invoke(EncryptTextBox.Text, KeyTextBox.Text, true, (bool)UpperInDecryptCheckBox.IsChecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить шифрование\r\n" + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void DecryptToolBarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Передаем текст из нижнего поля, ключ, указание шифровать и состояние Оставить буквы в верхнем регистре
                // Если указано Сделать буквы как в предложении, запускаем дополнительный делегат
                if ((bool)AsSentenceCheckBox.IsChecked)
                {
                    EncryptTextBox.Text = register?.Invoke(cryptography?.Invoke(DecryptTextBox.Text, KeyTextBox.Text, false, (bool)UpperInDecryptCheckBox.IsChecked));
                }
                else { EncryptTextBox.Text = cryptography?.Invoke(DecryptTextBox.Text, KeyTextBox.Text, false, (bool)UpperInDecryptCheckBox.IsChecked); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить расшифровку\r\n" + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
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
            try
            {
                // Определяем из какого TextBox вставлять
                TextBox textBoxCurrent = TextBoxDefining();

                // Открываем диалог
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // Указываем доступные типы файлов
                saveFileDialog.Filter = "Текстовые файлы (*.txt;*.docx)|*.txt;*.docx|Текстовый файл (*.txt)|*.txt|Документ Word (*.docx)|*.docx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string path = saveFileDialog.FileName;
                    // Определяем, из какой формы экспортировать в зависимости от текущего выбранной формы или выбранной кнопки
                    new SaveText().textSaver?.Invoke(textBoxCurrent.Text, path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось экспортировать файл\r\n" + ex.Message, "Ошибка", MessageBoxButton.OK);
            }

        }
        private void Execute()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить действие\r\n" + ex.Message, "Ошибка", MessageBoxButton.OK);
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

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }
        private void Open()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть файл\r\n" + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
