namespace OnlineStore.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(IUser user);
        IUser? GetUserByUsername(string username);
    }
}
