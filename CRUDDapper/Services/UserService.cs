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
        public UserService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<IncludeUserDto>>> AddUser(IncludeUserDto NewUser)
        {
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ResponseModel<List<IncludeUserDto>> response = new ResponseModel<List<IncludeUserDto>>();

                var newUser = await connection.ExecuteAsync("insert into Users (FullName,Email,Profession,Salary,CPF,Passw,Situation)" +
                    "values (@FullName,@Email,@Profession,@Salary,@CPF,@Passw,@Situation)",NewUser);

                if(newUser == 0)
                {
                    response.Status = false;
                    response.Message = "Nenhuma Linha afetada!";
                    return response;
                }

                var users = await GetAllUsers(connection);


                //Mapp
                var userMapper = _mapper.Map<List<IncludeUserDto>>(users);

                response.Data = userMapper;
                response.Status = true;
                response.Message = "Usuário incluido com sucesso!";
                return response;

            }
        }

        public async Task<ResponseModel<ListUserDto>> GetUserById(int IdUser)
        {
            ResponseModel<ListUserDto> response = new ResponseModel<ListUserDto>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("Select * from Users where Id = @Id", new {Id = IdUser});


                if (user == null)
                {
                    response.Message = "Id usuario não encontrado";
                    response.Status = false;
                    return response;
                }

                // Mapper 
                 var userDto = _mapper.Map<ListUserDto>(user);

                response.Data = userDto;
                response.Message = "Usuário encontrado";
                response.Status = true;
                return response;

            }
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

        private static async Task<IEnumerable<User>> GetAllUsers(SqlConnection connection)
        {
            return await connection.QueryAsync<User>("SELECT * FROM Users");
        }
    }
}
