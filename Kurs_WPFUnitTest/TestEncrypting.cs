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
            string text = "������";
            string key = "����";
            string expected = "������";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextNull_Default()
        {
            string text = null;
            string key = "����";
            string expected = null;
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextWithParagraph_Default()
        {
            string text = "������\r\n������";
            string key = "����";
            string expected = "������\r\n������";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextWithWhiteSpace_Default()
        {
            string text = "������ ������";
            string key = "����";
            string expected = "������ ������";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextWithSymbolsOrNumbers_Default()
        {
            string text = ".���?��123�!!!";
            string key = "����";
            string expected = ".���?��123�!!!";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextWithAnyRegister_Default()
        {
            string text = "������";
            string key = "����";
            string expected = "������";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextIsEmpty_Default()
        {
            string text = "";
            string key = "����";
            string expected = "";
            string actual = TextCryptor.Crypting(text, key, operation, false);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
        [TestMethod]
        public void Encrypting_TextAll_WithUpperRegister()
        {
            string text = "������ ������1. ������ �����!!�\r\n������ pRiVet \r\n ";
            string key = "����";
            string expected = "������ ������1. ������ �����!!�\r\n������ pRiVet \r\n ";
            string actual = TextCryptor.Crypting(text, key, true, true);

            Assert.AreEqual(expected, actual, "��������� ��������!");
        }
    }
}
