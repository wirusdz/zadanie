using System;
using System.IO;
using System.Text;
using System.Xml;
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
        public MessageBoxInformation LoadCommits()
        {
            return new MessageBoxInformation(Strings.St_MsgTitleZadanie, Strings.St_MsgTextZadanie)
            {
                YesHandler = () =>
                {
                    // Wczytujemy listę commitów
                    WczytanieListyCommitow();

                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }
        public MessageBoxInformation CommitowNaDzien()
        {
            return new MessageBoxInformation(Strings.St_MsgTitleZadanie, Strings.St_MsgTextZadanie)
            {
                YesHandler = () =>
                {
                    //_ListCommits.Clear();
                    FiltrCommitowNaDzien();
                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }
        public MessageBoxInformation SrednioCommitowDziennie()
        {
            return new MessageBoxInformation(Strings.St_MsgTitleZadanie, Strings.St_MsgTextZadanie)
            {
                YesHandler = () =>
                {
                    //_ListCommits.Clear();
                    FiltrSrednioCommitowDziennie();
                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }
    }
}