using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HelpDeskTicketingSystem
{
    public static class Logs
    {
      public static void Loggings(string logContent)
        {
            try
            
            {
                string logPath = Environment.CurrentDirectory + "/logs.txt";
                File.AppendAllText(logPath, logContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
