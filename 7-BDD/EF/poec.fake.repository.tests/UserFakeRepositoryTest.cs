using System;
using System.Collections.Generic;
using System.Linq;
using poec.sql.dtos;
using Xunit;

namespace poec.fake.repository.tests;

/// <summary>
/// Classe de tests respectant le pattern AAA
/// </summary>
public class UserFakeRepositoryTest
{
    private UserFakeRepository Repo { get; }= new();

    [Fact]
    public void GetTest()
    {
        //Arrange
        const short id = 1;

        //Action
        UserSqlDto? userSqlDto = Repo.GetSingle(id);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto.UserId, id);
    }

    [Fact]
    public void GetPredicateTest()
    {
        //Arrange
        const short count = 1;
        const string userName = "Alex";
        bool Predicate(UserSqlDto user) => user.Birthday.Year == 1990;
        //équivalet à Func<UserSqlDto, bool> predicate = user => user.Birthday.Year == 1990;

        //Action
        IList<UserSqlDto> userSqlDto = Repo.GetPredicate(Predicate);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto.Count, count);
        Assert.Equal(userSqlDto.First().UserName, userName);
    }

    [Fact]
    public void GetPredicateErrorTest()
    {
        //Arrange
        const string userName = "alex";
        bool Predicate(UserSqlDto user) => user.UserName == userName;

        //Action
        IList<UserSqlDto> userSqlDto = Repo.GetPredicate(Predicate);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Empty(userSqlDto);
    }
}