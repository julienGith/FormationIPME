using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoFixture;
using AutoMapper;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoBinding.Api.Tests
{
    [TestClass]
    public class MoqUsersControllerTest
    {
        private UsersController UsersController { get; set; }

        public Mock<IGenericRepository<UserEntity>> UserRepository { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<UsersController> Logger { get; set; } = new NullLogger<UsersController>();

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<UserEntity> Users { get; set; }


        public MoqUsersControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UsersController)));
            Mapper = new Mapper(configuration);
        }

        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Users = Fixture.CreateMany<UserEntity>(10);
            UserRepository = new Mock<IGenericRepository<UserEntity>>();
            UsersController = new UsersController(UserRepository.Object, Mapper,Logger);
        }


        [TestMethod]
        public void TestGetAllUsers_Ok()
        {
            //Arrange
            UserRepository.Setup(repo => repo.GetAll()).Returns(Users);
            UserRepository.Setup(repo => repo.Add(It.IsAny<UserEntity>()))
                .Throws(new Exception("test unitaire"));
            
            //Act
            var result = UsersController.Get();

            //Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<UserDto>;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            UserRepository.Verify(repo => repo.GetAll(),Times.Exactly(1));
        }


        [TestMethod]
        public void TestGetAllUsers_NullRepository()
        {
            //Arrange
            UsersController = new UsersController(null, Mapper, Logger); 


            //Act
            var result = UsersController.Get();

            //Assert
            var statusResult = result as StatusCodeResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError); 
        }
    }
}