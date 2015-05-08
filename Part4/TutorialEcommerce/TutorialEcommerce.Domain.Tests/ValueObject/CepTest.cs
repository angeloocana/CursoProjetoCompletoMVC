using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Domain.Tests.ValueObject
{
    [TestClass]
    public class CepTest
    {
        [TestMethod]
        public void Cep_Valido()
        {
            var cep = "06414-000";
            var obj = new Cep(cep);
            Assert.AreEqual(6414000, obj.CepCod);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cep_InValido()
        {
            var cep = "asfsaf";
            var obj = new Cep(cep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cep_Embranco()
        {
            new Cep("");
        }
        
        [TestMethod]
        public void Cep_GetCepFormatado06414000()
        {
            var cep = "06414-000";
            var obj = new Cep(cep);
            Assert.AreEqual(cep, obj.GetCepFormatado());
        }

        [TestMethod]
        public void Cep_GetCepFormatado00000000()
        {
            var cep = "00000-000";
            var obj = new Cep(cep);
            Assert.AreEqual(cep, obj.GetCepFormatado());
        }

        [TestMethod]
        public void Cep_GetCepFormatado12345678()
        {
            var cep = "12345-678";
            var obj = new Cep(cep);
            Assert.AreEqual(cep, obj.GetCepFormatado());
        }
    }
}
