using Microsoft.AspNetCore.Identity;

namespace ScientificWork.Domain.Users;

/// <summary>
/// Custom application identity role.
/// </summary>
public class AppIdentityRole : IdentityRole<Guid>
{
    public AppIdentityRole(string name)
        : base(name)
    {
    }
}
