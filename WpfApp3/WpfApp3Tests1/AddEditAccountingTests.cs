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
    public class AddEditAccountingTests
    {
        [TestMethod()]

        public void chekReferenceTest()
        {
            Accounting c = new Accounting {records_id = 100, company_id = 100, nameProduct = "Product", quantity = 10, price = 1000};
            bool expected = true;
            bool actual = AddEditAccounting.chekAccounting(c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chekReferenceNullTest()
        {
            Accounting c = new Accounting { records_id = 101, company_id = 100, nameProduct = "", quantity = 10, price = 1000 };
            bool expected = true;
            bool actual = AddEditAccounting.chekAccounting(c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chekReferenceDigitTest()
        {
            Accounting c = new Accounting { records_id = 102, company_id = 100, nameProduct = "Product123", quantity = 10, price = 1000 };
            bool expected = true;
            bool actual = AddEditAccounting.chekAccounting(c);
            Assert.AreEqual(expected, actual);
        }
    }
}