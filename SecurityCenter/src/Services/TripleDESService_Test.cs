#if DEBUG
using System;
using NUnit.Framework;

namespace SecurityCenter.Services {
    [TestFixture]
    public class TripleDESService_Test {
        public void TestEncryptAndDecrypt() {
            string clear = "This is the clear text.\r\nIt includes new lines\r\n�������Ĳ���";
            string key = "Here is the private key";

            TripleDESService des = new TripleDESService();
            string encrypted = des.Encrypt(key, clear);
            string decrypted = des.Decrypt(key, encrypted);

            Console.Out.WriteLine("Encrypted: " + encrypted);
            Console.Out.WriteLine("Decrypted: " + decrypted);

            Assert.AreEqual(clear, decrypted);
        }

        public void TestLongKey() {
            string clear = "This test case will test long key.";
            string key = "abcdefghijklmnopqrstuvwxyz";

            TripleDESService des = new TripleDESService();
            string encrypted = des.Encrypt(key, clear);
            string decrypted = des.Decrypt(key, encrypted);

            Assert.AreEqual(clear, decrypted);

        }

        public void TestLongClearText() {
            string clear = @"
Introduction
There are many, many examples of how to do encryption and decryption in .NET. So why one more? Well, for one thing, I find that the majority of good code examples of any type are issued in C#. This isn't surprising, since those from a C++ or Java background will have an easier transition to C# than a similarly experienced Visual Basic developer moving to VB.NET. It will take time for the VB.NET community to develop into what the C++ and Java community already has at its disposal. So, I thought that a solid, simple VB.NET example would do well.

Overview
This code example does four things that I think are missing from the examples that I have seen so far:

It's written in Visual Basic .NET. Not that it is in any way superior or inferior to C#, but most of the other examples (and all of the good ones) were done in C#. 
It uses the UTF-8 encoder to ensure that the strings which are encrypted or decrypted are in an 8-bit format. Many examples that I see use the ASCII encoding, which is a 7-bit format. When you combine this with TripleDES (which uses 3, 8-bit blocks for the key), you can get yourself into situations where you cannot decrypt something you encrypted. 
It uses the Convert object's Base-64 methods to make sure that the encrypted text is output in such a way that it can be easily stored in text files and/or database fields without the risk of your encrypted content being inadvertently modified by implicit conversions. 
It centralizes the actual encryption and decryption functionality into a single method, thus eliminating what would otherwise be 99% redundant code. 

��ת�ֻ�Ŀǰ֧��֧��ŵ���ǡ�Ħ�����������ᰮ���š����ǡ�LG�������ֻ�Ʒ�Ƶ�400����ͺŵ��ֻ������⣬������ĿǰΪ�ڶ��ֻ������ṩ����ת�ֻ���OEM�汾�����������˲��������OEM�汾����֧��һ���ֻ����̵������ͺŵ��ֻ�����������Щ�ͺŵ��ֻ������п���������������������ֻ��˲���ʲô����ͨ��Э�飬����һ��û�б�Ҫ����վ�������������Ÿ��ֲ�ͬ�汾��PCͬ������� 

 ����ֻ����̴����ܶ�ô�������û�б�Ҫ����վ�������������Ÿ��ֲ�ͬ�汾��PCͬ������������û����Ϻܳ�ʱ���ҵ��ʺ��Լ��ֻ��İ汾���û��е�������ͬʱҲ�������˳���������Ŀ�е����󣻶��ڳ����Լ����ԣ��ۺ������Աֻ��Ҫ��Ϥһ������Ϳ����ṩ�ۺ���񣬽������ۺ����ĳɱ���ͬʱ����һ���汾��ȹ���ܶ�汾Ҫ���׺ܶ࣬��Ҳ�ͽ���������汾�Ĺ���ɱ��� 

 Ŀǰ������ת�ֻ���OEM���汾�Ŀͻ��У���Ϊ��������������UT�����롢���ѡ�TCL&Alcatel�����������������š����š���ͨ��IVT����ʯ�ƶ�����������е������ߡ�����������SkyWorks����̩���͡� 
";
            string key = "Long text key.";

            TripleDESService des = new TripleDESService();

            Assert.AreEqual(clear, des.Decrypt(key, des.Encrypt(key, clear)));
        }
    }
}

#endif