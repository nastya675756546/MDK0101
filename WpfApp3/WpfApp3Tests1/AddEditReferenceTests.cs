using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp3.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Page.Tests
{
    [TestClass()]
    public class AddEditReferenceTests
    {
        [TestMethod()]

        public void chekReferenceTest()
        {
            Reference c = new Reference { company_id = 100, nameCompany = "YandexMusik", addressCompany = "Rossia", fullNameDirector = "Alexsandra CagavichА"};
            bool expected = true;
            bool actual = AddEditReference.chekReference(c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chekReferenceNullTest()
        {
            Reference c = new Reference { company_id = 101, nameCompany = "", addressCompany = "Rossia", fullNameDirector = "Alexsandra CagavichА"};
            bool expected = true;
            bool actual = AddEditReference.chekReference(c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chekReferenceDigitTest()
        {
            Reference c = new Reference { company_id = 102, nameCompany = "YandexMusik123", addressCompany = "Rossia", fullNameDirector = "Alexsandra CagavichА"};
            bool expected = true;
            bool actual = AddEditReference.chekReference(c);
            Assert.AreEqual(expected, actual);
        }
    }
}