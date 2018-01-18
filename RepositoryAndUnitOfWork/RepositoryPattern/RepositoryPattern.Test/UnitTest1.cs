using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPattern.Application;
using RepositoryPattern.Application.ViewModels;

namespace RepositoryPattern.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShowPerson()
        {
            var res = new PersonManage().GetPersons();
            Assert.AreNotEqual(0, res.Count);
        }

        [TestMethod]
        public void TestAddPerson()
        {
            var p = new PersonVM { Home = "zhengzhou", Age = 22, Name = "Jessica", PersonID = 3 };
            var res = new PersonManage().AddPerson(p);
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void TestEditPerson()
        {
            var persons = new PersonManage().GetPersons();
            var p = persons[0];
            p.Name = "fixed";
            var res = new PersonManage().EditPerson(p);
            Assert.IsTrue(res);
        }


        [TestMethod]
        public void TestDeletePerson()
        {
            var persons = new PersonManage().GetPersons();
            var p = persons[0];
            var res = new PersonManage().DeletePerson(p);
            Assert.IsTrue(res);
        }
    }

}
