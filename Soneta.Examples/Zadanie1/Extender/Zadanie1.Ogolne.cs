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

        private SortedDictionary<string, PolaListyComitow> _ListCommits;
        public IEnumerable<PolaListyComitow> KursyWalut
        {
            get
            {
                if (_ListCommits != null) return
                    _ListCommits.Values.ToArray();

                _ListCommits = new SortedDictionary<string, PolaListyComitow> {
                    {
                        "0", new PolaListyComitow {
                            Branche="master",
                            Commit = "0000000000000000000",
                            Autor = "Wojciech Dziedzic",
                            Data = "01.05.2018",
                            Opis = "Test 1"
                        }
                    },
                    {
                        "1", new PolaListyComitow {
                            Branche="master",
                            Commit = "111111111111111111111",
                            Autor = "Wojciech Dziedzic",
                            Data = "01.05.2018",
                            Opis = "Test 1"
                        }
                    },
                    {
                        "2", new PolaListyComitow {
                            Branche="master",
                            Commit = "22222222222222222",
                            Autor = "Wojciech Dziedzic",
                            Data = "01.05.2018",
                            Opis = "Test 1"
                        }
                    }
                };
                return _ListCommits.Values.ToArray();
            }
        }

        #endregion Property dla formularza
    }

}
