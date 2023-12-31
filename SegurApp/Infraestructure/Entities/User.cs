﻿using System.ComponentModel.DataAnnotations;

namespace SegurApp.Infraestructure.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Dni {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<MessageUsers> MessageUsersEmisor { get; set; }
        //public ICollection<MessageUsers> MessageUsersReceptor { get; set; }
    }
}
