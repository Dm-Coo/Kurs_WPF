using Microsoft.Win32;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kurs_WPF
{
    class SaveText
    {
        public delegate void TextSaver(TextBox textBoxCurrent);
        public TextSaver textSaver = TextSaveing;
        private static void TextSaveing(TextBox textBoxCurrent)
        {
            // Открываем диалог
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Указываем доступные типы файлов
            saveFileDialog.Filter = "Текстовые файлы (*.txt;*.docx)|*.txt;*.docx|Текстовый файл (*.txt)|*.txt|Документ Word (*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Если расширение файла .txt читаем файл в форму
                if (System.IO.Path.GetExtension(saveFileDialog.FileName) == ".txt")
                {
                    File.WriteAllText(saveFileDialog.FileName, textBoxCurrent.Text);
                }
                // Если расширение файла .docx читаем файл в форму
                else if (System.IO.Path.GetExtension(saveFileDialog.FileName) == ".docx")
                {
                    // Разделяем текст на строки
                    string[] newLineArray = textBoxCurrent.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    XWPFDocument doc = new XWPFDocument();
                    // Перебираем строки в новом массиве и добавляем текст в параграфы
                    foreach (var item in newLineArray)
                    {
                        doc.CreateParagraph().CreateRun().SetText(item);
                    }
                    // Записываем файл через поток
                    using (FileStream fs = File.Create(saveFileDialog.FileName))
                    {
                        doc.Write(fs);
                    }
                }
            }
        }
    }
}
