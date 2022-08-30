namespace CopyNotionApi3.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CopyNotionApi3.Models.Users;
using CopyNotionApi3.Services;
using CopyNotionApi3.Entities;


[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IJWTManager jWTManager;
    private ITokenService _tokenService;

    public AuthController (IJWTManager jWTManager, ITokenService tokenService)
    {
        this.jWTManager = jWTManager;
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginRequest user)
    {
        bool validUser = _tokenService.IsValidUser(user);

        if (!validUser)
            return Unauthorized("Incorrect username or password!");

        var token = jWTManager.GenerateToken(user.Email);

        if (token == null)
            return Unauthorized("Invalid Attempt!");

        // saving refresh token to the db
        UserRefreshTokens obj = new UserRefreshTokens
        {
            RefreshToken = token.Refresh_Token,
            Email = user.Email
        };
        Console.WriteLine(obj.RefreshToken);
        Console.WriteLine(obj.Email);

        _tokenService.AddUserRefreshTokens(obj);
        _tokenService.SaveCommit();
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh(Tokens token)
    {
        var principal = jWTManager.GetPrincipalFromExpiredToken(token.Access_Token);
        var email = principal.Identity?.Name;

        //retrieve the saved refresh token from database
        var savedRefreshToken = _tokenService.GetSavedRefreshTokens(email, token.Refresh_Token);

        if (savedRefreshToken.RefreshToken != token.Refresh_Token)
        {
            return Unauthorized("Invalid attempt!");
        }

        var newJwtToken = jWTManager.GenerateRefreshToken(email);

        if (newJwtToken == null)
        {
            return Unauthorized("Invalid attempt!");
        }

        // saving refresh token to the db
        UserRefreshTokens obj = new UserRefreshTokens
        {
            RefreshToken = newJwtToken.Refresh_Token,
            Email = email
        };

        _tokenService.DeleteUserRefreshTokens(email, token.Refresh_Token);
        _tokenService.AddUserRefreshTokens(obj);
        _tokenService.SaveCommit();

        return Ok(newJwtToken);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("revoke")]
    public IActionResult RevokeToken (UserRefreshTokens user)
    {
        _tokenService.DeleteUserRefreshTokens(user.Email, user.RefreshToken);
        return Ok( new { message = "Revoke token done!" });
    }
}
