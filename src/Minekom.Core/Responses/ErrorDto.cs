using System.Text.Json.Serialization;

namespace Minekom.Core.Responses
{
    public record ErrorDto(string Code,
        string Description,
        [property: JsonIgnore]
        Exception Exception = null
    );
}