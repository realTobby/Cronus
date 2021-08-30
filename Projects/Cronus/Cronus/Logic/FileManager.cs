using Cronus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronus.Logic
{
    public static class FileManager
    {
        private const string _projectIniName = "project.ini";

        public static void CreateNewProject(string workspacePath, ProjectModel pm)
        {
            string fullPath = System.IO.Path.Combine(workspacePath, pm.Name);

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
                                "ProjectDescription=" + pm.Description + System.Environment.NewLine + 
                                "RawZPLCode=" + pm.RawZPLCode;

            System.IO.File.WriteAllText(System.IO.Path.Combine(fullPath, _projectIniName), iniContent);

        }

        public static ProjectModel LoadProject(string fullPath)
        {
            ProjectModel pm = new ProjectModel();

            string[] iniContent = System.IO.File.ReadAllLines(System.IO.Path.Combine(fullPath, _projectIniName));

            pm.Name = iniContent[0].Split('=')[1];
            pm.Author = iniContent[1].Split('=')[1];
            pm.CreateDate = DateTime.Parse(iniContent[2].Split('=')[1]);
            pm.ChangeDate = DateTime.Parse(iniContent[3].Split('=')[1]);
            pm.Description = iniContent[4].Split('=')[1];
            pm.RawZPLCode = iniContent[5].Split('=')[1];

            return pm;
        }


    }
}
