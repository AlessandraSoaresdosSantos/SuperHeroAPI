using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;

namespace SuperHeroAPI.Tests.Controllers
{
    [TestClass]
    public class SuperPowerControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            SuperPower superPower = new SuperPower();

            Mock<ISuperPowersMoq> mock = new Mock<ISuperPowersMoq>();
            mock.Setup(m => m.RetornaSuperPowerById(1)).Returns(superPower);
            var superPowersMoq = new SuperPowersMoq();
            var resultado = superPowersMoq.RetornaSuperPowerById(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void TestGet()
        {
            List<SuperPower> superPowers = new List<SuperPower>();

            Mock<ISuperPowersMoq> mock = new Mock<ISuperPowersMoq>();
            mock.Setup(m => m.RetornaSuperPowers()).Returns(superPowers);
            var superPowersMoq = new SuperPowersMoq();
            var resultado = superPowersMoq.RetornaSuperPowers();
            Assert.IsNotNull(resultado);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void TestInsert()
        {
            SuperPower superPower = new SuperPower()
            {
                Id = 3,
                Name = "Robin",
                Description = "SuperPower Robin"
            };

            Mock<ISuperPowersMoq> mock = new Mock<ISuperPowersMoq>();
            mock.Setup(m => m.Insert(superPower)).Returns("Cadastrado realizado com sucesso");
            var superPowersMoq = new SuperPowersMoq();
            var resultado = superPowersMoq.Insert(superPower);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Cadastrado realizado com sucesso", resultado);
        }

        [TestMethod]
        public void TestUpdate()
        {
            SuperPower superPower = new SuperPower()
            {
                Id = 2,
                Name = "Batman Alterado",
                Description = "SuperPower Batman Alterado"
            };

            Mock<ISuperPowersMoq> mock = new Mock<ISuperPowersMoq>();
            mock.Setup(m => m.Update(superPower)).Returns("Atualização realizada com sucesso");
            var superPowersMoq = new SuperPowersMoq();
            var resultado = superPowersMoq.Update(superPower);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Atualização realizada com sucesso", resultado);
        }

        [TestMethod]
        public void TestDelete()
        {
            SuperPower superPower = new SuperPower();

            Mock<ISuperPowersMoq> mock = new Mock<ISuperPowersMoq>();
            mock.Setup(m => m.Delete(1)).Returns("Exclusão realizada com sucesso");
            var superPowersMoq = new SuperPowersMoq();
            var resultado = superPowersMoq.Delete(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Exclusão realizada com sucesso", resultado);
        }
    }
}
