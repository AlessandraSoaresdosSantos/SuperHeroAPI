using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroAPI.EntityFramework;
using System;
using System.Collections.Generic;

namespace SuperHeroAPI.Tests.Controllers
{
    [TestClass]
    public class AuditEventControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            AuditEvent AuditEvent = new AuditEvent();

            Mock<IAuditEventsMoq> mock = new Mock<IAuditEventsMoq>();
            mock.Setup(m => m.RetornaAuditEventById(1)).Returns(AuditEvent);
            var AuditEventsMoq = new AuditEventsMoq();
            var resultado = AuditEventsMoq.RetornaAuditEventById(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void TestGet()
        {
            List<AuditEvent> AuditEvents = new List<AuditEvent>();

            Mock<IAuditEventsMoq> mock = new Mock<IAuditEventsMoq>();
            mock.Setup(m => m.RetornaAuditEvents()).Returns(AuditEvents);
            var AuditEventsMoq = new AuditEventsMoq();
            var resultado = AuditEventsMoq.RetornaAuditEvents();

            Assert.IsNotNull(resultado);
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void TestInsert()
        {
            AuditEvent AuditEvent = new AuditEvent()
            {
                Id = 3,
                Entity = "User",
                EntityId = 1,
                Datetime = Convert.ToDateTime("25-03-2019"),
                Action = "Post",
                Username_Id = 2
            };

            Mock<IAuditEventsMoq> mock = new Mock<IAuditEventsMoq>();
            mock.Setup(m => m.Insert(AuditEvent)).Returns("Cadastrado realizado com sucesso");
            var AuditEventsMoq = new AuditEventsMoq();
            var resultado = AuditEventsMoq.Insert(AuditEvent);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Cadastrado realizado com sucesso", resultado);
        }

        [TestMethod]
        public void TestUpdate()
        {
            AuditEvent AuditEvent = new AuditEvent()
            {
                Id = 1,
                Entity = "SuperHero Alterado",
                EntityId = 1,
                Datetime = Convert.ToDateTime("24-03-2019"),
                Action = "Get",
                Username_Id = 1
            };

            Mock<IAuditEventsMoq> mock = new Mock<IAuditEventsMoq>();
            mock.Setup(m => m.Update(AuditEvent)).Returns("Atualização realizada com sucesso");
            var AuditEventsMoq = new AuditEventsMoq();
            var resultado = AuditEventsMoq.Update(AuditEvent);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Atualização realizada com sucesso", resultado);
        }

        [TestMethod]
        public void TestDelete()
        {
            AuditEvent AuditEvent = new AuditEvent();

            Mock<IAuditEventsMoq> mock = new Mock<IAuditEventsMoq>();
            mock.Setup(m => m.Delete(1)).Returns("Exclusão realizada com sucesso");
            var AuditEventsMoq = new AuditEventsMoq();
            var resultado = AuditEventsMoq.Delete(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Exclusão realizada com sucesso", resultado);
        }
    }
}
