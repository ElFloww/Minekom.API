using BetD.Transverse.API.ErrorCodes;
using FluentValidation;

namespace Minekom.API.Requests
{
    /// <summary>
    /// Request for login action
    /// </summary>
    public record LoginRequest
    {
        /// <summary>
        /// Email (login) of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// Validator for login request
    /// </summary>
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        /// <summary>
        /// ctor containing validation rules
        /// </summary>
        public LoginRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty().WithErrorCode(CommonErrors.Authentication.Login.Empty)
                .EmailAddress().WithErrorCode(CommonErrors.Authentication.Login.InvalidEmail);
            RuleFor(m => m.Password)
                .NotEmpty().WithErrorCode(CommonErrors.Authentication.Password.Empty)
                .MinimumLength(8).WithErrorCode(CommonErrors.Authentication.Password.InvalidLength)
                .Matches("[A-Z]+").WithErrorCode(CommonErrors.Authentication.Password.InvalidUppercase)
                .Matches("[a-z]+").WithErrorCode(CommonErrors.Authentication.Password.InvalidLowercase)
                .Matches("[0-9]+").WithErrorCode(CommonErrors.Authentication.Password.InvalidNumber);
        }
    }
}