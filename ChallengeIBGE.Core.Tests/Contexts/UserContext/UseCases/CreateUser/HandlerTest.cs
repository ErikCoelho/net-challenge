using ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.CreateUser;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidFirstNameTooShortRequest = new("An", "Baltieri", "contato@balta.io");
    private readonly Request _invalidFirstNameTooLargeRequest = new("Testandoumnomemuitograndecommuitosdigitos", "Baltieri", "contato@balta.io");
    private readonly Request _invalidLastNameTooShortRequest = new("André", "Ba", "contato@balta.io");
    private readonly Request _invalidLastNameTooLargeRequest = new("André", "Testandoumsobrenomemuitograndequetenhaacimadeoitentadigitosparaostestesdeunidadesobrenome", "contato@balta.io");
    private readonly Request _invalidEmailRequest = new("André", "Baltieri", "contatobalta.io");
    private readonly Request _invalidPasswordTooShortRequest = new("André", "Baltieri", "contato@balta.io", "abc123");
    private readonly Request _invalidUserAlreadyExistsRequest = new("André", "Baltieri", "contato@balta.io", "ABC123abc123");
    private readonly Request _validRequest = new("André", "Baltieri", "contato@balta.io", "ABC123abc123");
    private readonly Request _validHandlerSucceed = new("Douglas", "Adams", "douglas@balta.io", "ABC123abc123");
    #endregion

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Request_FirstName_Is_Too_Short()
    {
        var response = Specification.Validate(_invalidFirstNameTooShortRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Request_FirstName_Is_Too_Large()
    {
        var response = Specification.Validate(_invalidFirstNameTooLargeRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Request_LastName_Is_Too_Short()
    {
        var response = Specification.Validate(_invalidLastNameTooShortRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Request_LastName_Is_Too_Large()
    {
        var response = Specification.Validate(_invalidLastNameTooLargeRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Request_Email_Is_Invalid()
    {
        var response = Specification.Validate(_invalidEmailRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Request_Password_Is_Not_Empty_And_Is_Too_Short()
    {
        var response = Specification.Validate(_invalidPasswordTooShortRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_If_User_Already_Existis()
    {
        var response = await _handler.Handle(_invalidUserAlreadyExistsRequest, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public void Should_Succeed_When_Request_Valid()
    {
        var response = Specification.Validate(_validRequest);
        Assert.True(response.IsValid);
    }

    [Fact]
    public async void Should_Succeed_When_User_Deleted()
    {
        var response = await _handler.Handle(_validHandlerSucceed, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
