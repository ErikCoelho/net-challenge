using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    public Handler(IRepository repository)
        => _repository = repository;
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        try
        {
            var response = Specification.Validate(request);
            if (!response.IsValid)
                return new Response("Request Invalid", 400, response.Notifications);
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
            user = await _repository.GetUserById(request.Id, cancellationToken);
        }
        catch
        {
            return new Response("Unable to retrieve user.", 500);
        }
        #endregion

        #region Delete User
        try
        {
            await _repository.DeleteUserAsync(user, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Response
        return new Response("User deleted successfully.", new ResponseData(request.Id));
        #endregion
    }
}
