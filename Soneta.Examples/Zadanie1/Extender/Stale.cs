using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Examples.Zadanie1.Extender;
using Soneta.Examples.Example3.Extender;
using Soneta.Tools;

namespace Soneta.Examples.Zadanie1.Extender
{
    public partial class Zadanie1
    {
        // Katalog GIT'a
        const string GitWorkDir = @"C:\Users\wojtek\source\repos\enova365\Examples";
        // Pobranie listy commitów
        const string GitGetCommits = "git log HEAD --stat --date=format:\"%Y-%m-%d %H:%M:%S\"";
        //Lista gałęzi    * aktywna
        const string GitGetBranches = "git branch";
        const string GitReset = "git reset -q --hard HEAD";
        const string GitSetBranche = "git checkout ";

    }
}