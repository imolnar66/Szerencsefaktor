using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szerencsefaktor.Other_classes
{
    class Log
    {
        public static void Bejegyzes(string message, NaploSzint szint)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}][{szint}] - {message}" + Environment.NewLine); ;
        }
        public static void Bejegyzes(Exception ex)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}][{NaploSzint.Hiba}] - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }
    }
}
