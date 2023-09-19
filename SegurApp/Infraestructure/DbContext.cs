using Microsoft.EntityFrameworkCore;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Infraestructure
{
    public class Context : DbContext
    {
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Segurapp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageUsers> MessagesUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(x => x.Role).WithMany(a => a.Users).HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<MessageUsers>(entity =>
            {
                entity.HasOne(x => x.Emisor).WithMany(a => a.MessageUsersEmisor).HasForeignKey(x => x.EmisorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Message).WithMany(a => a.MessageUsers).HasForeignKey(x => x.MessageId);
            });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Emisor",
                    Description = "Rol que enviará mensajes de alerta"
                },
                new Role
                {
                    Id = 2,
                    Name = "Receptor",
                    Description = "Rol que recibe mensajes de alerta"
                }
            );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   FullName = "Claudio Damico",
                   Email = "cdamico@gmail.com",
                   Phone = "1128341234",
                   Dni = "12345678",
                   RoleId = 1,
               },                
               new User
                {
                    Id = 2,
                    FullName = "Ciro Gargatagli",
                    Email = "ciroshaila@gmail.com",
                    Phone = "1125714153",
                    Dni = "12345679",
                    RoleId = 2,
                }
            );

            modelBuilder.Entity<Message>().HasData(
               new Message
               {
                   Id = 1,
                   Description = "Robo"
               },
               new Message
               {
                   Id = 2,
                   Description = "Sospechoso"
               },
               new Message
               {
                   Id = 3,
                   Description = "Alerta"
               },               
               new Message
                {
                    Id = 4,
                    Description = "Pelea"
                }
            );
        }
    }
}
