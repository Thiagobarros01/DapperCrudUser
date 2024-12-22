using AutoMapper;
using CRUDDapper.Dto;
using CRUDDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;


namespace CRUDDapper.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(IConfiguration configuration,IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<ListUserDto>>> GetUsers()
        {

            ResponseModel<List<ListUserDto>> response = new ResponseModel<List<ListUserDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var userDb = await connection.QueryAsync<User>("select * from Users");

                if (userDb.Count() == 0) 
                {
                    response.Message = "Nenhum usuário encontrado";
                    response.Status = false;
                    return response;
                }


                //Transfer Mapper

                var UserDto = _mapper.Map<List<ListUserDto>>(userDb);



                response.Data = UserDto;
                response.Message = "Usuários encontrados!";
                response.Status = true;
                return response;
            }

           
        }
    }
}
