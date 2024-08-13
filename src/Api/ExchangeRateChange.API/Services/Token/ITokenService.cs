using ExchangeRateChange.Common.ViewModels;

namespace ExchangeRateChange.API.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponseDto> GenerateJwtToken(LoginUserViewModel dto);
    }
}