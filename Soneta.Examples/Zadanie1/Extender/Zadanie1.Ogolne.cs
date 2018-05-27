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
        private string GitWorkDir;

        public IEnumerable<PolaListyComitow> ListaComitow
        {
            get
            {
                return _ListCommits.Values.ToArray();
            }
        }

        #endregion Property dla formularza
    }

}
