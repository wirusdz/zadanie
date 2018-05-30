using System.Text;
using System.Diagnostics;

namespace Soneta.Examples.Zadanie1.Extender
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
            _WorkDir = @"C:\Users\wojtek\source\repos\enova365_testy\Examples";
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

            proc1.WorkingDirectory = _WorkDir;

            proc1.FileName = exe;
            proc1.Arguments = "/c " + _command;
            proc1.CreateNoWindow = true;
            proc1.RedirectStandardOutput = true;
            proc1.RedirectStandardError = true;
            proc1.StandardOutputEncoding = Encoding.UTF8;
            p.StartInfo = proc1;
            p = Process.Start(proc1);
            _outtext = p.StandardOutput.ReadToEnd();

            _outeerror = p.StandardError.ReadToEnd();
            //if (_outeerror != string.Empty)
            //    throw new System.Exception(_outeerror);
            return _outeerror;
        }
    }
}
