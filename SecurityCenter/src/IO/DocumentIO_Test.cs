#if DEBUG
using System;
using System.Collections.Generic;
using NUnit.Framework;
using SecurityCenter.Entity;
using SecurityCenter.Services;

namespace SecurityCenter.IO {
    [TestFixture]
    public class DocumentIO_Test {
        private Note _note0;
        private Note _note1;
        private string _pwd;

        [TestFixtureSetUp]
        public void TestFixtureSetup() {
            _pwd = "123";

            _note0 = new Note();
            _note0.Name = "Note1";
            _note0.Text = "Note test case.";

            _note1 = new Note();
            _note1.Name = "Note2";
            _note1.Text = "���Ĳ���";
        }

        public void TestReader() {
            WriteExample();

            DocumentReader reader = new DocumentReader(_pwd);
            reader.Load();

            Assert.AreEqual("1.0", reader.State.Doc.Schema.Version);

            Note[] safeNotes = reader.State.ClearGroup.GetNotes();
            
            Assert.AreEqual(2, safeNotes.Length);
            Assert.AreEqual(_note0.Name, safeNotes[0].Name);
            Assert.AreEqual(_note0.Text, safeNotes[0].Text);
            Assert.AreEqual(_note1.Name, safeNotes[1].Name);
            Assert.AreEqual(_note1.Text, safeNotes[1].Text);
        }
        [Test]
        public void WriteExample() {
            ClearState state = new ClearState();
            state.Password = _pwd;
            Note safe0 = _note0;
            Note safe1 = _note1;
            state.ClearGroup.Elements.Add(safe0);
            state.ClearGroup.Elements.Add(safe1);

            DocumentWriter writer = new DocumentWriter(state);
            writer.Write();
        }

        [Test]
        public void WriteExample2() {
            SecurityCenterDocument2 doc2 = new SecurityCenterDocument2();
            doc2.LastUpdatedDate = DateTime.Now;

            doc2.AddNote(new Note2(){Name = "����", Notes = "���Ĳ��� abc", Tags = "����,123,abc"});
            doc2.AddNote(new Note2(){Name = "����2", Notes = "���Ĳ��� abc 222", Tags = "����,222"});
            doc2.AddNote(new Note2(){Name = "���ı�", Notes = longTxt, Tags = ""});

            Doc2IO io = new Doc2IO();
            io.Save(doc2, "doc2_test.dat", "123");
        }

        [Test]
        public void LoadExample2() {
            SecurityCenterDocument2 doc2 = new Doc2IO().Load("doc2_test.dat", "123");
        }

        [Test, ExpectedException(typeof(WrongPasswordException))]
        public void LoadExample2WithWrongPwd() {
            SecurityCenterDocument2 doc2 = new Doc2IO().Load("doc2_test.dat", "12");
        }

        private string longTxt = @"
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
    }
}
#endif