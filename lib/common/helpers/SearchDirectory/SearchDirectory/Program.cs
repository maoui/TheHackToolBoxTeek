using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{ 
    public class Folders
    {
 
        public static List<string> GetDirectories(Environment.SpecialFolder path)
        {
            List<string> tmp = new List<string>() { };

            foreach (var item in GetDirectories(Environment.GetFolderPath(path)))
            {
                tmp.Add(item);
            }
            return tmp;
        }

        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>

        private static List<string> GetDirectories(string path, string searchPattern = "*",   SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            
            try
            {
                if (searchOption == SearchOption.TopDirectoryOnly)
                    return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (DirectoryNotFoundException)
            {
                return new List<string>();
            }

            var directories = new List<string>(GetDirectories(path, searchPattern));

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPattern));
            return directories;

        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {

            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
            catch (DirectoryNotFoundException)
            {
                return new List<string>();
            }
        }
    }
}
