using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fileStream = File.Open("E:\\log.txt", FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite))
            {
                fileStream.Seek(0, SeekOrigin.End);
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                   
                    for (;;)
                    {
                        // Substitute a different timespan if required.
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));

                        // Write the output to the screen or do something different.
                        // If you want newlines, search the return value of "ReadToEnd"
                        // for Environment.NewLine.
                        var line = streamReader.ReadToEnd();
                        string fixedLine = Regex.Replace(line, @"\s+", String.Empty);

                        bool condition = String.Equals("EXIT", fixedLine, StringComparison.OrdinalIgnoreCase);
                        //Console.Out.WriteLine(fixedLine + " - " + condition);
                        if(condition) System.Environment.Exit(1);
                    }
                }
            }
        }
    }
}
