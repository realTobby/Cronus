using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronus.FileHandler
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
