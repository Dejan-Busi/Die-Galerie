using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ITokenGenerator
    {
        string CreateAccessToken(User user);

        string CreateRefreshToken();
    }
}

