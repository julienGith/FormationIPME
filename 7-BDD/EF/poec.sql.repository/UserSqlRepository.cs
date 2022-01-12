using poec.sql.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poec.sql.repository
{
    public class UserSqlRepository
    {
        private SqlDbContext SqlContext { get; }
        public UserSqlDto Add(UserSqlDto userSqlDto)
        {
            SqlContext.Add(userSqlDto);
        }
        public UserSqlRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public IList<UserSqlDto> GetBestUsers()
        {
            throw new NotImplementedException();
        }

        public TimeSpan GetOlderAge()
        {
            throw new NotImplementedException();
        }

        public UserSqlDto? GetSingle(short id)
        {
            return SqlContext.Set<UserSqlDto>().SingleOrDefault(u=>u.UserId== id);
        }
    }
}
