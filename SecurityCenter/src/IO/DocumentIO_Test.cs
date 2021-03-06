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
            _note1.Text = "中文测试";
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

            doc2.AddNote(new Note2(){Name = "测试", Notes = "中文测试 abc", Tags = "测试,123,abc"});
            doc2.AddNote(new Note2(){Name = "测试2", Notes = "中文测试 abc 222", Tags = "测试,222"});
            doc2.AddNote(new Note2(){Name = "长文本", Notes = longTxt, Tags = ""});

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

玩转手机目前支持支持诺基亚、摩托罗拉、索尼爱立信、三星、LG等著名手机品牌的400多个型号的手机。此外，奇点软件目前为众多手机厂商提供“玩转手机”OEM版本。由于利用了插件技术，OEM版本可以支持一个手机厂商的所有型号的手机，而不论这些型号的手机是自研开发还是外包开发，或者手机端采用什么样的通信协议，这样一来没有必要在网站或随机光盘里面放各种不同版本的PC同步软件。 

 这对手机厂商带来很多好处，比如没有必要在网站或随机光盘里面放各种不同版本的PC同步软件，而让用户花上很长时间找到适合自己手机的版本。用户感到便利的同时也大大提高了厂商在其心目中的形象；对于厂商自己而言，售后服务人员只需要熟悉一套软件就可以提供售后服务，降低了售后服务的成本；同时管理一个版本相比管理很多版本要容易很多，这也就降低了软件版本的管理成本。 

 目前采用玩转手机“OEM”版本的客户有：华为、海尔、宇龙、UT、联想、康佳、TCL&Alcatel、波导、金立、东信、首信、佳通、IVT、滚石移动；合作伙伴有德信无线、深圳赛龙、SkyWorks、科泰世纪。 
";
    }
}
#endif