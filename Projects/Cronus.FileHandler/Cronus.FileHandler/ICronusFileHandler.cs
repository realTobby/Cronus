using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronus.FileHandler
{
    public interface ICronusFileHandler
    {
        void SaveProject(ProjectModel projectModel);
        object LoadProject(string path);
        IEnumerable<string> GetProjectsList();
        string GetWorkspacePathFromRegistry();
        void SaveWorkspacePathToRegistry(string newWorkspacePath);

    }
}
