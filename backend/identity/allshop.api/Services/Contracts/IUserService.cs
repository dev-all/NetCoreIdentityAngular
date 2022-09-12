using allshop.Models.Response;
using allshop.Models.Request;
using allshop.api.Models;

namespace allshop.api.Services.Contracts
{
    public interface IUserService
    {
        // UserResponse Auth(AuthRequest model);

        Task<UserModel> SingIn(string email);
        string GenerateJWTToken(Guid id, bool rememberMe);
        string GenerateJWTTokenByEmail(string email);
        Task<UserModel> ExistEmailAsync(string email);

        Task AddAsync(UserModel user);
        Task<UserModel> AddGetAsync(UserModel user);
        Task<UserModel> UpdateAsync(UserModel user);
        Task<UserModel> Get(Guid id);
    }
}
