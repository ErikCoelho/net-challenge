using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.CreateAddress;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidCityShortNameRequest = new("A", "SC", 0101011);
    private readonly Request _invalidCityLargeNameRequest = new("EstadoFantásticoComTrintaDígitos", "SC", 0101011);
    private readonly Request _invalidStateShortNameRequest = new("Floripa", "S", 0101011);
    private readonly Request _invalidStateLargeNameRequest = new("Floripa", "SSS", 0101011);
    private readonly Request _invalidIdZeroRequest = new("Floripa", "SC", 0000000);
    private readonly Request _invalidAddressAlreadyExists = new("Floripa", "SC", 9999999);
    private readonly Request _validRequest = new("Floripa", "SC", 0101011);
    private readonly Request _validRequestNewAddress = new("Floripa", "SC", 1111111);
    #endregion   

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_City_In_Request_Is_Too_Short()
    {
        var response = Specification.Validate(_invalidCityShortNameRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_City_In_Request_Is_Too_Large()
    {
        var response = Specification.Validate(_invalidCityLargeNameRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_State_In_Request_Is_Too_Short()
    {
        var response = Specification.Validate(_invalidStateShortNameRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_State_In_Request_Is_Too_Large()
    {
        var response = Specification.Validate(_invalidStateLargeNameRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Id_In_Request_Is_Zero()
    {
        var response = Specification.Validate(_invalidIdZeroRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_Address_Already_Exists()
    {
        var response = await _handler.Handle(_invalidAddressAlreadyExists, new CancellationToken());
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
    public async void Should_Succeed_When_Request_Is_Valid_And_Is_New_Address()
    {
        var response = await _handler.Handle(_validRequestNewAddress, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
