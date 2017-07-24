using GithubUsersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GithubUsersApi.Helper;

namespace GithubUsersApi.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// default action method
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Method to call github service and return partical view result
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PartialViewResult> GetUserDetails(string userName)
        {
            UserRepo userRepo = new UserRepo();
            try
            {
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var gitHubManager = new GitHubManager(AppSettings.GitHubApiUserAddress);
                    var userDetails = await gitHubManager.GetUserDetails(userName);
                    if (userDetails != null)
                    {
                        //fetch repository details
                        var userRepoDetails = await gitHubManager.GetUserRepository(userDetails.Repos_url);
                        if (userRepoDetails.Count > 0)
                        {
                            userRepo = new UserRepo
                            {
                                UserDetails = userDetails,
                                Repository = userRepoDetails.OrderByDescending(x => x.Stargazers_count).Take(5).ToList()
                            };
                        }
                        else
                        {
                            userRepo = new UserRepo
                            {
                                UserDetails = userDetails,
                                Repository = new List<Repo>()
                            };
                        }
                    }
                    else
                    {
                        userRepo = null;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile("Error.txt");
            }
            return PartialView("_UserDetails", userRepo);
        }
    }
}