using Microsoft.AspNetCore.Mvc;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        //User Add(string nombre, string apellido, string email, string telefono, string direccion);
        //User GetById(int UsuarioId);
        //User Delete(int UsuarioId);
        User GetById(int id);

    }
}
