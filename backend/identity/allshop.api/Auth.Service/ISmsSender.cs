using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allshop.api.Auth.Service
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
