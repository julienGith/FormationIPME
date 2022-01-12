using poec.sql.dtos;
using poec.sql.repository;
using Xunit;

namespace poec.sql.repository.tests
{
    public class SqlRepositoryTest
    {
        private SqlDbContext SqlDbContext { get; }
        private UserSqlRepository UserSqlRepository { get; }

        public SqlRepositoryTest()
        {
            SqlDbContext = new SqlDbContext("Server=.;Database=EFTest;Trusted_Connection=True;");
            UserSqlRepository = new UserSqlRepository(SqlDbContext);
        }
        [Fact]
        public UserSqlDto Add(UserSqlDto userSqlDto)
        {
            //Arrange

        }
        [Fact]
        public void GetTest()
        {
            //Arrange
            const short id = 1;

            //Action
            UserSqlDto? userSqlDto = UserSqlRepository.GetSingle(id);

            //Assert
            Assert.NotNull(userSqlDto);
            Assert.Equal(userSqlDto.UserId, id);
        }
    }
}