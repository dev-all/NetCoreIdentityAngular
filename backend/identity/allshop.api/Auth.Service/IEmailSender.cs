using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allshop.api.Auth.Service
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
