using System.Configuration;

namespace GithubUsersApi.Helper
{
    public class AppSettings
    {
        public static string GitHubApiUserAddress => ConfigurationManager.AppSettings["GitHubApiUserAddress"];
        public static int MaxRowsPerPage => int.Parse(ConfigurationManager.AppSettings["MaxRowsPerPage"]);
    }
}