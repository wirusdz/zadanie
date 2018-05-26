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
                    LoadList();

                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }
    }
}