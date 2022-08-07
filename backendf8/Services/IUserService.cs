using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;

namespace backendf8.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<bool> Registration(RegistrationUser request);
        List<UserResponse> GetListUser();
        UserResponse DeleteUser(Guid id);
        /*Task<UserResponse> EditUser(EditUserRequest request);*/


    }
}