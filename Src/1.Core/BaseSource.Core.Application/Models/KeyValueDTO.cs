using BaseSource.Core.Application.Common.Models;

namespace BaseSource.Core.Application.Models;

public record KeyValueDTO(string Key,string Value);


public class UserProfileDTO : BaseDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string DisplayName { get => $"{Name} {Family}"; }
}

public class AuthResponse
{
    public string RefreshToken { get; set; }
    public string Token { get; set; }
    public UserProfileDTO User { get; set; }
    public DateTime ExpiresIn { get; set; }
}