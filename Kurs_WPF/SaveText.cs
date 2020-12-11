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
    public class SaveText
    {
        public delegate void TextSaver(string text, string path);
        public TextSaver textSaver = TextSaveing;
        private static void TextSaveing(string text, string path)
        {
                // Если расширение файла .txt читаем файл в форму
                if (System.IO.Path.GetExtension(path) == ".txt")
                {
                    File.WriteAllText(path, text);
                }
                // Если расширение файла .docx читаем файл в форму
                else if (System.IO.Path.GetExtension(path) == ".docx")
                {
                    // Разделяем текст на строки
                    string[] newLineArray = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    XWPFDocument doc = new XWPFDocument();
                    // Перебираем строки в новом массиве и добавляем текст в параграфы
                    foreach (var item in newLineArray)
                    {
                        doc.CreateParagraph().CreateRun().SetText(item);
                    }
                    // Записываем файл через поток
                    using (FileStream fs = File.Create(path))
                    {
                        doc.Write(fs);
                    }
                }
            
        }
    }
}
