using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_WPF
{
    class TextCryptor
    {
        public static string Crypting(string text, string key, bool operation, bool register)
        {
            // Проверяем на null/пустую строку
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            {
                return text;
            }
            // Определяем алфавит
            string abc = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string textNew = "";
            int j = 0;
            // Перебираем символы в исходном тексте
            for (int i = 0; i < text.Length; i++)
            {
                // Проверка символа на принадлежность буквам и алфавиту
                if (Char.IsLetter(text[i]) && abc.Contains(Char.ToLower(text[i])))
                {
                    // Задание исходному сиволу индексов в тексте и алфавите
                    int n = abc.IndexOf(Char.ToLower(text[i]));
                    int n1 = abc.IndexOf(key[j]);
                    if (n1 == -1) { n1 = 0; }
                    // Если выбрано шифрование - true
                    if (operation)
                    {
                        // Перемещение отсчета в 0, если индекс превышает границы алфавита
                        if (n + n1 > 32) { n = n + n1 - 33; }
                        else { n += n1; }
                    }
                    else
                    {
                        // Перемещение отсчета в 0, если индекс ниже границы алфавита
                        if (n - n1 < 0) { n = n - n1 + 33; }
                        else { n -= n1; }
                    }
                    // Перемещение отсчета в 0, если индекс превышает границы ключа
                    if (j + 1 >= key.Length) { j = 0; }
                    else { j++; }
                    // Добавление символа к новой строке, если выбрано сохранять регистр - символ будет заглавным, если был таким изначально
                    if (register && Char.IsUpper(text[i])) { textNew += Char.ToUpper(abc[n]); }
                    else { textNew += abc[n]; }
                }
                else { textNew += text[i]; }
            }
            return textNew;
        }
        public static string ToSentenceRegister(string text)
        {
            // Проверяем на null/пустую строку
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            // Определяем лист для строк
            List<char> list = new List<char>();
            // Определяем знаки, после которых буква - заглавная
            string punctuations = ".?!";
            // Разделяем текст на строки
            string[] newLineArray = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            // Перебираем строки в новом массиве
            foreach (var item in newLineArray)
            {
                bool check = true;
                for (int i = 0; i < item.Length; i++)
                {
                    // Если символ - знак препинания и содержится в списке, добавляем его в строку и ставим необходимость следующую букву сделать заглавной
                    if (!Char.IsLetterOrDigit(item[i]) && punctuations.Contains(item[i]))
                    {
                        check = true;
                        list.Add(item[i]);
                        continue;
                    }
                    // Если символ не буква или нет необходимости в заглавной букве, добавляем его в строку
                    if (!Char.IsLetter(item[i]) || check == false)
                    {
                        list.Add(item[i]);
                        continue;
                    }
                    // Отключаем необходимость в заглавной букве и добавляем заглавный символ в строку
                    check = false;
                    list.Add(Char.ToUpper(item[i]));
                }
                list.Add('\r');
                list.Add('\n');
            }
            // Удаляем последний перенос строки
            list.RemoveRange(list.Count - 2, 2);
            string temp = "";
            list.ForEach(x => temp += x);
            return temp;
        }
    }
}
