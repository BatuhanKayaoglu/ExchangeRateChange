﻿using ExchangeRateChange.API.Extensions.JwtConf;
using Microsoft.IdentityModel.Tokens;
using ExchangeRateChange.Common.ResponseViewModel;
using ExchangeRateChange.Common.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ExchangeRateChange.API.Services.Token
{
    public class TokenService : ITokenService
    {
        public async Task<TokenResponseDto> GenerateJwtToken(LoginUserViewModel dto)
        {
            Claim[] claims = new Claim[]
           {
                     new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()),
                     new Claim(ClaimTypes.GivenName,dto.NameSurname),
           };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTime expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // RefreshToken
            byte[] numbers = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(numbers);
            var refreshToken = Convert.ToBase64String(numbers);

            var accessToken = handler.WriteToken(jwtSecurityToken);

            return new TokenResponseDto(accessToken, expireDate, refreshToken);
        }
    }
}
