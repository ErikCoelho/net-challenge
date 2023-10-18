using ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.RemoveRoles;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidNameTooShort = new(Guid.NewGuid(), "Ad");
    private readonly Request _invalidNameTooLong = new(Guid.NewGuid(), "TestandoCriarUmRoleComTrintaCaracteres");
    private readonly Request _invalidUserNotFound = new(Guid.NewGuid(), "Admin");
    private readonly Request _invalidRoleNotFound = new(new Guid("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e"), "Usuario");
    private readonly Request _validRequest = new(Guid.NewGuid(), "User");
    private readonly Request _validRoleRemoved = new(new Guid("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e"), "Admin");
    #endregion

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Role_Name_Is_Too_Short()
    {
        var result = Specification.Validate(_invalidNameTooShort);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Role_Name_Is_Too_Long()
    {
        var result = Specification.Validate(_invalidNameTooLong);
        Assert.False(result.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_User_Id_Not_Found()
    {
        var result = await _handler.Handle(_invalidUserNotFound, new CancellationToken());
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_Role_Name_Not_Found()
    {
        var result = await _handler.Handle(_invalidRoleNotFound, new CancellationToken());
        Assert.False(result.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public void Should_Succeed_When_Request_Is_Valid()
    {
        var result = Specification.Validate(_validRequest);
        Assert.True(result.IsValid);
    }

    [Fact]
    public async void Should_Succeed_When_Role_Removed()
    {
        var result = await _handler.Handle(_validRoleRemoved, new CancellationToken());
        Assert.True(result.IsSuccess);
    }
    #endregion
}
