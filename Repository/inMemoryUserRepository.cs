public class inMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users;

    public inMemoryUserRepository(){
        _users = new List<User>
        {
            new User {Id = 1, Username = "Messi", Password = "contra123", AccessLevels = AccessLevels.Admin},
            new User {Id = 2, Username = "Colapinto", Password = "contra123", AccessLevels = AccessLevels.Admin},
            new User {Id = 2, Username = "Lecrerc", Password = "contra123", AccessLevels = AccessLevels.Empleado}
        };
    }
    public User GetUser(string username, string password){
        return _users.Where(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password,StringComparison.Ordinal)).FirstOrDefault();
    }
}
public interface IUserRepository{
    public User GetUser(string username, string password);
}