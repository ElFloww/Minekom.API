using Minekom.Core.Requests.Authentication;
using Minekom.Core.Requests.Tools;
using Minekom.Core.Responses;
using Minekom.Core.Responses.Authentication;
using Minekom.Core.Responses.Tools;
using Minekom.Domain.Bo;
using Minekom.Domain.Interfaces.Data;
using Minekom.Domain.Interfaces.Token;
using Minekom.Domain.Token;
using BetD.Transverse.API.ErrorCodes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Minekom.Core.UseCases.Authentication;

internal class JwtAuthenticationUseCase : AUseCase, IRequestHandler<JwtAuthenticationRequest, JwtAuthenticationResponse>
{
    private readonly IJwtFactory m_JwtFactory;
    private readonly IMediator m_Mediator;

    public JwtAuthenticationUseCase(IUnitOfWork p_UnitOfWork, ILogger<JwtAuthenticationUseCase> p_Logger, IJwtFactory p_JwtFactory, IMediator p_Mediator) : base(p_UnitOfWork, p_Logger)
    {
        m_JwtFactory = p_JwtFactory;
        m_Mediator = p_Mediator;
    }

    public async Task<JwtAuthenticationResponse> Handle(JwtAuthenticationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Utilisateur v_User = await m_UnitOfWork.UserRepository.GetUserByEmailAsync(request.Login, cancellationToken);

            HashResponse v_HashResponse = await m_Mediator.Send(new HashRequest(request.Password), cancellationToken);

            // Forward errors if any
            if (!v_HashResponse.Success) return new JwtAuthenticationResponse(v_HashResponse.Errors);

            if (v_User is null || v_User.MotDePasse != v_HashResponse.Value)
                return new JwtAuthenticationResponse(new[] { new ErrorDto(CommonErrors.Authentication.Missmatch, "Invalid login and/or password") });

            JwtTokenResponse v_TokenInfos = m_JwtFactory.CreateToken(v_User);

            return new JwtAuthenticationResponse(new UserToken
            {
                Token = v_TokenInfos,
                User = v_User
            });
        }
        catch (Exception v_Ex)
        {
            m_Logger.LogError(v_Ex, "An error was thrown");
            return new JwtAuthenticationResponse(new[] { v_Ex.ToError() });
        }
    }
}