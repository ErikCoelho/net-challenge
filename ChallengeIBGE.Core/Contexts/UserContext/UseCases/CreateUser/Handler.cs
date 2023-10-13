using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        try
        {
            var response = Specification.Validate(request);
            if (!response.IsValid)
                return new Response("Invalid Request", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate request.", 500);
        }
        #endregion

        #region Create User
        User? user;
        try
        {
            user = CreateUser(request);
        }
        catch
        {
            return new Response("Failed to create a new user.", 500);
        }
        #endregion

        #region Verify User Existence
        try
        {
            var exists = await _repository.AnyAsync(request.Email, cancellationToken);
            if (exists)
                return new Response("Email already exists", 400);
        }
        catch
        {
            return new Response("Unable to verify existence.", 500);
        }
        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Failed to persist data.", 500);
        }
        #endregion

        #region Response
        return new Response("User created successfully.", new ResponseData(user.Id, user.Name.FirstName, user.Email.Address));
        #endregion
    }

    public User CreateUser(Request request)
    {
        User user = new(request.FirstName, request.LastName, request.Email, request.Password);
        return user;
    }
}
