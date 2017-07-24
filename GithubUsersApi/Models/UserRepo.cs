using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubUsersApi.Models
{
    public class UserRepo
    {
        public User UserDetails { get; set; }
        public List<Repo> Repository { get; set; }
    }
}