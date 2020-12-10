using Kurs_WPF.SimpleHelpers;
using Microsoft.Win32;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kurs_WPF
{
    class OpenText
    {
        public delegate void TextOpener(TextBox textBoxCurrent);
        public TextOpener textOpener = TextOpening;

        



        private static void TextOpening(TextBox textBoxCurrent)
        {
            // Открываем диалог
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Указываем доступные типы файлов
            openFileDialog.Filter = "Текстовые файлы (*.txt;*.docx)|*.txt;*.docx|Текстовый файл (*.txt)|*.txt|Документ Word (*.docx)|*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                // Если расширение файла .txt читаем файл в форму
                if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".txt")
                {
                    // Записываем текст в форму, проверяя кодировку текста
                    textBoxCurrent.Text = File.ReadAllText(openFileDialog.FileName, DetectingEncode.DetectingTextEncode(openFileDialog.FileName));
                }
                // Если расширение файла .docx читаем файл в форму
                else if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".docx")
                {
                    List<string> list = new List<string>();
                    string text = "";
                    // Открываем файл через поток
                    using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                    {
                        XWPFDocument doc = new XWPFDocument(fs);
                        // Перебираем параграфы
                        foreach (var item in doc.Paragraphs)
                        {
                            // Добавляем текст параграфа в лист
                            list.Add(item.ParagraphText);
                            list.Add("\r\n");
                        }
                        // Удаляем последний перенос строки
                        list.RemoveAt(list.Count - 1);
                        list.ForEach(x => text += x);
                    }
                    textBoxCurrent.Text = text;
                }
            }
        }
    }
}
