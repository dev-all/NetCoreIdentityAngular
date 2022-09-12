using allshop.Models.Response;
using allshop.Models.Request;
using allshop.api.Models;

namespace allshop.api.Services.Contracts
{
    public interface IRolesService
    {
        Task<RoleModel> GetRolesByUserId(Guid roleId);
    }
}
