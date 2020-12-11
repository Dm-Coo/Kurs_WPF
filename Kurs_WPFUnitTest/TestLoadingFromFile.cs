using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurs_WPF;
using System.Windows.Controls;
using System.Text;
using System.Globalization;

namespace Kurs_WPFUnitTest
{
    [TestClass]
    public class TestLoadingFromFile
    {
        [TestMethod]
        public void Loading_From_Txt_UTF8()
        {
            string path = "../../../Test Texts/TextWithUTF8.txt";
            string expected = "Привет, я\r\nвсего лишь текстовый документ\r\nИ я для теста!!!!!!!!!!";
            string actual = new OpenText().textOpener?.Invoke(path);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Loading_From_Txt_ANSI()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string path = "../../../Test Texts/TextWithANSI.txt";
            string expected = "Это обычный текст или не обычный";
            string actual = new OpenText().textOpener?.Invoke(path);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Loading_From_Word()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string path = "../../../Test Texts/TestWord.docx";
            string expected = "Привет, я\r\nвсего лишь текстовый документ\r\nИ я для теста!!!!!!!!!!";
            string actual = new OpenText().textOpener?.Invoke(path);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
    }
}
