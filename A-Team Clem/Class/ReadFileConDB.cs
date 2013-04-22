using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace A_Team_Clem
{
    class ReadFileConDB
    {
        public string hostName = "";
        public string dataBaseName = "";
        public string userName = "";
        public string pwd = "";
        public string port = "";
        
        public bool readFileConDB(string pathFileName)
        {
            try
            {
                StreamReader stR = File.OpenText(pathFileName);
                hostName = stR.ReadLine();
                dataBaseName = stR.ReadLine();
                userName = stR.ReadLine();
                pwd = stR.ReadLine();
                port = stR.ReadLine();
                stR.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool saveFileConDB(string path)
        {
            try
            {
                StreamWriter stW = File.CreateText(path);
                stW.WriteLine(hostName);
                stW.WriteLine(dataBaseName);
                stW.WriteLine(userName);
                stW.WriteLine(pwd);
                stW.WriteLine(port);
                stW.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
