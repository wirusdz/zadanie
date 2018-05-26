using System;
using System.IO;
using System.Text;
using System.Xml;
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
        public MessageBoxInformation LoadCommits()
        {
            return new MessageBoxInformation(Strings.St_MsgTitleZadanie, Strings.St_MsgTextZadanie)
            {
                YesHandler = () =>
                {
                    // Wczytujemy aktualne kursy 
                    GetCommits();

                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }

        private void GetCommits()
        {
            _ListCommits.Clear();
            CMDCommand cmd = new CMDCommand();
            cmd.Command = "git fetch origin";
            cmd.Run();
            _ListCommits = new SortedDictionary<string, PolaListyComitow> {
                    {
                        "9", new PolaListyComitow {
                            Branche="master",
                            Commit = "9999",
                            Autor = "Wojciech Dziedzic",
                            Data = "01.05.2018",
                            Opis = cmd.GetText
                        }
                    }
                };

        }

    }
}