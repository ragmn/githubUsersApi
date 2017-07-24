using GithubUsersApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubUsersApi.Helper
{
    public class GitHubManager
    {
        private readonly string _gitHubUrl;
        public GitHubManager(string gitHubUri)
        {
            _gitHubUrl = gitHubUri;
        }
        /// <summary>
        /// Method to fetch github user details
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<User> GetUserDetails(string userName)
        {
            var gitHubUserUrl = $"{_gitHubUrl}{userName}";
            var userDetails = await GitHubProxy.GetAsync<User>(gitHubUserUrl);
            return userDetails;
        }
        /// <summary>
        /// Method to fetch repository details
        /// </summary>
        /// <param name="gitHubUser"></param>
        /// <returns></returns>
        public async Task<List<Repo>> GetUserRepository(string userRepository)
        {
            var userRepoDetails = await GitHubProxy.GetAsync<List<Repo>>(userRepository);
            return userRepoDetails;
        }
    }
}