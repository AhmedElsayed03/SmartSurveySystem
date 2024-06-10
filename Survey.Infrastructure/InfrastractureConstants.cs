using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure
{
    public static class InfrastractureConstants
    {
        public static class ErrorMessages
        {
            public const string EmailExists = "EmailExists";
            public const string RegistrationFailed = "RegistrationFailed";
            public const string IncorrectCredentials = "Email/Password are incorrect";
            public const string EmailConfirmationFailed = "EmailConfirmationFailed";
            public const string UserNotFound = "UserNotFound";
            public const string ResetPasswordFailed = "ResetPasswordFailed";
            public const string RoleNotFound = "RoleNotFound";
            public const string AddingUserToRoleFailed = "AddingUserToRoleFailed";
            public const string RemovingFromRoleFailed = "RemovingFromRoleFailed";
            public const string RoleExists = "RoleExists";
        }

        public static class EmailContent
        {
            public const string EmailConfirmationSubject = "EmailConfirmationSubject";
            public const string EmailConfirmationBody = "EmailConfirmationBody";
            public const string ResetPasswordSubject = "ResetPasswordSubject";
            public const string ResetPasswordBody = "ResetPasswordBody";
        }

        public static class Endpoints
        {
            public const string ConfirmEmail = "api/auth/confirm-email";
            public const string ResetPassword = "api/auth/reset-password";
        }

        public static class QueryStrings
        {
            public static string ConfirmEmail(Guid userId, string code)
                => $"userId={userId}&code={Uri.EscapeDataString(code)}";
            public static string ResetPassword(Guid userId, string code)
                => $"userId={userId}&code={Uri.EscapeDataString(code)}";
        }

        public static class AppSettings
        {
            public const string StoragePath = "StoragePath";
        }
    }
}
