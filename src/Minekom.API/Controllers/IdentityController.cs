using Asp.Versioning;
using AutoMapper;
using Minekom.Domain.Bo;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minekom.API.Presenters;
using Minekom.API.Requests;
using Minekom.API.Presenters.Authentication;
using Minekom.Core.Requests.Authentication;
using Minekom.BackOfficeAPI.Requests;

namespace Minekom.API.Controllers
{
    /// <summary>
    /// Controller used to handle actions bound to authentication and users
    /// </summary>
    [ApiVersion("1")]
    public class IdentityController : BaseController
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="p_Logger"></param>
        /// <param name="p_Mediator"></param>
        /// <param name="p_ValidationPresenter"></param>
        public IdentityController(ILogger<IdentityController> p_Logger, IMediator p_Mediator, ValidationPresenter p_ValidationPresenter) 
            : base(p_Logger, p_Mediator, p_ValidationPresenter)
        {
        }

        /// <summary>
        /// Display user infos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult Get()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                m_Logger.LogInformation("User is logged");
                return Ok(new { User = User.Identity.Name, Claims = User.Claims.Select(p_C => new { p_C.Type, p_C.Value }) });
            }

            m_Logger.LogInformation("User is not authorized");
            return Unauthorized();
        }

        /// <summary>
        /// Login an existing user
        /// </summary>
        /// <param name="p_LoginRequest"></param>
        /// <param name="p_Validator"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginRequest p_LoginRequest, 
            [FromServices] LoginRequestValidator p_Validator, 
            [FromServices] JwtAuthenticationPresenter p_Presenter, 
            CancellationToken p_CancellationToken = default)
        {
            ValidationResult v_Result = await p_Validator.ValidateAsync(p_LoginRequest);

            if (!v_Result.IsValid)
            {
                m_ValidationPresenter.Handle(v_Result);
                return m_ValidationPresenter.ContentResult;
            }

            p_Presenter.Handle(await m_Mediator.Send(new JwtAuthenticationRequest(p_LoginRequest.Email, p_LoginRequest.Password), p_CancellationToken));

            return p_Presenter.ContentResult;
        }

        /// <summary>
        /// Create an account
        /// </summary>
        /// <param name="p_RegisterRequest"></param>
        /// <param name="p_Mapper"></param>
        /// <param name="p_Validator"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterRequest p_RegisterRequest, 
            [FromServices] IMapper p_Mapper, 
            [FromServices] RegisterRequestValidator p_Validator)
        {
            ValidationResult v_Result = await p_Validator.ValidateAsync(p_RegisterRequest);

            if (!v_Result.IsValid)
            {
                return BadRequest(v_Result.ToDictionary());
            }

            return Ok(await m_Mediator.Send(new RegistrationRequest(p_Mapper.Map<Utilisateur>(p_RegisterRequest))));
        }
    }
}