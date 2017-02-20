using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ContactManagement.Repository;
using System.Collections.Generic;
using ContactManagement.Models;
using System.Net;

namespace ContactManagement.Tests
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void TestGetAllcontact()
        {
            //Arranage
            var controller = new Controllers.ContactController();
            MockRepository();

            //Act
            var result = controller.Get();

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestPostcontact()
        {
            //Arranage
            var controller = new Controllers.ContactController();
            MockRepository();

            //Act
            var result = controller.Post(new Contacts());
            
            //Assert
            Assert.IsNotNull(result);

        }

        private void MockRepository()
        {
            var listOfContacts = new List<Contacts>();
            listOfContacts.Add(new Contacts());
            Mock<IContactRepository> mockRepository = new Mock<IContactRepository>();
            mockRepository.Setup(r => r.GetAllContact()).Returns(listOfContacts);
            mockRepository.Setup(r => r.SaveContact(new Contacts()));
        }
    }
}
