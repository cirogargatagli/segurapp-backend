using SegurApp.Infraestructure.Entities;
using SegurApp.Repository.Interfaces;
using SegurApp.Services.Interfaces;

namespace SegurApp.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
