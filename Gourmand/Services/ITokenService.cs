﻿namespace Gourmand.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
