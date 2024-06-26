namespace ScientificWork.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Logged user accessor routines.
/// </summary>
public interface ILoggedUserAccessor
{
    Guid? UserId { get; set; }

    /// <summary>
    /// Get current logged user identifier.
    /// </summary>
    /// <returns>Current user identifier.</returns>
    Guid GetCurrentUserId();

    /// <summary>
    /// Return true if there is any user authenticated.
    /// </summary>
    /// <returns>Returns <c>true</c> if there is authenticated user.</returns>
    bool IsAuthenticated();
}
