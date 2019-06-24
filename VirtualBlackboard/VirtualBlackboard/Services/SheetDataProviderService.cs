using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using VirtualBlackboard.Model;

namespace VirtualBlackboard.Services
{
    public class ProjectDataProvider
    {
        public const string ROOTPATH = "Projects";
        public ProjectDataProvider()
        {
            if (!Directory.Exists(ROOTPATH))
            {
                Directory.CreateDirectory(ROOTPATH);
            }
        }
        public ICollection<Project> GetAllSheets()
        {
            var myprojs = new List<Project>();
         
            foreach (var item in Directory.GetFiles(ROOTPATH))
            {
                myprojs.Add(Deserialize(item));
            }
            return myprojs;
        }

        public Project Deserialize(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            Project obj = (Project)formatter.Deserialize(stream);
            stream.Close();

            return obj;
        }


        public void Serialize(Project proj)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(proj.Filepath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, proj);
            stream.Close();
        }

        public void Delete(Project proj)
        {
            File.Delete(proj.Filepath);
        }

    }
}
