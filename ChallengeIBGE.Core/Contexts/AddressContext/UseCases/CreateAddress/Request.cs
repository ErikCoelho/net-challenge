﻿using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress;

public record Request(string City, string State, int Id) : IRequest<Response>;