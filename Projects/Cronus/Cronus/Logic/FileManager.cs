using Cronus.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace Cronus.Logic
{
    public static class FileManager
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
        public static void CreateNewProject(ProjectModel pm)
        {
            string fullPath = System.IO.Path.Combine(GetWorkspacePath(), pm.Name);

            if(!System.IO.Directory.Exists(fullPath))
            {
                // create base project folder
                System.IO.Directory.CreateDirectory(fullPath);

                // create ini file

                // 1. ProjectName
                // 2. ProjectAuthor
                // 3. ProjectCreateDate
                // 4. ProjectChangeDate
                // 5. ProjectDescription
                // 6. RawZPLCode

                string iniContent = "ProjectName=" + pm.Name + System.Environment.NewLine +
                                    "ProjectAuthor=" + pm.Author + System.Environment.NewLine +
                                    "ProjectCreateDate=" + pm.CreateDate + System.Environment.NewLine +
                                    "ProjectChangeDate=" + pm.ChangeDate + System.Environment.NewLine +
                                    "ProjectDescription=" + pm.Description + System.Environment.NewLine;

                System.IO.File.WriteAllText(System.IO.Path.Combine(fullPath, FILE_PROJECT_INI), iniContent);

                System.IO.File.WriteAllText(System.IO.Path.Combine(fullPath, pm.Name + ".zpl"), "^XAEMPTY^XZ");

            }
        }

        public static List<ProjectModel> SearchForProjects(string fullPath)
        {
            List<ProjectModel> projects = new List<ProjectModel>();
            string[] projectsInsideWorkspace = System.IO.Directory.GetDirectories(fullPath);

            foreach (string name in projectsInsideWorkspace)
            {
                ProjectModel nextProject = FileManager.GatherProjectMetaData(name);
                projects.Add(nextProject);
            }
            return projects;
        }

        public static string LoadZPL(string projectName)
        {
            string fullPath = System.IO.Path.Combine(GetWorkspacePath(), projectName);
            string result = string.Empty;
            result = System.IO.File.ReadAllText(System.IO.Path.Combine(fullPath, projectName + ".zpl"));
            return result;
        }

        public static void SetWorkspacePath(string path)
        {
            cronusRegistryEntry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_CRONUS_PATH);
            cronusRegistryEntry.SetValue(REGISTRY_WORKSPACE_KEY, path);
            cronusRegistryEntry.Close();
        }

        public static string GetWorkspacePath()
        {
            cronusRegistryEntry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_CRONUS_PATH);
            string workspacePath = cronusRegistryEntry.GetValue(REGISTRY_WORKSPACE_KEY).ToString();
            cronusRegistryEntry.Close();
            return workspacePath;
        }
        #endregion

        #region Private Methods
        private static ProjectModel GatherProjectMetaData(string fullPath)
        {
            ProjectModel pm = new ProjectModel();
            string[] iniContent = System.IO.File.ReadAllLines(System.IO.Path.Combine(fullPath, FILE_PROJECT_INI));

            pm.Name = iniContent[0].Split('=')[1];
            pm.Author = iniContent[1].Split('=')[1];
            pm.CreateDate = DateTime.Parse(iniContent[2].Split('=')[1]);
            pm.ChangeDate = DateTime.Parse(iniContent[3].Split('=')[1]);
            pm.Description = iniContent[4].Split('=')[1];

            return pm;
        }

        private static string GetProjectNameFromPath(string fullpath)
        {
            return System.IO.Path.GetDirectoryName(fullpath);
        }
        #endregion

    }
}
