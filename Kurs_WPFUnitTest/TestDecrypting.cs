using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurs_WPF;

namespace Kurs_WPFUnitTest
{
    [TestClass]
    public class TestDecrypting
    {
        bool operation = false;
        [TestMethod]
        public void Decrypting_TextSimple_Default()
        {
            string text = "ъьжщпю";
            string key = "ключ";
            string expected = "привет";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextWithParagraph_Default()
        {
            string text = "ъьжщпю\r\nнзунгй";
            string key = "ключ";
            string expected = "привет\r\nпривет";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextWithWhiteSpace_Default()
        {
            string text = "ъьжщпю нзунгй";
            string key = "ключ";
            string expected = "привет привет";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextWithSymbolsOrNumbers_Default()
        {
            string text = ".ъьж?щп123ю!!!";
            string key = "ключ";
            string expected = ".при?ве123т!!!";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextWithAnyRegister_Default()
        {
            string text = "ъьжщпю";
            string key = "ключ";
            string expected = "привет";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextIsEmpty_Default()
        {
            string text = "";
            string key = "ключ";
            string expected = "";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextAll_WithUpperRegister()
        {
            string text = "Ъьжщпю нзунгй1. Ъьжщпю НзУнг!!й\r\nъьжЩпю pRiVet \r\n ";
            string key = "ключ";
            string expected = "Привет привет1. Привет ПрИве!!т\r\nприВет pRiVet \r\n ";
            string actual = TextCryptor.Crypting(text, key, operation, true);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextAll_WithAsInSentence()
        {
            string text = "ъьжщпю нзунгй1. Ъьжщпю НзУнг!!й\r\nъьжЩпю pRiVet \r\n ";
            string key = "ключ";
            string expected = "Привет привет1. Привет приве!!Т\r\nПривет pRiVet \r\n ";
            string temp = TextCryptor.Crypting(text, key, operation, false);
            string actual = TextCryptor.ToSentenceRegister(temp);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextAll_WithAsInSentenceAndUpperRegister()
        {
            string text = "ъьжщпю нзунгй1. ЪьжщПю НзУнг!!й\r\nъьжЩпю pRiVet \r\n ";
            string key = "ключ";
            string expected = "Привет привет1. ПривЕт ПрИве!!Т\r\nПриВет pRiVet \r\n ";
            string temp = TextCryptor.Crypting(text, key, operation, true);
            string actual = TextCryptor.ToSentenceRegister(temp);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Decrypting_TextNull_WithAsInSentenceAndUpperRegister()
        {
            string text = null;
            string key = "ключ";
            string expected = null;
            string temp = TextCryptor.Crypting(text, key, operation, true);
            string actual = TextCryptor.ToSentenceRegister(temp);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
    }
}
