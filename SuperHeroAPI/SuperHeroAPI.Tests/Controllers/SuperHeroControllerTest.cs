using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroAPI.EntityFramework;
using SuperHeroAPI.EntityFramework.Moq;
using System.Collections.Generic;

namespace SuperHeroAPI.Tests.Controllers
{
    [TestClass]
    public class SuperHeroControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            SuperHero superHero = new SuperHero();

            Mock<ISuperHeroesMoq> mock = new Mock<ISuperHeroesMoq>();
            mock.Setup(m => m.RetornaSuperHeroById(1)).Returns(superHero);
            var superHerosMoq = new SuperHeroesMoq();
            var resultado = superHerosMoq.RetornaSuperHeroById(1);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void TestGet()
        {
            List<SuperHero> superHeros = new List<SuperHero>();

            Mock< ISuperHeroesMoq> mock = new Mock< ISuperHeroesMoq>();
            mock.Setup(m => m.RetornaSuperHeroes()).Returns(superHeros);
            var superHeroesMoq = new SuperHeroesMoq();
            var resultado = superHeroesMoq.RetornaSuperHeroes();
            Assert.IsNotNull(resultado);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void TestInsert()
        {
            SuperHero superHero = new SuperHero()
            {
                Id = 3,
                Name = "Varejao",
                Alias = "Disney",
                ProtectionArea_Id = 2,
                SuperPower_Id = 1
            };

            Mock< ISuperHeroesMoq> mock = new Mock< ISuperHeroesMoq>();
            mock.Setup(m => m.Insert(superHero)).Returns("Cadastrado realizado com sucesso");
            var superHerosMoq = new SuperHeroesMoq();
            var resultado = superHerosMoq.Insert(superHero);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Cadastrado realizado com sucesso", resultado);
        }

        [TestMethod]
        public void TestUpdate()
        {
            SuperHero superHero = new SuperHero()
            {
                Id = 1,
                Name = "Jordan Alterado",
                Alias = "Bruce",
                ProtectionArea_Id = 1,
                SuperPower_Id = 1
            };

            Mock< ISuperHeroesMoq> mock = new Mock< ISuperHeroesMoq>();
            mock.Setup(m => m.Update(superHero)).Returns("Atualização realizada com sucesso");
            var superHerosMoq = new SuperHeroesMoq();
            var resultado = superHerosMoq.Update(superHero);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Atualização realizada com sucesso", resultado);
        }

        [TestMethod]
        public void TestDelete()
        {
            SuperHero superHero = new SuperHero();

            Mock< ISuperHeroesMoq> mock = new Mock< ISuperHeroesMoq>();
            mock.Setup(m => m.Delete(1)).Returns("Exclusão realizada com sucesso");
            var superHerosMoq = new SuperHeroesMoq();
            var resultado = superHerosMoq.Delete(1);
            Assert.IsNotNull(resultado);

            Assert.AreEqual("Exclusão realizada com sucesso", resultado);
        }
    }
}
