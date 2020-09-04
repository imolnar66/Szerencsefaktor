using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szerencsefaktor.FajlKezeles
{
    static public class JsonFileManagement
    {

        public static string ReadFromJsonFile(string filePathAndName)
        {
            string strResultJson = File.ReadAllText(filePathAndName);
            return strResultJson;

        }
        public static void SaveToJsonFile(string filePathAndName, string jsonData)
        {
            File.WriteAllText(filePathAndName, jsonData);
        }
    }
}
