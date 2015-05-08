using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Domain.Tests.ValueObject
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Em_Branco()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        public void Email_New_Email_Valido()
        {
            var endereco = "angeloocana@gmail.com";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Endereco);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalido()
        {
            var email = new Email("sdfgsdbglsdkjbgsdlkgb");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Erro_MaxLength()
        {
            var endereco = "angeloocana@gmail.com.br";
            while (endereco.Length < Email.EnderecoMaxLength + 1)
            {
                endereco = endereco + "angeloocana@gmail.com.br";
            }

            new Email(endereco);
        }
    }
}

