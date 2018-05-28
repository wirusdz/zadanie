using System;
using System.Collections.Generic;
using System.Linq;
using Soneta.Business;
using Soneta.Examples.Zadanie1.Extander;
//using Soneta.Examples.Example3.Extender;

namespace Soneta.Examples.Zadanie1.Extender
{
    public partial class Zadanie1
    {
        [Context(Required = true)]
        public Context Context { get; set; }

        [Context(Required = true)]
        public Session Session { get; set; }

        #region Widoczność zakładki

        /// <summary>
        /// Metoda pozwalająca na sterowanie widocznościa zakładki.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        ///     true - widoczność zakładki, 
        ///     false - zakładka niewidoczna
        /// </returns>
        public static bool IsVisible(Context context)
        {
            //bool result;
            //using (var session = context.Login.CreateSession(true, true))
            //{
            //    result = CfgWalutyNbpExtender.GetValue(session, "AktywneKursyNbp", false);
            //}
            return true;
        }

        #endregion Widoczność zakładki

        #region Property dla formularza

        private SortedDictionary<string, PolaListyComitow> _ListCommits = new SortedDictionary<string, PolaListyComitow>();

        public IEnumerable<PolaListyComitow> ListaComitow
        {
            get
            {
                //WczytanieListyCommitow();
                //FiltrAutorList("wdziedzic");
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
                throw new System.Exception(ex.ToString());
            }
            finally
            {
                //RunGitCommand(GitReset);
                RunGitCommand(GitSetBranche + _akt.Branche);
            }

        }
        #endregion Property dla formularza
    }

}
