﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;

namespace SuperHeroAPI.Tests.Controllers
{
    [TestClass]
    public class RoleControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            Role role = new Role();

            Mock<IRolesMoq> mock = new Mock<IRolesMoq>();
            mock.Setup(m => m.RetornaRoleById(1)).Returns(role);
            var rolesMoq = new RolesMoq();
            var resultado = rolesMoq.RetornaRoleById(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual(1, resultado.Id); 
         }

        [TestMethod]
        public void TestGet()
        {
            List<Role> roles = new List<Role>();

            Mock<IRolesMoq> mock = new Mock<IRolesMoq>();
            mock.Setup(m => m.RetornaRoles()).Returns(roles);
            var rolesMoq = new RolesMoq();
            var resultado = rolesMoq.RetornaRoles();
            Assert.IsNotNull(resultado);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
         }

        [TestMethod]
        public void TestInsert()
        {
            Role role = new Role() {
                Id= 3,
                Name = "User",
                User_Id = 2
            };

            Mock<IRolesMoq> mock = new Mock<IRolesMoq>();
            mock.Setup(m => m.Insert(role)).Returns("Cadastrado realizado com sucesso");
            var rolesMoq = new RolesMoq();
            var resultado = rolesMoq.Insert(role);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Cadastrado realizado com sucesso",  resultado);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Role role = new Role()
            {
                Id = 1,
                Name = "Admin Alterado",
                User_Id = 1
            };

            Mock<IRolesMoq> mock = new Mock<IRolesMoq>();
            mock.Setup(m => m.Update(role)).Returns("Atualização realizada com sucesso");
            var rolesMoq = new RolesMoq();
            var resultado = rolesMoq.Update(role);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Atualização realizada com sucesso", resultado);
        }

        [TestMethod]
        public void TestDelete()
        {
            Role role = new Role();

            Mock<IRolesMoq> mock = new Mock<IRolesMoq>();
            mock.Setup(m => m.Delete(1)).Returns("Exclusão realizada com sucesso");
            var rolesMoq = new RolesMoq();
            var resultado = rolesMoq.Delete(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Exclusão realizada com sucesso", resultado);
        }
    }
}
