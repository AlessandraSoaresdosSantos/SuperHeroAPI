﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroAPI.EntityFramework
{
    public interface IUsersServices : IServices<User>
    {
        User Authenticate(string username, string password);
        
    }
}