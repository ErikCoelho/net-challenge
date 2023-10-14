using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.DeleteAddress;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidAddressNotExists = new(1111111);
    private readonly Request _validAddressExists = new(9999999);
    #endregion

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }


    [Fact]
    public async void Should_Fail_If_Address_Is_Different()
    {
        var response = await _handler.Handle(_invalidAddressNotExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_If_Same_Address()
    {
        var response = await _handler.Handle(_validAddressExists, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
}
