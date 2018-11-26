using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AuthRepository:IAuthRepository
    {
        private DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            try
            {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.SystemInsertTime = DateTime.Now;
            user.SystemUpdateTime = DateTime.Now;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string Email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Email == Email);
            if (user==null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public async Task<bool> UserExists(string Email)
        {
            if (await _context.User.AnyAsync(x=>x.Email == Email))
            {
                return true;
            }
            return false;
        }
    }
}
