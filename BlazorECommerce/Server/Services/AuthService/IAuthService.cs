﻿using BlazorECommerce.Shared;

namespace BlazorECommerce.Server.Services.AuthService
{
    public interface IAuthService
    {
        public Task<ServiceResponse<int>> Register(User user, string password);
        public Task<bool> UserExists(string email);
        public Task<ServiceResponse<string>> Login(string email, string password);
        public Task<ServiceResponse<bool>> ChangePassword(int userID, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<User> GetUserByEmail(string email);


    }
}
