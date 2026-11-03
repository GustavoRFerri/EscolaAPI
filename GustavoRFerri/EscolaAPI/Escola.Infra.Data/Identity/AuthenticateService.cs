using Escola.Domain.Account;
using Escola.Domain.Entities;
using Escola.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var usuario = await  _context.Usuario.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (usuario == null || usuario.Excluido)            
                return false;

            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.PasswordHash[i])
                    return false;
            }
            return true;
        }

        public string GenerateToken(int id, string email, string role)
        {

            //var secretKey = _configuration["Jwt:SecretKey"];

            //if (string.IsNullOrWhiteSpace(secretKey))
            //{
            //    throw new InvalidOperationException(
            //        "Jwt:SecretKey não foi configurada.");
            //}

            //var keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!);

            //if (keyBytes.Length < 32)
            //{
            //    throw new InvalidOperationException(
            //        "A chave JWT deve possuir pelo menos 32 bytes.");
            //}

            //var claims = new[]
            //{
            //    new Claim("id", id.ToString()),
            //    new Claim(ClaimTypes.Email, email.ToLowerInvariant()),
            //    new Claim(ClaimTypes.Role, role),
            //    new Claim(
            //        JwtRegisteredClaimNames.Jti,
            //        Guid.NewGuid().ToString())
            //};

            //var privateKey = new SymmetricSecurityKey(keyBytes);

            //var credentials = new SigningCredentials(
            //    privateKey,
            //    SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(
            //    issuer: _configuration["Jwt:Issuer"],
            //    audience: _configuration["Jwt:Audience"],
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddHours(1),
            //    signingCredentials: credentials
            //);

            //return new JwtSecurityTokenHandler().WriteToken(token);

            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("id", email.ToLower()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        public Task<Usuario> GetUsuarioByEmail(string email)
        {
            return _context.Usuario.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
