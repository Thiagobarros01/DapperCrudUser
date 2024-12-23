using CRUDDapper.Dto;
using CRUDDapper.Models;

namespace CRUDDapper.Services
{
    public interface IUserService
    {
        public Task<ResponseModel<List<ListUserDto>>> GetUsers();
        public Task<ResponseModel<ListUserDto>> GetUserById(int IdUser);
        public Task<ResponseModel<List<IncludeUserDto>>> AddUser(IncludeUserDto NewUser);
        public Task<ResponseModel<List<ListUserDto>>> UserEdit(UserEditDto userDto);
        public Task<ResponseModel<List<ListUserDto>>> UserRemove (int IdUser);
       
    }
}
