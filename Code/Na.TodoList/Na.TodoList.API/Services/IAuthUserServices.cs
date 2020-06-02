using Na.TodoList.Domain;

namespace Na.TodoList.API.Services
{
    public interface IAuthUserServices
    {
        void CreateToken(AppUser userInfo);
    }
}
