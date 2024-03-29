﻿using allshop.Models.Response;
using allshop.Models.Request;
using allshop.api.Models;
using allshop.domain.Entities;

namespace allshop.api.Services.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendRecoveryLinkEmail(string recoveryLink, string? fullName, string email);
        Task<bool> SendWelcomeEmail(string fullname, string email);
    }
}
