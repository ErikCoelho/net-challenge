using ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.Authenticate;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidEmailRequest = new("contatobalta.io", "ABC123abc123");
    private readonly Request _invalidPasswordTooShort = new("contato@balta.io", "ABC123");
    private readonly Request _invalidPasswordTooLong = new("contato@balta.io", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{};:'\",.<>?/\\|~abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
    private readonly Request _invalidUserNotFound = new("balta@balta.io", "ABC123abc123");
    private readonly Request _invalidUserPasswordInvalid = new("contato@balta.io", "invalidpassword");
    private readonly Request _validAuthorization = new("contato@balta.io", "ABC123abc123");
    #endregion

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Request_Email_Is_Invalid()
    {
        var response = Specification.Validate(_invalidEmailRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Password_Is_Too_Short()
    {
        var response = Specification.Validate(_invalidPasswordTooShort);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Password_Is_Too_Long()
    {
        var response = Specification.Validate(_invalidPasswordTooLong);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_User_Not_Found()
    {
        var response = await _handler.Handle(_invalidUserNotFound, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_Password_Is_Invalid()
    {
        var response = await _handler.Handle(_invalidUserPasswordInvalid, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public async void Should_Succeed_When_User_Found_And_Password_Is_Valid()
    {
        var response = await _handler.Handle(_validAuthorization, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion 
}
