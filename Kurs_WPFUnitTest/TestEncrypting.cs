using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurs_WPF;

namespace Kurs_WPFUnitTest
{
    [TestClass]
    public class TestEncrypting
    {
        readonly bool operation = true;
        [TestMethod]
        public void Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "ключ";
            string expected = "ъьжщпю";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextNull_Default()
        {
            string text = null;
            string key = "ключ";
            string expected = null;
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextWithParagraph_Default()
        {
            string text = "привет\r\nпривет";
            string key = "ключ";
            string expected = "ъьжщпю\r\nнзунгй";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextWithWhiteSpace_Default()
        {
            string text = "привет привет";
            string key = "ключ";
            string expected = "ъьжщпю нзунгй";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextWithSymbolsOrNumbers_Default()
        {
            string text = ".при?ве123т!!!";
            string key = "ключ";
            string expected = ".ъьж?щп123ю!!!";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextWithAnyRegister_Default()
        {
            string text = "прИвеТ";
            string key = "ключ";
            string expected = "ъьжщпю";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextIsEmpty_Default()
        {
            string text = "";
            string key = "ключ";
            string expected = "";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Encrypting_TextAll_WithUpperRegister()
        {
            string text = "Привет привет1. Привет ПрИве!!т\r\nприВет pRiVet \r\n ";
            string key = "ключ";
            string expected = "Ъьжщпю нзунгй1. Ъьжщпю НзУнг!!й\r\nъьжЩпю pRiVet \r\n ";
            string actual = TextCryptor.Crypting(text, key, true, true);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
    }
}
