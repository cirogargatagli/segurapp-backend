using Microsoft.IdentityModel.Tokens;
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

        public User CreateUser(string FullName, string Dni, string Email, string Phone, String Password)
        {
            return _userRepository.CreateUser(FullName, Dni, Email, Phone, Password);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(Domain.QueryParameters queryParameters)
        {
            if (queryParameters.Email.IsNullOrEmpty())
            {
                return _userRepository.GetById(queryParameters.Id);
            }

            return _userRepository.GetByParam(queryParameters);
        }
        
        public User LoginUser(string email, string password)
        {
            return _userRepository.GetLogin(email, password);
        }
    }
}
