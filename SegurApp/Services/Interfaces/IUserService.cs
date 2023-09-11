using SegurApp.Infraestructure.Entities;

namespace SegurApp.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
    }
}
