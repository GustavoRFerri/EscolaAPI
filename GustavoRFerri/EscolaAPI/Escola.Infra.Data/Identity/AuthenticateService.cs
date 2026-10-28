using Escola.Domain.Account;
using Escola.Domain.Entities;
using Escola.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Escola.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;  
        }

        public string GenerateToken(int id, string email)
        {
            throw new NotImplementedException();
        }

        //public string GenerateToken(int id, string email, string role)
        //{
        //    var claims = new[]
        //    {
        //        new Claim("id", id.ToString()),
        //        new Claim("id", email.ToLower()),
        //        new Claim(ClaimTypes.Role, "User"),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    };

        //    var primaryKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        //}

        public Task<Usuario> GetUsuarioByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
