namespace Minekom.Domain.Errors
{
    public static class DomainErrors
    {
        private const string DOMAIN_PREFIX = "minekom.";

        public const string UnknowError = DOMAIN_PREFIX + "unknown-error";
    }

    internal static class GeneralErrors
    {
        public const string Empty = "empty";
        public const string Duplicated = "duplicated";

        public static class InvalidFormat
        {
        }
    }
}