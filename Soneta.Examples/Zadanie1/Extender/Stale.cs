namespace Soneta.Examples.Zadanie1.Extender
{
    public partial class Zadanie1
    {
        // Domyślny katalog GIT
        const string GitWorkDir = @"C:\Users\wojtek\source\repos\enova365_testy\Examples";
        // Pobranie listy commitów
        const string GitGetCommits = "git log HEAD --stat --date=format:\"%Y-%m-%d %H:%M:%S\"";
        //Lista gałęzi    * aktywna
        const string GitGetBranches = "git branch";
        const string GitReset = "git reset -q --hard HEAD";
        const string GitSetBranche = "git checkout ";

    }
}