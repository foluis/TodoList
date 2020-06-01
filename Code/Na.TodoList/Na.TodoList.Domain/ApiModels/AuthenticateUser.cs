using System;
using System.Collections.Generic;
using System.Text;

namespace Na.TodoList.Domain.ApiModels
{
    public class AuthenticateUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
