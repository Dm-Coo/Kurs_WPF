using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurs_WPF;

namespace Kurs_WPFUnitTest
{
    [TestClass]
    public class TestKey
    {
        [TestMethod]
        public void Key_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "ключ";
            string expected = "ъьжщпю";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void KeyWithNumber_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "клю1ч";
            string expected = "ъьжвьэ";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void KeyWithSymbol_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "клю!ч";
            string expected = "ъьжвьэ";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void KeyIsEmpty_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "";
            string expected = "привет";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void KeyIsNull_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = null;
            string expected = "привет";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void KeyWithWhiteSpace_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "ключ к";
            string expected = "ъьжщеэ";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
    }
}
