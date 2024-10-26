using Minekom.Core.Responses.Tools;
using MediatR;

namespace Minekom.Core.Requests.Tools;

public class HashRequest : IRequest<HashResponse>
{
    public string Value { get; }

    public HashRequest(string p_Value)
    {
        Value = p_Value;
    }
}