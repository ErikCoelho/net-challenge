using ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.DeleteUser;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidUserNotFound = new(new Guid("5d7b0d5b-aa83-500f-0f70-d7cab1e34c3f"));
    private readonly Request _validRequest = new(Guid.NewGuid());
    private readonly Request _validRequestUserFound = new(new Guid("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e"));
    #endregion

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public async void Should_Fail_When_User_Not_Found()
    {
        var response = await _handler.Handle(_invalidUserNotFound, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public void Should_Succeed_When_Request_Is_Valid()
    {
        var response = Specification.Validate(_validRequest);
        Assert.True(response.IsValid);
    }

    [Fact]
    public async void Should_Succeed_When_User_Found()
    {
        var response = await _handler.Handle(_validRequestUserFound, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
