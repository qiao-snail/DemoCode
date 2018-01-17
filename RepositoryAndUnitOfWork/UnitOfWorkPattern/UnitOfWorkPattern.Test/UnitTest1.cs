using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitOfWorkPattern.Application;
using UnitOfWorkPattern.Application.ViewModels;

namespace UnitOfWorkPattern.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShow()
        {
            var res = new PersonManage().GetPersons();
            Console.WriteLine(res.Count);
            Assert.AreNotEqual(0, res.Count);
        }

        [TestMethod]
        public void TestAdd()
        {
            var res = new PersonManage().AddPerson(new PersonVM { Home = "meiguo", Age = 11, Name = "tidy" });
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestEdit()
        {
            var pmanage = new PersonManage();
            var p = pmanage.GetPersons()[0];
            p.Name = "fixed";
            var res = pmanage.EditPerson(p);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestDelete()
        {
            var pmanage = new PersonManage();
            var p = pmanage.GetPersons()[0];
            var res = pmanage.DeletePerson(p);
            Assert.IsTrue(res);
        }
    }
}
