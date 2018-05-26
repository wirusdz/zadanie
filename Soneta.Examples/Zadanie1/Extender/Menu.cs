#define ZADANIE1

using Soneta.Business.UI;
using Soneta.Examples.Zadanie1.Extender;

#if ZADANIE1

[assembly: FolderView("Soneta.Examples/Zadanie1",
    Priority = 12,
    Description = "Zadanie rekrutacyjne",
    ObjectType = typeof(Zadanie1),
    ObjectPage = "Zadanie1.Ogolne.pageform.xml",
    ReadOnlySession = false,
    ConfigSession = false
)]

#endif