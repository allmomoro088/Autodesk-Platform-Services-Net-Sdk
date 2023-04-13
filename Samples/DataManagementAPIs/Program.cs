using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.DM;

namespace DataManagementAPIs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating a ClientCredentials instance
            //For now we are going to use the 2 legged authentication flow
            ClientCredentials cc = new ClientCredentials("YOUR CLIENT ID", "YOUR CLIENT SECRET");

            //Now we can create API instances passing the credentials, for authentication
            HubsApi hubsApi = new HubsApi(cc);

            //In APIs classes you will find methods for APS API calls
            //For example GetHubs
            IEnumerable<Hub> hubs = hubsApi.GetHubs();

            //ProjectsApi
            ProjectsApi projectsApi = new ProjectsApi(cc);

            //Getting all projects from a hub
            IEnumerable<Project> projects = projectsApi.GetProjects(hubs.First().Id);

            //Getting a project's top folders
            IEnumerable<Folder> topFolders = projectsApi.GetTopFolders(hubs.First().Id, projects.First().Id);

            //FoldersApi
            FoldersApi foldersApi = new FoldersApi(cc);

            //Getting a folder's contents
            Contents contents = foldersApi.GetContents(projects.First().Id, topFolders.First().Id);

            //In contents there are the folders, items and included versions
            var folders = contents.Folders;
            var items = contents.Items;
            var versions = contents.Versions;
        }
    }
}