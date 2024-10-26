namespace BetD.Transverse.API.ErrorCodes
{
    public static class CommonErrors
    {
        private const string COMMON_PREFIX = "common.";

        public const string UnknowError = COMMON_PREFIX + "unknown-error";

        public static class Authentication
        {
            private const string AUTHENT_PREFIX = COMMON_PREFIX + "authentication.";

            public const string Missmatch = AUTHENT_PREFIX + "missmatch";

            public static class Login
            {
                private const string LOGIN_PREFIX = AUTHENT_PREFIX + "login.";

                public const string Empty = LOGIN_PREFIX + GeneralErrors.Empty;
                public const string InvalidEmail = LOGIN_PREFIX + GeneralErrors.InvalidFormat.InvalidEmail;
                public const string Duplicated = LOGIN_PREFIX + GeneralErrors.Duplicated;
                public const string NotExist = LOGIN_PREFIX + GeneralErrors.NotExist;
            }

            public static class Password
            {
                private const string PASSWORD_PREFIX = AUTHENT_PREFIX + "password.";

                public const string Empty = PASSWORD_PREFIX + GeneralErrors.Empty;
                public const string InvalidLength = PASSWORD_PREFIX + GeneralErrors.InvalidFormat.InvalidLength;
                public const string InvalidUppercase = PASSWORD_PREFIX + GeneralErrors.InvalidFormat.InvalidUppercase;
                public const string InvalidLowercase = PASSWORD_PREFIX + GeneralErrors.InvalidFormat.InvalidLowercase;
                public const string InvalidNumber = PASSWORD_PREFIX + GeneralErrors.InvalidFormat.InvalidNumber;
            }
        }

        public static class User
        {
            private const string USER_PREFIX = COMMON_PREFIX + "user.";

            public static class FirstName
            {
                private const string FIRSTNAME_PREFIX = USER_PREFIX + "firstname.";

                public const string Empty = FIRSTNAME_PREFIX + GeneralErrors.Empty;
            }

            public static class LastName
            {
                private const string LASTNAME_PREFIX = USER_PREFIX + "lastname.";

                public const string Empty = LASTNAME_PREFIX + GeneralErrors.Empty;
            }
        }

        public static class Data
        {
            private const string DATA_PREFIX = COMMON_PREFIX + "data.";

            public const string NotFound = DATA_PREFIX + "notfound";

            public const string AlreadyExist = DATA_PREFIX + "alreadyexist";

            public const string IsNull = DATA_PREFIX + "isnull";
        }

        public static class Email
        {
            private const string EMAIL_PREFIX = COMMON_PREFIX + "email.";

            public const string NotSent = EMAIL_PREFIX + "notsent";
        }

        public static class ResetPassword
        {
            private const string RESETPASSWORD_PREFIX = COMMON_PREFIX + "resetpassword.";

            public const string Expired = RESETPASSWORD_PREFIX + "expired";

            public const string InvalidCode = RESETPASSWORD_PREFIX + "invalidcode";

            public const string InvalidUser = RESETPASSWORD_PREFIX + "invaliduser";
        }

        public static class Hash
        {
            private const string HASH_PREFIX = COMMON_PREFIX + "hash.";

            public const string Error = HASH_PREFIX + "error";
        }

        public static class Convertion
        {
            private const string CONVERTION_PREFIX = COMMON_PREFIX + "conversion.";

            public static class ToInt
            {
                private const string TOINT = CONVERTION_PREFIX + "toint.";

                public const string Error = TOINT + "error";
            }
        }
    }

    internal static class GeneralErrors
    {
        public const string Empty = "empty";
        public const string Duplicated = "duplicated";
        public const string NotExist = "not-exist";

        public static class InvalidFormat
        {
            public const string InvalidEmail = "invalid-email";
            public const string InvalidLength = "invalid-length";
            public const string InvalidUppercase = "invalid-uppercase";
            public const string InvalidLowercase = "invalid-lowercase";
            public const string InvalidNumber = "invalid-number";
        }
    }
}