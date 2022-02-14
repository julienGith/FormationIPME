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

namespace DemoBinding.Api.Tests
{
    [TestClass]
    public class UsersControllerTest
    {
        private UsersController UsersController { get; set; }

        public IGenericRepository<UserEntity> UserRepository { get; set; } = new FakeGenericRepository<UserEntity>();

        public IMapper Mapper { get; set; }

        public ILogger<UsersController> Logger { get; set; } = new NullLogger<UsersController>();



        public UsersControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UsersController)));
            Mapper = new Mapper(configuration);

        }

        [TestInitialize]
        public void InitTest()
        {
            UsersController = new UsersController(UserRepository, Mapper,Logger);
        }

        [TestMethod]
        public void TestGetAllUsers_Ok()
        {
            //Arrange

            //Act
            var result = UsersController.Get();

            //Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<UserDto>;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(15);
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