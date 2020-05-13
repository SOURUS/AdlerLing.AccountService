﻿using AdlerLing.AccountService.Core.DTO;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Interfaces
{
    public interface IUserDAL : IDAL, IDisposable
    {
        Task<bool> CreateUserAsync(CreateUserDTO user);
        Task<int> CheckUserExists(string email);
    }
}
