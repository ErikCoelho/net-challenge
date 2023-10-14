﻿using Flunt.Notifications;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses;

public class Response : SharedContext.UseCases.Response
{
    protected Response() { }
    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }
    public Response(string? message, ResponseData data)
    {
        Message = message;
        Status = 200;
        Notifications = null;
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(int? Id, string? City, string? State);
