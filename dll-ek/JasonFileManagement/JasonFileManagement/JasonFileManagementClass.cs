using System;
using System.IO;

namespace JasonFileManagement
{
    public class JasonFileManagementClass
    {

        #region Json műveletek
        public static string JsonFileread(string fajlutvonal)
        {
            string strResultJson = File.ReadAllText(fajlutvonal);
            return strResultJson;
        }

        public static void JsonFileWrite(string fajlutvonal, string jsonadat)
        {

            File.WriteAllText(fajlutvonal, jsonadat);

        }
        #endregion

    }
}
