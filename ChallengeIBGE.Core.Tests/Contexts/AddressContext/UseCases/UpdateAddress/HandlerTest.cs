using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.UpdateAddress;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    #region Requests
    private readonly Request _invalidCityShortNameRequest = new(0101011, "A", "SC");
    private readonly Request _invalidCityLargeNameRequest = new(0101011, "EstadoFantásticoComTrintaDígitos", "SC");
    private readonly Request _invalidStateShortNameRequest = new(0101011, "Floripa", "S");
    private readonly Request _invalidStateLargeNameRequest = new(0101011, "Floripa", "SSS");
    private readonly Request _invalidIdZeroRequest = new(0000000, "Floripa", "SC");
    private readonly Request _validRequest = new(9999999, "Floripa", "SC");
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
    #endregion

    #region Should Succeed
    [Fact]
    public void Should_Succeed_When_Request_Is_Valid()
    {
        var response = Specification.Validate(_validRequest);
        Assert.True(response.IsValid);
    }

    [Fact]
    public async void Should_Succeed_When_Handler_Response_Returns_IsSuccess()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
