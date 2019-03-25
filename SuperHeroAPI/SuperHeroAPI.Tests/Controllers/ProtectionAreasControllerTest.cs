using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;

namespace SuperHeroAPI.Tests.Controllers
{
    [TestClass]
    public class ProtectionAreaControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            ProtectionArea protectionArea = new ProtectionArea();

            Mock<IProtectionAreasMoq> mock = new Mock<IProtectionAreasMoq>();
            mock.Setup(m => m.RetornaProtectionAreaById(1)).Returns(protectionArea);
            var protectionAreasMoq = new ProtectionAreasMoq();
            var resultado = protectionAreasMoq.RetornaProtectionAreaById(1);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void TestGet()
        {
            List<ProtectionArea> ProtectionAreas = new List<ProtectionArea>();

            Mock<IProtectionAreasMoq> mock = new Mock<IProtectionAreasMoq>();
            mock.Setup(m => m.RetornaProtectionAreas()).Returns(ProtectionAreas);
            var protectionAreasMoq = new ProtectionAreasMoq();
            var resultado = protectionAreasMoq.RetornaProtectionAreas();

            Assert.IsNotNull(resultado);
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void TestInsert()
        {
            ProtectionArea ProtectionArea = new ProtectionArea()
            {
                Id = 3,
                Name = "Area C",
                Lat = 2.15f,
                Long = 4.15f,
                Radius = 2.1f
            };

            Mock<IProtectionAreasMoq> mock = new Mock<IProtectionAreasMoq>();
            mock.Setup(m => m.Insert(ProtectionArea)).Returns("Cadastrado realizado com sucesso");
            var ProtectionAreasMoq = new ProtectionAreasMoq();
            var resultado = ProtectionAreasMoq.Insert(ProtectionArea);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Cadastrado realizado com sucesso", resultado);
        }

        [TestMethod]
        public void TestUpdate()
        {
            ProtectionArea ProtectionArea = new ProtectionArea()
            {
                Id = 1,
                Name = "Area A Alterado",
                Lat = 1.45f,
                Long = 3.45f,
                Radius = 6.3f
            };

            Mock<IProtectionAreasMoq> mock = new Mock<IProtectionAreasMoq>();
            mock.Setup(m => m.Update(ProtectionArea)).Returns("Atualização realizada com sucesso");
            var protectionAreasMoq = new ProtectionAreasMoq();
            var resultado = protectionAreasMoq.Update(ProtectionArea);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Atualização realizada com sucesso", resultado);
        }

        [TestMethod]
        public void TestDelete()
        {
            ProtectionArea ProtectionArea = new ProtectionArea();

            Mock<IProtectionAreasMoq> mock = new Mock<IProtectionAreasMoq>();
            mock.Setup(m => m.Delete(1)).Returns("Exclusão realizada com sucesso");
            var protectionAreasMoq = new ProtectionAreasMoq();
            var resultado = protectionAreasMoq.Delete(1);

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Exclusão realizada com sucesso", resultado);
        }
    }
}
