﻿using Flunt.Notifications;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress;

public class Response : SharedContext.UseCases.Response
{
    public Response() { }
    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }
    public Response(string message, ResponseData data)
    {
        Message = message;
        Status = 201;
        Notifications = null;
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(string City, string State, long IbgeCode);
