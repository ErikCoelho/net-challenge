using ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.UpdateUser;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidFirstNameTooShortRequest = new(Guid.NewGuid(), "An", "Baltieri", "contato@balta.io");
    private readonly Request _invalidFirstNameTooLargeRequest = new(Guid.NewGuid(), "Testandoumnomemuitograndecommuitosdigitos", "Baltieri", "contato@balta.io");
    private readonly Request _invalidLastNameTooShortRequest = new(Guid.NewGuid(), "André", "Ba", "contato@balta.io");
    private readonly Request _invalidLastNameTooLargeRequest = new(Guid.NewGuid(), "André", "Testandoumsobrenomemuitograndequetenhaacimadeoitentadigitosparaostestesdeunidadesobrenome", "contato@balta.io");
    private readonly Request _invalidEmailRequest = new(Guid.NewGuid(), "André", "Baltieri", "contatobalta.io");
    private readonly Request _invalidUserNotFound = new(Guid.NewGuid(), "David", "Adams", "david@balta.io");
    private readonly Request _validRequest = new(Guid.NewGuid(), "André", "Baltieri", "contato@balta.io");
    private readonly Request _validUpdateComplete = new(new Guid("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e"), "Andre", "Baltieri", "balta@balta.io");
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
    public async void Should_Fail_When_User_Not_Found()
    {
        var response = await _handler.Handle(_invalidUserNotFound, new CancellationToken());
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
    public async void Should_Succeed_When_Update_Complete()
    {
        var response = await _handler.Handle(_validUpdateComplete, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
