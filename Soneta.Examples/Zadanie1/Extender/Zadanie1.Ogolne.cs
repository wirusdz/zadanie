using System;
using System.Collections.Generic;
using System.Linq;
using Soneta.Business;

namespace Soneta.Examples.Zadanie1.Extender
{
    public partial class Zadanie1
    {
        [Context(Required = true)]
        public Context Context { get; set; }

        [Context(Required = true)]
        public Session Session { get; set; }

        private bool _ListaPelna = false;
        private bool _WszystkiePola = true;

        private string _GitWorkDir = string.Empty;

        #region Property dla formularza

        private SortedDictionary<string, PolaListyComitow> _ListCommits = new SortedDictionary<string, PolaListyComitow>();

        public bool IsLista
        {
            get
            {
                return _ListaPelna;
            }
        }

        public string GitWorkDirEdit
        {
            get
            {
                return (_GitWorkDir == string.Empty) ? GitWorkDir : _GitWorkDir;
            }
            set
            {
                _GitWorkDir = value;
            }
        }

        public bool IsWszystkiePola
        {
            get
            {
                return _WszystkiePola;
            }
        }
        public IEnumerable<PolaListyComitow> ListaComitow
        {
            get
            {
                return _ListCommits.Values.ToArray();
            }
        }

        public void WczytanieListyCommitow()
        {
            PolaListyBranches _akt = new PolaListyBranches();
            try
            {
                _ListCommits.Clear();
                _akt.Aktywny = '\0';
                foreach (PolaListyBranches br in GetBranches(RunGitCommand(GitGetBranches)))
                {
                    if (br.Aktywny != '*') RunGitCommand(GitSetBranche + br.Branche);
                    LoadList(br.Aktywny, br.Branche, RunGitCommand(GitGetCommits));
                    if (br.Aktywny == '*') _akt.Branche = br.Branche;
                }
            }
            catch (Exception ex)
            {
                _ListaPelna = false;
                throw new System.Exception(ex.ToString());
            }
            finally
            {
                _ListaPelna = true;
                _WszystkiePola = true;
                //RunGitCommand(GitReset);
                RunGitCommand(GitSetBranche + _akt.Branche);
            }

        }
        #endregion Property dla formularza
    }

}
