using CRUDDapper.Dto;
using CRUDDapper.Models;

namespace CRUDDapper.Services
{
    public interface IUserService
    {
        public Task<ResponseModel<List<ListUserDto>>> GetUsers();
    }
}
