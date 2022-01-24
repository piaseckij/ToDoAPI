using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDoAPI.Entites;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }


    public class AccountService : IAccountService
    {
        private readonly ToDoDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(ToDoDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                Username = dto.Username,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.HashPassword = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
