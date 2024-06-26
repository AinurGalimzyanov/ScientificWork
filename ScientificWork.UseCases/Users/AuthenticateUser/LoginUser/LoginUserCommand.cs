﻿using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;

/// <summary>
/// Login user command.
/// </summary>
public record LoginUserCommand : IRequest<LoginUserCommandResult>
{
    /// <summary>
    /// Email.
    /// </summary>
    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    required public string Email { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    required public string Password { get; init; }
}
