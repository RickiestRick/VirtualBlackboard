using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBlackboard.Model
{
    [Serializable] 
   public class Project
    {
        public string Filepath { get; set; }
        public string DisplayText { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}
