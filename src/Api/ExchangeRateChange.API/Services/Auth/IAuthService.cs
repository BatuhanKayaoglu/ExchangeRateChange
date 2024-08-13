using Microsoft.AspNetCore.Identity;
using ExchangeRateChange.Common.ResponseViewModel;
using ExchangeRateChange.Common.ViewModels;
using ExchangeRateChange.Entity.Models.Identity;

namespace ExchangeRateChange.API.Services.Auth
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(CreateUserResponseViewModel user);
        Task<LoginUserViewModel> Login(LoginUserResponseViewModel customer);
        Task<IdentityResult> LogOut(string email);

        Task GenerateConfirmEmailTokenAndSendMail(string email);
        Task<IdentityResult> ConfirmEmail(string email, string token);
        Task<IdentityResult> ChangePassword(ChangePasswordViewModel changePassModel);
        Task ForgotPassword(string email);
        Task<IdentityResult> ResetPassword(string email, string token, string newPassword);
        Task<bool> IsTwoFactorEnabled(string email);
        Task GenerateTwoFactorToken(string email);
        Task<SignInResult> LoginWith2FA(string code);
    }
}