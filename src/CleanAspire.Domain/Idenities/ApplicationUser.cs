﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.



using CleanAspire.Domain.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CleanAspire.Domain.Idenities;

public class ApplicationUser : IdentityUser, IAuditableEntity
{
   

    public string? Nickname { get; set; }
    public string? Provider { get; set; } = "Local";
    public string? TenantId { get; set; }
    public byte[]? Avatar { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public string? TimeZoneId { get; set; }
    public string? LanguageCode { get; set; }
    public string? SuperiorId { get; set; } = null;
    public ApplicationUser? Superior { get; set; } = null;
    public DateTime? Created { get; set; }
    public string? CreatedBy { get; set; }
    public ApplicationUser? CreatedByUser { get; set; } = null;
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public ApplicationUser? LastModifiedByUser { get; set; } = null;

  
}