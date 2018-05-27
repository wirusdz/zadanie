using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Soneta.Examples.Zadanie1.Extander
{
    public class CMDCommand
    {
        public string WorkDir { set { _WorkDir = value; } }
        public string Command { set { _command = value; } }
        private string _WorkDir;
        private string _command;

        private const string exe = @"C:\Windows\system32\cmd.exe";

        public string GetText { get { return _outtext; } }
        private string _outtext;
        private string _outeerror;

        public CMDCommand()
        {
            _WorkDir = @"C:\Users\wojtek\source\repos\enova365\Examples";
        }
        public CMDCommand(string WorkDir, string command)
        {
            _WorkDir = WorkDir;
            _command = command;
        }
        public string Run()
        {
            var proc1 = new ProcessStartInfo();
            Process p = new Process();

            proc1.UseShellExecute = false;

            proc1.WorkingDirectory = _WorkDir; // @"C:\Users\wdziedzic\Documents\Visual Studio 2015\Projects\t3s\GIT\t3s4.1.1";

            proc1.FileName = exe; // @"git";
            proc1.Arguments = "/c " + _command;
            proc1.CreateNoWindow = true;
            proc1.RedirectStandardOutput = true;
            proc1.RedirectStandardError = true;
            proc1.StandardOutputEncoding = Encoding.UTF8; // .GetEncoding(1250);// Encoding.Unicode;// BigEndianUnicode;
            p.StartInfo = proc1;
            p = Process.Start(proc1);
            //p.WaitForExit();
            //StreamReader myStreamReader = p.StandardOutput;
            _outtext = p.StandardOutput.ReadToEnd();

            //Encoding En = p.StandardOutput.CurrentEncoding;
            _outeerror = p.StandardError.ReadToEnd();
            return _outeerror;
        }
    }
}
