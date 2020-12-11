using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurs_WPF;

namespace Kurs_WPFUnitTest
{
    [TestClass]
    public class TestKey
    {
        [TestMethod]
        public void Key_Decrypting_TextSimple_Default()
        {
            string text = "ъьжщпю";
            string key = "ключ";
            string expected = "привет";
            string actual = TextCryptor.Crypting(text, key, false, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
        [TestMethod]
        public void Key_Encrypting_TextSimple_Default()
        {
            string text = "привет";
            string key = "ключ";
            string expected = "ъьжщпю";
            string actual = TextCryptor.Crypting(text, key, true, false);

            Assert.AreEqual(expected, actual, "Результат неверный!");
        }
    }
}
