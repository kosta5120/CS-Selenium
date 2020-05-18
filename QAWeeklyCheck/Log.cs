using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWeeklyCheck
{
    public class Log
    {
        public void Data(string logMessage,string plant)
        {
            //StreamWriter log;
            var fileName = $@"C:\temp\WeeklyCheck.txt";
            

            if (!File.Exists(fileName))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                using (StreamWriter log = File.CreateText(fileName))
                {

                    if (logMessage == string.Empty)
                        log.WriteLine($"{plant} :");
                    else
                        log.WriteLine($"    {plant}:  {logMessage}");
                }
            }
            else
            {
                using (StreamWriter log = File.AppendText(fileName))
                {

                    if (logMessage == string.Empty)
                        log.WriteLine($"{plant} :");
                    else
                        log.WriteLine($"    {plant}:  {logMessage}");
                }
            }
            
            
            
        }
    }
}
