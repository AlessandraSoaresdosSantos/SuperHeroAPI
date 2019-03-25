using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroAPI.EntityFramework;
using SuperHeroAPI.EntityFramework.PreparaHash;
using System.Collections.Generic;

namespace SuperHeroAPI.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            User user = new User();

            Mock<IUsersMoq> mock = new Mock<IUsersMoq>();
            mock.Setup(m => m.RetornaUserById(1)).Returns(user);
            var usersMoq = new UsersMoq();
            var resultado = usersMoq.RetornaUserById(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void TestGet()
        {
            List<User> users = new List<User>();

            Mock<IUsersMoq> mock = new Mock<IUsersMoq>();
            mock.Setup(m => m.RetornaUsers()).Returns(users);
            var usersMoq = new UsersMoq();
            var resultado = usersMoq.RetornaUsers();
            Assert.IsNotNull(resultado);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void TestInsert()
        {
            var criptografar = new PreparaHash();

            User user = new User()
            {
                Id = 3,
                Username = "pedro123",
                Password = criptografar.RetornaSenhaCriptografada("joaopedro2019")
            };

            Mock<IUsersMoq> mock = new Mock<IUsersMoq>();
            mock.Setup(m => m.Insert(user)).Returns("Cadastrado realizado com sucesso");
            var usersMoq = new UsersMoq();
            var resultado = usersMoq.Insert(user);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Cadastrado realizado com sucesso", resultado);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var criptografar = new PreparaHash();

            User user = new User()
            {
                Id = 1,
                Username = "marta2020",
                Password = criptografar.RetornaSenhaCriptografada("Brasil126")
            };

            Mock<IUsersMoq> mock = new Mock<IUsersMoq>();
            mock.Setup(m => m.Update(user)).Returns("Atualização realizada com sucesso");
            var usersMoq = new UsersMoq();
            var resultado = usersMoq.Update(user);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Atualização realizada com sucesso", resultado);
        }

        [TestMethod]
        public void TestDelete()
        {
            User user = new User();

            Mock<IUsersMoq> mock = new Mock<IUsersMoq>();
            mock.Setup(m => m.Delete(1)).Returns("Exclusão realizada com sucesso");
            var usersMoq = new UsersMoq();
            var resultado = usersMoq.Delete(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Exclusão realizada com sucesso", resultado);
        }
    }
}
