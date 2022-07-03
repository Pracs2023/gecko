using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBox.Utility
{
    public class SerializeUtility
    {
        public static void SerializeScoreInfos(ScoreInfos sta, String filename)
        {
            //Create the stream to add object into it.  
            Serailze(sta, filename);
        }

        public static void CreateNewScoreFile(String filename)
        {
            ScoreInfos sta = new ScoreInfos();
            Serailze(sta, filename);
        }
        public static ScoreInfos DeserializeScore(String filename)
        {
            object obj = Deserialize(filename);
            ScoreInfos sta = (ScoreInfos)obj;
            return sta;
        }

        private static void Serailze(object obj, String filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, obj);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        private static object Deserialize(String filename)
        {
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            // Statistics sta = (Statistics)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return obj;

        }
    }
}
