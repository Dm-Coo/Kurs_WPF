using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurs_WPF;
using System.IO;

namespace Kurs_WPFUnitTest
{
    [TestClass]
    public class TestExporting
    {
        [TestMethod]
        public void Exporting_Txt()
        {
            string path = "../../../Test Texts/TextExport.txt";
            string expected = "Привет, я\r\nзаписываю в файл этот текст\r\nИ я для теста!!!!!!!!!!";
            new SaveText().textSaver?.Invoke(expected, path);

            StringAssert.Contains(expected, File.ReadAllText(path), "Результат неверный!");
        }
        [TestMethod]
        public void Exporting_Word()
        {
            string path = "../../../Test Texts/TextExport.docx";
            string expected = "Привет, я\r\nзаписываю в файл этот текст\r\nИ я для теста!!!!!!!!!!";
            new SaveText().textSaver?.Invoke(expected, path);

            StringAssert.Contains(expected, new OpenText().textOpener.Invoke(path), "Результат неверный!");
        }
    }
}
