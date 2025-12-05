using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDooDoo.services
{
    internal static class Repository
    {
        public static readonly string ROOT = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string dataDirectory = ROOT + "data/";

        public static string getFilePath(DateTime date)
        {
            string path = dataDirectory + date.ToString("yyyy-MM-dd") + ".txt";
            return path;
        }

        public static List<string> getDataFile(DateTime date)
        {
            if (!File.Exists(dataDirectory + date.ToString("yyyy-MM-dd") + ".txt"))
            {
                return [];
            }
            List<string> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(getFilePath(date)));
            return lines;
        }
    }
}
