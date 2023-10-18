using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser;

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
                return new Response("Request invalid.", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate request.", 500);
        }
        #endregion

        #region Get User by Id
        User? user;
        try
        {
            user = await _repository.GetUserById(request.Id, cancellationToken);
            if (user is null)
                return new Response("User not found.", 404);
        }
        catch
        {
            return new Response("Unable to retireve user", 500);
        }
        #endregion

        #region Update User
        try
        {
            UpdateUser(user, request);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Failed to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("User updated successfully", new ResponseData(user.Id, user.Name.FirstName, user.Email.Address));
        #endregion
    }

    private static void UpdateUser(User user, Request request)
    {
        user.UpdateName(request.UpdatedFirstName, request.UpdatedLastName);
        user.UpdateEmail(request.UpdatedEmail.ToLower());
    }
}
