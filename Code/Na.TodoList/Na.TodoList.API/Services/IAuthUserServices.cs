using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Na.TodoList.API.Services
{
    public interface IAuthUserServices
    {
        void CreateToken(AppUser userInfo);
        //void CreateToken2(AppUser userInfo);
    }
}
