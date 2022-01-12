using poec.sql.dtos;

namespace poec.fake.repository;

public class UserFakeRepository
{
    private IList<UserSqlDto> Users { get; } = new List<UserSqlDto>();
    private IDictionary<short, UserSqlDto> KeyUsers { get; }

    public UserFakeRepository()
    {
        Users.Add(new UserSqlDto(1, "Alex", "Lelexxx", new DateTime(1990, 10, 30, 2, 55, 0)));
        Users.Add(new UserSqlDto(2, "Toto", null, new DateTime(2000, 9, 4, 5, 0, 0)));
        Users.Add(new UserSqlDto(3, "Titi", "Tit", new DateTime(2000, 11, 1, 18, 32, 20)));
        Users.Add(new UserSqlDto(4, "Tutu", null, new DateTime(2000, 9, 4, 5, 1, 0)));

        KeyUsers = Users.ToDictionary(userSqlDto => userSqlDto.UserId, GetUserSqlDto);
        //équivalent à KeyUsers = Users.ToDictionary(userSqlDto => userSqlDto.UserId, GetUserSqlDto);
        //foreach (UserSqlDto userSqlDto in Users)
        //{
        //    IdUsers.Add(userSqlDto.UserId, userSqlDto);
        //}

        Users = KeyUsers.Values.ToList();
    }

    //équivalent à userSqlDto => userSqlDto.UserName + userSqlDto.UserId
    //private static string GetKeyUserSqlDto(UserSqlDto userSqlDto)
    //{
    //    return userSqlDto.UserName + userSqlDto.UserId;
    //}

    private static UserSqlDto GetUserSqlDto(UserSqlDto userSqlDto)
    {
        return userSqlDto;
    }

    #region CRUD

    public UserSqlDto? Add(UserSqlDto userSqlDto)
    {
        throw new NotImplementedException();
    }

    public UserSqlDto? GetFirst(short id)
    {
        return Users.FirstOrDefault(user => user.UserId == id);
        
        //équivalent avec le dictionnaire
        //return KeyUsers.FirstOrDefault(ku => ku.Value.UserId == id).Value;

        //équivalent à return Users.FirstOrDefault(user => user.UserId == id);
        //foreach (UserSqlDto userSqlDto in Users)
        //{
        //    if (userSqlDto.UserId == id)
        //        return userSqlDto;
        //}

        //return null;
    }

    //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/
    /// <summary>
    /// Récupère le seul élément qui a pour id le paramètre passé
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <returns></returns>
    public UserSqlDto? GetSingle(short id)
    {
        return Users.SingleOrDefault(user => user.UserId == id);

        //équivalent dictionnaire
        //return KeyUsers[id];

        //équivalent à return Users.SingleOrDefault(user => user.UserId == id);
        //UserSqlDto? user = null;
        //foreach (UserSqlDto userSqlDto in Users)
        //{
        //    if (userSqlDto.UserId == id)
        //    {
        //        if (user == null)
        //            user = userSqlDto;
        //        else
        //            throw new InvalidOperationException("Multiple instance");
        //    }
        //}

        //return user;
    }

    public IList<UserSqlDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public IList<UserSqlDto> GetPredicate(Func<UserSqlDto, bool> predicate)
    {
        return Users.Where(predicate).ToList();
    }

    public UserSqlDto? Update(UserSqlDto userSqlDto)
    {
        throw new NotImplementedException();
    }

    public bool Delete(short id)
    {
        throw new NotImplementedException();
    }

    #endregion

    public IList<UserSqlDto> GetBestUsers()
    {
        return Users.Where(user => user.Birthday.Year == 1990).ToList();

        //équivalent à
        //return (from user in Users
        //        where user.Birthday.Year == 1990
        //        select user).ToList();
    }

    public TimeSpan GetOlderAge()
    {
        return Users.Max(user => DateTime.Now - user.Birthday);
    }
}