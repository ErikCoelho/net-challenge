﻿using ChallengeIBGE.Core.Contexts.SharedContext.Entity;
using System.Text.Json.Serialization;

namespace ChallengeIBGE.Core.Contexts.UserContext.Entities;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public List<User> Users { get; set; } = new();
}