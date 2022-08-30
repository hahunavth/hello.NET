using BCrypt.Net;
using CopyNotionApi3.Entities;
using CopyNotionApi3.Helpers;
using CopyNotionApi3.Models.Users;

namespace CopyNotionApi3.Services;

public interface ITokenService
{
	bool IsValidUser(LoginRequest user);
	UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);
	UserRefreshTokens GetSavedRefreshTokens(string email, string refreshtoken);
	void DeleteUserRefreshTokens(string email, string refreshToken);
	int SaveCommit();
}

public class TokenService : ITokenService
{
	private readonly DataContext _context;

	public TokenService(DataContext dataContext)
    {
        _context = dataContext;
    }

    public bool IsValidUser(LoginRequest model)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);

        Console.WriteLine("user: " + model.Email);

        if (user == null) return false;

        if (BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return true;

        return false;
    }

    public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
    {
        _context.UserRefreshToken.Add(user);
        return user;
    }

    public void DeleteUserRefreshTokens(string email, string refreshToken)
    {
        var item = _context.UserRefreshToken.FirstOrDefault(x => x.Email == email && x.RefreshToken == refreshToken);
        if (item != null)
            _context.UserRefreshToken.Remove(item);
    }

    public UserRefreshTokens GetSavedRefreshTokens(string email, string refreshToken)
    {
        return _context.UserRefreshToken.FirstOrDefault(x => x.Email == email && x.RefreshToken == refreshToken && x.IsActive == true);
    }

    public int SaveCommit()
    {
        return _context.SaveChanges();
    }
}
