using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;
using Tenis.ViewModels;

namespace Tenis.Services.Interface
{
    public interface IUsersService
    {
        UserGetModel Authenticate(string username, string password);
        UserGetModel Register(RegisterPostModel registerInfo);
        User GetCurrentUser(HttpContext httpContext);
        IEnumerable<UserGetModel> GetAll();
        User DeleteUser(int id);
        User UpsertUser(int id, User modifiedUser);
    }
}
