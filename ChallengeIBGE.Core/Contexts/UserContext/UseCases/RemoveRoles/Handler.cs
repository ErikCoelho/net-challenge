using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles;

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
                return new Response("Invalid Request", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate request", 500);
        }
        #endregion

        #region Remove Role from User
        try
        {
            await _repository.RemoveRoleFromEmployeeAsync(request.UserId, request.Role, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Response
        return new Response("Role sucessfully removed from user", new ResponseData(request.UserId, request.Role));
        #endregion
    }
}
