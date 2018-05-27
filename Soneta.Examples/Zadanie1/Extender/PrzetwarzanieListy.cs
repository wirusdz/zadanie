﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
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
            CMDCommand cmd = new CMDCommand(GitWorkDir,command);
            cmd.Run();
            return cmd.GetText;
        }
        public void LoadList(char _aktywny, string _branch, string _text)
        {
            string _commit = string.Empty;

            foreach (string s in _text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                try
                {
                    if (s.Trim() == string.Empty) continue;
                    if (s.Contains("commit") & s[0] == 'c')
                    {
                        _commit = _branch + s.Split(new char[] { ' ' })[1];
                        _ListCommits.Add(_commit, new PolaListyComitow
                        {
                            Aktywny = _aktywny,
                            Branche = _branch,
                            Commit = _commit
                        });
                        continue;
                    }
                    if (s.Contains("Merge:") & s[0] == 'M')
                    {
                        _ListCommits[_commit].Merge = s.Split(new char[] { ':' })[1].TrimStart().TrimEnd();
                        continue;
                    }
                    if (s.Contains("Author:") & s[0] == 'A')
                    {
                        string[] elementy = s.Split(new char[] { ' ' });
                        _ListCommits[_commit].Autor += elementy[1];
                        if (!elementy[2].Contains("<") & !elementy[2].Contains(">"))
                            _ListCommits[_commit].Autor += " " + elementy[2];
                        continue;
                    }
                    if (s.Contains("Date:") & s[0] == 'D')
                    {
                        _ListCommits[_commit].Data = DateTime.ParseExact(s.Replace("Date:", string.Empty).TrimStart(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        continue;
                    }
                    if (s.Contains("Merge pull request"))
                        continue;

                    if (s.Contains("|") & (s.Contains("+") | s.Contains("-")))
                        continue;
                    if (s.Contains("file") & (s.Contains("(+)") | s.Contains("(-)")))
                        continue;
                    if (!s.Contains("git-svn-id:") & !s.Contains("cherry picked from commit") & !s.Contains("Signed-off-by:"))
                        _ListCommits[_commit].Opis = s.TrimStart().TrimEnd();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Błąd odczytu listy commit'ów GIT'a\ncommit:\n\n" + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new System.Exception("Błąd odczytu listy commit'ów GIT'a\ncommit:\n\n" + ex.ToString());
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
    }
}