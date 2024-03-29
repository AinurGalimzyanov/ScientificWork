namespace ScientificWork.UseCases.Users.AuthenticateUser;

/// <summary>
/// Shared constants for authentication.
/// </summary>
public static class AuthenticationConstants
{
    /// <summary>
    /// Name of login provider used to keep refresh token for ASP.NET Identity.
    /// </summary>
    public const string AppLoginProvider = "RefreshTokenProvider";

    /// <summary>
    /// Refresh token purpose name for ASP.NET Identity.
    /// </summary>
    public const string RefreshTokensName = "RefreshToken";

    /// <summary>
    /// Issued at date/time claim. https://tools.ietf.org/html/rfc7519#page-10 .
    /// </summary>
    public const string IatClaimType = "iat";

    /// <summary>
    /// Refresh token expiration time.
    /// </summary>
    public static readonly TimeSpan RefreshTokenExpire = TimeSpan.FromMinutes(2);

    /// <summary>
    /// Access token expiration time.
    /// </summary>
    public static readonly TimeSpan AccessTokenExpirationTime = -TimeSpan.FromMinutes(4);
}
