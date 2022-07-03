using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBox.Utility
{
    public class FileUtility
    {
        public static string CurrentPath
        {
            get
            {
                String ExePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                return Path.GetDirectoryName(ExePath);
                //   logFilePath = logFilePath.Replace(".exe", "");
            }
        }
        public static string PuppyFilePath
        {
            get
            {
                return CurrentPath + @"\Images\puppy_small.png";
            }
        }
        public static string ScoreFilePath
        {
            get
            {
                return CurrentPath + @"\Score.bin";
            }
        }
        public static  bool IsFileExist(String fileName)
        {
            return System.IO.File.Exists(fileName);
        }
    }
}
