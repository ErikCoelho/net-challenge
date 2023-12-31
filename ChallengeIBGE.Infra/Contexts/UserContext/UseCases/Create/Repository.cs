﻿using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;
using ChallengeIBGE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) => _context = context;

    public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
    {
       return await _context
        .Users
        .AsNoTracking()
        .AnyAsync(x => x.Email.Address == email, cancellationToken: cancellationToken);
    }

    public Role? GetRoleByName(string role)
        => _context.Roles.FirstOrDefault(x => x.Name == role);

    public async Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async void SaveRole(Role userRole)
    {
        await _context.Roles.AddAsync(userRole);
        await _context.SaveChangesAsync();
    }
}