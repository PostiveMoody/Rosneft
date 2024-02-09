namespace Rosneft.WebApplication
{
    public static class Errors
    {
        public static class NotFound
        {
            public static readonly string Code = "NotFound";
            public static readonly string Message = "{0} with id '{1}' not found.";
        }

        public static class BadRequest
        {
            public static readonly string Code = "BadRequest";
            public static readonly string Message = "BadRequest";
        }

        public static class Unauthorized
        {
            public static readonly string Code = "Unauthorized";
            public static readonly string Message = "There are no enough permissions (required operation is {0})";

            public static string GetMessage(string operation)
                    => string.Format(Message, operation);
        }

        public static class TechError
        {
            public static readonly string Code = "TechError";
            public static readonly string Message = "Technical error";
        }

        public static class BadFilterExpression
        {
            public static readonly string Code = "BadFilterExpression";
            public static readonly string Message = "Filter expression '{0}' is bad. See internal errors.";
        }

        public static class InternalExpression
        {
            public static readonly string Code = "InternalExpression";
        }

        public static class PropertyNameBadExpression
        {
            public static readonly string Code = "PropertyNameBadExpression";
            public static readonly string Message = "Property '{0}' is not supported. Only property '{1}' is supported.";
        }

        public static class CollectionStringConstBadExpression
        {
            public static readonly string Code = "CollectionStringConstBadExpression";
            public static readonly string Message = "Value {0} is not string.";
        }

        public static class CollectionLongConstBadExpression
        {
            public static readonly string Code = "CollectionLongConstBadExpression";
            public static readonly string Message = "Value {0} is not long integer.";
        }

        public static class NotSupportedExpression
        {
            public static readonly string Code = "NotSupportedExpression";
            public static readonly string Message = "'{0}' expression is not supported.";
        }

        public static class BinaryOperatorKindBadExpression
        {
            public static readonly string Code = "BinaryOperatorKindBadExpression";
            public static readonly string Message = "'{0}' operator is not supported. Only '{1}' operator is supported.";
        }

        public static class StringConstBadExpression
        {
            public static readonly string Code = "StringConstBadExpression";
            public static readonly string Message = "Value {0} is not string.";
        }

        public static class BoolConstBadExpression
        {
            public static readonly string Code = "BoolConstBadExpression";
            public static readonly string Message = "Value {0} is not boolean.";
        }

        public static class LongConstBadExpression
        {
            public static readonly string Code = "LongConstBadExpression";
            public static readonly string Message = "Value {0} is not long integer.";
        }

        public static class IntConstBadExpression
        {
            public static readonly string Code = "IntConstBadExpression";
            public static readonly string Message = "Value {0} is not integer.";
        }

        public static class DomainError
        {
            public static readonly string Code = "DomainError";
            public static readonly string Message = "Domain error";
        }

        public static class UserRegistrationError
        {
            public static readonly string Code = "UserNotRegistered";
        }
    }
}
