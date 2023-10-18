using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate.Contracts;
using ChallengeIBGE.Core.Contexts.UserContext.ValueObjects;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate;

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

        #region Get User
        User? user;
        try
        {
            user = await _repository.GetUserByEmailAsync(request.Email.ToLower(), cancellationToken);
            if (user is null)
                return new Response("User not found.", 404);
        }
        catch
        {
            return new Response("Failed to retrieve User.", 500);
        }
        #endregion

        #region Verify Password
            if (!user.Password.VerifyHash(request.Password))
                return new Response("Email or Password invalid", 400);
        #endregion

        #region Return Authentication Data
        try
        {
            return new Response("", new ResponseData
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Roles = user.Roles.Select(role => role.Name).ToArray()
            });
        }
        catch
        {
            return new Response("Failed to check user", 500);
        }
        #endregion
    }
}
