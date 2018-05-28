using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Examples.Zadanie1.Extander;
using Soneta.Examples.Example3.Extender;
using Soneta.Tools;

namespace Soneta.Examples.Zadanie1.Extender
{
    public partial class Zadanie1
    {
        public string RunGitCommand(string command)
        {
            CMDCommand cmd = new CMDCommand(GitWorkDir, command);
            cmd.Run();
            return cmd.GetText;
        }
        public void LoadList(char _aktywny, string _branch, string _text)
        {
            string _commit = string.Empty;
            SortedDictionary<string, PolaListyComitow> _lista = new SortedDictionary<string, PolaListyComitow>();

            foreach (string s in _text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                try
                {
                    if (s.Trim() == string.Empty) continue;
                    if (s.Contains("commit") & s[0] == 'c')
                    {
                        _commit = _branch + s.Split(new char[] { ' ' })[1];
                        _lista.Add(_commit, new PolaListyComitow
                        {
                            Aktywny = _aktywny,
                            Branche = _branch,
                            Commit = _commit
                        });
                        continue;
                    }
                    if (s.Contains("Merge:") & s[0] == 'M')
                    {
                        _lista[_commit].Merge = s.Split(new char[] { ':' })[1].TrimStart().TrimEnd();
                        continue;
                    }
                    if (s.Contains("Author:") & s[0] == 'A')
                    {
                        string[] elementy = s.Split(new char[] { ' ' });
                        _lista[_commit].Autor += elementy[1];
                        if (!elementy[2].Contains("<") & !elementy[2].Contains(">"))
                            _lista[_commit].Autor += " " + elementy[2];
                        continue;
                    }
                    if (s.Contains("Date:") & s[0] == 'D')
                    {
                        _lista[_commit].Data = DateTime.ParseExact(s.Replace("Date:", string.Empty).TrimStart(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        continue;
                    }
                    if (s.Contains("Merge pull request"))
                        continue;

                    if (s.Contains("|") & (s.Contains("+") | s.Contains("-")))
                        continue;
                    if (s.Contains("file") & (s.Contains("(+)") | s.Contains("(-)")))
                        continue;
                    if (!s.Contains("git-svn-id:") & !s.Contains("cherry picked from commit") & !s.Contains("Signed-off-by:"))
                        _lista[_commit].Opis = s.TrimStart().TrimEnd();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Błąd odczytu listy commit'ów GIT'a\ncommit:\n\n" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new System.Exception("Błąd odczytu listy commit'ów GIT'a\ncommit:\n\n" + ex.ToString());
                }
            foreach (KeyValuePair<string, PolaListyComitow> l in _lista.OrderBy(l => l.Value.Data))
            {
                _ListCommits.Add(l.Key, l.Value);
            }
        }
        public List<PolaListyBranches> GetBranches(string _text)
        {
            List<PolaListyBranches> _lista = new List<PolaListyBranches>();

            string _nazwa;

            foreach (string s in _text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                try
                {
                    char _aktywny = '\0';
                    if (s.Contains("*"))
                    {
                        _aktywny = '*';
                        _nazwa = s.Split(new char[] { ' ' })[1];
                    }
                    else
                    {
                        _nazwa = s.Trim();
                    }
                    _lista.Add(new PolaListyBranches()
                    {
                        Aktywny = _aktywny,
                        Branche = _nazwa
                    });
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Błąd odczytu listy branches\n\n" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new System.Exception("Błąd odczytu listy branches\n\n" + ex.ToString());
                }

            return _lista;
        }
        public void FiltrAutorList(string Autor)
        {
            //var c = from l in _ListCommits
            //        group l by new { l.Value.Autor, l.Value.Data }
            //        into grupa
            //        select grupa.FirstOrDefault();

            var c = from l in _ListCommits
                    //group l by new { l.Value.Branche, l.Value.Autor, l.Value.Data }
                    group l by new { l.Value.Autor, l.Value.Data }
                    into g
                    select g.FirstOrDefault();



            SortedDictionary<string, PolaListyComitow> _listtmp = new SortedDictionary<string, PolaListyComitow>();
            //foreach (KeyValuePair<string, PolaListyComitow> l in _ListCommits.Where(c => c.Value.Autor == Autor))
            foreach (KeyValuePair<string, PolaListyComitow> l in c)
            {
                l.Value.Ilosc = _ListCommits.Where(w => w.Value.Autor == l.Value.Autor & w.Value.Data == l.Value.Data).Count();
                _listtmp.Add(l.Key, l.Value);
            }
            //MessageBox.Show("_listtmp\n\n" + _listtmp.Count.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _ListCommits.Clear();
            //MessageBox.Show("_ListCommits.Clear()\n\n" + _listtmp.Count.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (KeyValuePair<string, PolaListyComitow> l in _listtmp)
            {
                _ListCommits.Add(l.Key, l.Value);
            }
        }
    }
}