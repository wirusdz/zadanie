using Soneta.Business.UI;
using Soneta.Examples.Example4.Extender;
using Soneta.Examples.Zadanie1.Extender;

[assembly: FolderView("Soneta.Examples/Zadanie1",
    Priority = 12,
    Description = "Zadanie rekrutacyjne ....",
    ObjectType = typeof(Zadanie1),
    ObjectPage = "Zadanie1.Ogolne.pageform.xml",
    ReadOnlySession = false,
    ConfigSession = false
)]
