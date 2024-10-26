using MediatR;
using Microsoft.Extensions.Logging;
using Minekom.Core.Requests.Authentication;
using Minekom.Core.Requests.Tools;
using Minekom.Domain.Interfaces.Data.Entities;
using Minekom.Domain.Interfaces.Data;
using Minekom.Domain.Bo;
using BetD.Transverse.API.ErrorCodes;
using Minekom.Core.Responses.Authentication;
using Minekom.Core.Responses.Tools;
using Minekom.Core.Responses;

namespace Minekom.Core.UseCases.Authentication
{
    internal class RegistrationUseCase : AUseCase, IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly IMediator m_Mediator;

        public RegistrationUseCase(IUnitOfWork p_UnitOfWork, ILogger<RegistrationUseCase> p_Logger, IMediator p_Mediator) : base(p_UnitOfWork, p_Logger)
        {
            m_Mediator = p_Mediator;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await m_UnitOfWork.UserRepository.GetUserByEmailAsync(request.User.Email, cancellationToken) != null)
                    return new RegistrationResponse(new[] { new ErrorDto(CommonErrors.Authentication.Login.Duplicated, "Email duplicated") });

                HashResponse v_HashResponse = await m_Mediator.Send(new HashRequest(request.User.MotDePasse), cancellationToken);

                if (!v_HashResponse.Success) return new RegistrationResponse(v_HashResponse.Errors);

                request.User.MotDePasse = v_HashResponse.Value;

                IMappingAddEntity<Utilisateur, IEntity> v_UserMap = await m_UnitOfWork.UserRepository.CreateUserAsync(request.User, cancellationToken);

                m_UnitOfWork.Save();

                return new RegistrationResponse(v_UserMap.MapBoEntity);
            }
            catch (Exception v_Ex)
            {
                m_Logger.LogError(v_Ex, "An error was thrown");
                return new RegistrationResponse(new[] { v_Ex.ToError() });
            }
        }
    }
}
