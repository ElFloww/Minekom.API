using Minekom.Core.Requests.Tools;
using Minekom.Core.Responses.Tools;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace Minekom.Core.UseCases.Tools;

internal class HashUseCase : IRequestHandler<HashRequest, HashResponse>
{
    private readonly ILogger<HashUseCase> m_Logger;

    public HashUseCase(ILogger<HashUseCase> p_Logger)
    {
        m_Logger = p_Logger;
    }

    public Task<HashResponse> Handle(HashRequest request, CancellationToken cancellationToken)
    {
        try
        {
            byte[] v_Message = Encoding.UTF8.GetBytes(request.Value);
            using SHA512 v_Alg = SHA512.Create();
            StringBuilder v_Hex = new();

            foreach (byte v_X in v_Alg.ComputeHash(v_Message))
            {
                v_Hex.AppendFormat("{0:x2}", v_X);
            }

            return Task.FromResult(new HashResponse(v_Hex.ToString()));
        }
        catch (Exception v_Ex)
        {
            m_Logger.LogError(v_Ex, "An error was thrown");
            return Task.FromResult(new HashResponse(new[] { v_Ex.ToError() }));
        }
    }
}