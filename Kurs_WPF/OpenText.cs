using Kurs_WPF.SimpleHelpers;
using Microsoft.Win32;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kurs_WPF
{
    public class OpenText
    {
        public delegate string TextOpener(string FileName);
        public TextOpener textOpener = TextOpening;

        private static string TextOpening(string FileName)
        {
            // Если расширение файла .txt читаем файл в форму
            if (System.IO.Path.GetExtension(FileName) == ".txt")
            {
                // Записываем текст в форму, проверяя кодировку текста
                return File.ReadAllText(FileName, DetectingEncode.DetectingTextEncode(FileName));
            }
            // Если расширение файла .docx читаем файл в форму
            if (System.IO.Path.GetExtension(FileName) == ".docx")
            {
                List<string> list = new List<string>();
                string text = "";
                // Открываем файл через поток
                using (FileStream fs = File.OpenRead(FileName))
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
                return text;
            }
            return null;
        }
    }
}
