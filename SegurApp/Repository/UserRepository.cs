using SegurApp.Infraestructure;
using SegurApp.Infraestructure.Entities;
using SegurApp.Repository.Interfaces;

namespace SegurApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Find<User>(id);//_context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public User GetByParam(Domain.QueryParameters queryParameters)
        {
            return _context.Users.Where(x => (x.Id == null || x.Id == queryParameters.Id) && 
                                             (x.Email == null || x.Email == queryParameters.Email)).FirstOrDefault();
        }

        public User CreateUser(string FullName, string Dni, string Email, string Phone, String Password)
        {
            User user = new User()
            {
                FullName = FullName,
                Dni = Dni,
                Email = Email,
                Phone = Phone,
                Password = Password,
                RoleId = 1
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    
        public User GetLogin(string email, string password)
        {
            return _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
