using allshop.api.Tools;
using Google.Apis.Gmail.v1;

namespace allshop.api.Services.Contracts
{
    public interface IGmailApiService
    {
        Task<List<Gmail>> GetAllEmails();
        Task<GmailService> GetServiceGoogle();
    }
}
