using NUnit.Framework;
using MyPayProject;
using System.Collections.Generic;

namespace MyPayNUnitTestProject
{
    public class Tests
    {
        private List<PayRecord> _records;
        string fileName = @"..\..\..\Import/employee-payroll-data.csv";
        string fileWrite = @"..\..\..\Export/writeTest.csv";

        [SetUp]
        public void Setup()
        {
            _records = CsvImporter.ImportPayRecords(fileName);
        }

        [Test]
        public void TestImport()
        {
            Assert.AreEqual(_records.Count, 5);
        }
        [Test]
        public void TestGross()
        {
            Assert.AreEqual(_records[0].Gross, 652); 
            Assert.AreEqual(_records[1].Gross, 418);
            Assert.AreEqual(_records[2].Gross, 2202);
            Assert.AreEqual(_records[3].Gross, 1104);
            Assert.AreEqual(_records[4].Gross, 1797.45);
        }
        [Test]
        public void TestTax()
        {
            Assert.AreEqual(_records[0].Tax, 182.45);
            Assert.AreEqual(_records[1].Tax, 133.76);
            Assert.AreEqual(_records[2].Tax, 754.91);
            Assert.AreEqual(_records[3].Tax, 165.60);
            Assert.AreEqual(_records[4].Tax, 597.14);
        }
        [Test]
        public void TestNet()
        {
            Assert.AreEqual(_records[0].Net, 469.55);
            Assert.AreEqual(_records[2].Net, 1447.09);
            Assert.AreEqual(_records[1].Net, 284.24);
            Assert.AreEqual(_records[3].Net, 938.40);
            Assert.AreEqual(_records[4].Net, 1200.31);
        }
        [Test]
        public void TestExport()
        {
            PayRecordWriter.Write(_records, fileWrite, false);
            Assert.That(fileWrite, Does.Exist);
        }
    }
}