using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Account;

public interface IAuthenticate
{
    public string GenerateToken(int id, string email);
    Task<Usuario> GetUsuarioByEmail(string email);
    Task<bool> UserExists(string email);
}
