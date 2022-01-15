﻿using Blog.Data.DbModels;
using System;

namespace Blog.BL.Authorization.Contracts
{
    public interface IJwtTokenProvider
    {
        public string GenerateToken(ApplicationUser user);

        public string ValidateToken(string token);
    }
}
