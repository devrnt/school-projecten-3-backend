using TalentCoach.Controllers;
using TalentCoach.Models.Domain;
using TalentCoach.Tests.Data;
using Microsoft.AspNetCore;
using Xunit;
using Newtonsoft.Json;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using TalentCoach.Models;

namespace TalentCoach.Tests.Controllers
{
    public class LeerlingenControllerTest
    {
        private readonly Mock<ILeerlingenRepository> _mockRepository;
        private readonly Mock<ILeerlingCompetentieRepository> _mockRepositoryLlnComp;
        private readonly Mock<ILeerlingWerkaanbiedingenRepository> _mockRepositoryLWaB;
        private readonly Mock<IWerkgeversRepository> _mockRepositoryLWg;
        private readonly DummyApplicationDbContext _context;
        private readonly LeerlingenController _controller;

        public LeerlingenControllerTest()
        {
            _context = new DummyApplicationDbContext();
            _mockRepository = new Mock<ILeerlingenRepository>();
            _mockRepositoryLlnComp = new Mock<ILeerlingCompetentieRepository>();
            _mockRepositoryLWaB = new Mock<ILeerlingWerkaanbiedingenRepository>();
            _mockRepositoryLWg = new Mock<IWerkgeversRepository>();
            _mockRepository.Setup(m => m.GetLeerling(1)).Returns(_context.Leerlingen[0]);
            _mockRepository.Setup(m => m.GetLeerling(2)).Returns(_context.Leerlingen[1]);
            _mockRepository.Setup(m => m.GetLeerling(6)).Returns(null as Leerling);
            _mockRepository.Setup(m => m.GetAll()).Returns(_context.Leerlingen);
            _controller = new LeerlingenController(_mockRepository.Object, _mockRepositoryLlnComp.Object,_mockRepositoryLWaB.Object,_mockRepositoryLWg.Object);
        }

        #region === GetAll ===
        [Fact]
        public void GetAll_WhenCalled_ReturnsActionResult()
        {
            var result = _controller.GetAll();

            Assert.IsType<ActionResult<List<Leerling>>>(result);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            var aantalLeerlingen = _context.Leerlingen.Count;
            var result = _controller.GetAll();

            var items = Assert.IsType<ActionResult<List<Leerling>>>(result);
            Assert.Equal(aantalLeerlingen, items.Value.Count);
        }
        #endregion

        #region === GetById ===

        [Fact]
        public void GetById_WrongId_ReturnsNotFoundResult()
        {
            var result = _controller.GetById(123);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void GetById_RightId_ReturnsRightLeerling()
        {
            var result = _controller.GetById(2);

            Assert.IsType<Leerling>(result.Value);
            // Assert.Equal(1, result.Value.Id);
        }
        #endregion

        #region === Create ===
        [Fact]
        public void CreateLeerling_ReturnsCreatedResponse()
        {
            Leerling newLeerling = new Leerling(
                "Haleydt",
                "Renaat",
                new DateTime(1994, 2, 2),
                Geslacht.Man,
                "renaat.Haleydt@school.be"
               );

            var result = _controller.Create(newLeerling);

            Assert.IsType<CreatedAtRouteResult>(result);

        }

        [Fact]
        public void CreateLeerling_ReturnsHasCreatedItem()
        {
            Leerling newLeerling = new Leerling(
            "Haleydt",
            "Renaat",
            new DateTime(1994, 2, 2),
            Geslacht.Man,
            "renaat.Haleydt@school.be"
            );

            var result = _controller.Create(newLeerling) as CreatedAtRouteResult;
            var item = result.Value as Leerling;

            Assert.IsType<Leerling>(item);
            Assert.Equal("Renaat", item.Voornaam);
        }
        #endregion

        #region === Update == 
        [Fact]
        public void Update_WrongId_ReturnsNotFoundResult()
        {
            var leerling = new Leerling(
            "Haleydt",
            "Renaat",
            new DateTime(1994, 2, 2),
            Geslacht.Man,
            "renaat.Haleydt@school.be");
            var result = _controller.Update(93393939, leerling);
            Assert.IsType<ActionResult<Leerling>>(result);
        }

        [Fact]
        public void Update_RightId_ReturnsUpdatedLeerling()
        {
            var leerling = new Leerling(
            "Haleydt",
            "Renaat",
            new DateTime(1994, 2, 2),
            Geslacht.Man,
            "renaat.Haleydt@school.be"
            );
            _mockRepository.Setup(m => m.UpdateLeerling(1, It.IsAny<Leerling>())).Returns(leerling);
            var result = _controller.Update(1, leerling);
            Assert.Equal("Renaat", result?.Value.Voornaam);
        }

        #endregion

        #region === Delete === 
        //      [Fact]
        //public void Delete_WrongId_ReturnsNotFoundResult() {
        //	var result = _controller.Delete(123);
        //	Assert.IsType<NotFoundObjectResult>(result);
        //}

        //[Fact]
        //public void Delete_RightId_ReturnsNoContentResult() {
        //	var items = _controller.GetAll().Value;
        //	var result = _controller.Delete(1);
        //	Assert.IsType<NoContentResult>(result);
        //}
        #endregion

    }
}
