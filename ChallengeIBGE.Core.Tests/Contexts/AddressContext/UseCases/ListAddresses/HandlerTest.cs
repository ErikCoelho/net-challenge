using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;
using ChallengeIBGE.Core.Contexts.UserContext.ValueObjects;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.ListAddresses;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidAddressCityNotExists = Request.WithCity("Porto Alegre");
    private readonly Request _invalidAddresStateNotExists = Request.WithState("RS");
    private readonly Request _invalidAddresIdNotExists = Request.WithId(2222222);
    private readonly Request _validAdddressCityExists = Request.WithCity("Floripa");
    private readonly Request _validAddresStateExists = Request.WithState("SC");
    private readonly Request _validAddresIdExists = Request.WithId(9999999);
    #endregion

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public async void Should_Fail_If_Address_City_Not_Exists()
    {
        var response = await _handler.Handle(_invalidAddressCityNotExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_If_Address_State_Not_Exists()
    {
        var response = await _handler.Handle(_invalidAddresStateNotExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_If_Address_Id_Not_Exists()
    {
        var response = await _handler.Handle(_invalidAddresIdNotExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public async void Should_Succeed_If_Address_City_Exits()
    {
        var response = await _handler.Handle(_validAdddressCityExists, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_If_Address_State_Exists()
    {
        var response = await _handler.Handle(_validAddresStateExists, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_If_Address_Id_Exists()
    {
        var response = await _handler.Handle(_validAddresIdExists, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
