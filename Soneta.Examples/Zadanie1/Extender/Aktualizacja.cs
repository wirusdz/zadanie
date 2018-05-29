using Soneta.Business;
using Soneta.Business.UI;


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
                    FiltrSrednioCommitowDziennie();
                    // Wymuszamy odświeżenie listy 
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }
    }
}