/*
 Created by : MADHAN KAMALAKANNAN
 Student ID : 20230907
 Email      : 20230907@mywhitecliffe.com
 Date       : 31 March 2023
*/﻿
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
