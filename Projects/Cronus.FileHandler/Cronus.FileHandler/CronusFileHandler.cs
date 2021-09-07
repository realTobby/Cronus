using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronus.FileHandler
{
    public class CronusFileHandler : ICronusFileHandler
    {
        #region Private Constants
        private const string REGISTRY_CRONUS_PATH = @"SOFTWARE\Cronus";
        private const string REGISTRY_WORKSPACE_KEY = "WorkspacePath";
        private const string FILE_PROJECT_INI = "project.ini";
        #endregion

        #region Private Fields
        private static RegistryKey cronusRegistryEntry;
        #endregion

        #region Public Methods

        #region Workspace Utils  
        public void SaveWorkspacePathToRegistry(string newWorkspacePath)
        {
            cronusRegistryEntry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_CRONUS_PATH);
            cronusRegistryEntry.SetValue(REGISTRY_WORKSPACE_KEY, newWorkspacePath);
            cronusRegistryEntry.Close();
        }

        public string GetWorkspacePathFromRegistry()
        {
            cronusRegistryEntry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_CRONUS_PATH);
            string workspacePath = cronusRegistryEntry.GetValue(REGISTRY_WORKSPACE_KEY).ToString();
            cronusRegistryEntry.Close();
            return workspacePath;
        }
        #endregion

        #region Project Informations
        public IEnumerable<string> GetProjectsList() => System.IO.Directory.GetDirectories(GetWorkspacePathFromRegistry());
        #endregion

        #region Project
        public void SaveProject(ProjectModel projectModel)
        {
            string fullPath = System.IO.Path.Combine(GetWorkspacePathFromRegistry(), projectModel.Name);
            if(!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }

            // create ini file

            // 1. ProjectName
            // 2. ProjectAuthor
            // 3. ProjectCreateDate
            // 4. ProjectChangeDate
            // 5. ProjectDescription
            // 6. RawZPLCode

            string iniContent = "ProjectName=" + projectModel.Name + System.Environment.NewLine +
                                "ProjectAuthor=" + projectModel.Author + System.Environment.NewLine +
                                "ProjectCreateDate=" + projectModel.CreateDate + System.Environment.NewLine +
                                "ProjectChangeDate=" + projectModel.ChangeDate + System.Environment.NewLine +
                                "ProjectDescription=" + projectModel.Description + System.Environment.NewLine;

            System.IO.File.WriteAllText(System.IO.Path.Combine(fullPath, FILE_PROJECT_INI), iniContent);

            System.IO.File.WriteAllText(System.IO.Path.Combine(fullPath, projectModel.Name + ".zpl"), "^XAEMPTY^XZ");
        }

        public object LoadProject(string path)
        {
            return new ProjectModel();
        }
        #endregion

        #region Private Methods

        #endregion

        #endregion

    }
}
