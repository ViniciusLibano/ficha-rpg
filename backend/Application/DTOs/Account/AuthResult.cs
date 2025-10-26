namespace RpgApi.Application.DTOs.Account;

public class AuthResult
{
    public bool Succeeded { get; set; }
    public AuthResponse? Response { get; set; }
    public IEnumerable<string> Errors { get; set; }
    
    public static AuthResult Success(AuthResponse response) =>
        new() { Succeeded = true, Response = response };
    
    public static AuthResult Failure(IEnumerable<string> errors) => 
        new() { Succeeded = false, Errors = errors };
    
    public static AuthResult Failure(string error) => 
        new() { Succeeded = false, Errors = [error] };
}