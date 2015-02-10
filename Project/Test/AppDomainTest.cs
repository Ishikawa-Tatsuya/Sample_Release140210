using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class AppDomainTest
    {
        WindowsAppFriend _app;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start("Target.exe"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void Test()
        {
            dynamic form = _app.Type<Application>().OpenForms[0];

            //新しいドメイン開始
            form.StartNewDomain();

            //別のドメインを取得
            var apps = _app.AttachOtherDomains();

            Assert.AreEqual(1, apps.Length);
            Assert.AreEqual("new domain 0", (string)apps[0].Type<AppDomain>().CurrentDomain.FriendlyName);
        }
    }
}
