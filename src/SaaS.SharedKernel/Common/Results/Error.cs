namespace SaaS.SharedKernel.Common.Results;

public class Error
{
    public string Code { get; }
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error NotFound(string message) =>
        new("not_found", message);

    public static Error Validation(string message) =>
        new("validation_error", message);

    public static Error Unauthorized(string message) =>
        new("unauthorized", message);
}